using DBMS_NHOM_10.Forms_branch;
using DBMS_NHOM_10.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_NHOM_10.Forms
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
            danhsach_nhanvien();
            AddContextMenu();


        }

        public void NhanVien_Xoa() // XÓA NHÂN VIÊN
        {
            string err;
            try
            {
                string sql;
                string a = dataGridView_Employee.Rows[mouseLocation.RowIndex].Cells["idNV"].Value.ToString();
                sql = "exec proc_NhanVien_XoaNV '" + a.Trim() + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBConnection.open();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                err = "Xóa Thành Công";
            }
            catch (SqlException ex)
            {
                err = ex.Message;
            }
            finally
            {
                DBConnection.close();
            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public bool NhanVien_ThongTinChiTiet(string value)
        {
            try
            {
                SqlConnection connection = DBConnection.open();
                SqlCommand cmd = new SqlCommand("proc_NhanVien_ttct", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", value);

                DataTable nhanVienTable = new DataTable();
                DataTable congviecTable = new DataTable();

                SqlDataReader reader = cmd.ExecuteReader();
                // Chuyển sang bảng kết quả Nhân viên
                nhanVienTable.Load(reader);

                // Chuyển sang bảng kết quả Công Việc
                congviecTable.Load(reader);

                dataGridView_ttnv.DataSource = nhanVienTable;
                dataGridView_ttcv.DataSource = congviecTable;

                return true; // Success
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false; // Failure
            }
            finally
            {
                DBConnection.close();
            }
        }


        public void danhsach_nhanvien()
        {
            string query = "SELECT * FROM v_nhanvien";
            try
            {
                SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                DataTable table = new DataTable();
                dap.Fill(table);

                dataGridView_Employee.DataSource = table;

                dataGridView_Employee.Columns[0].HeaderText = "ID";
                dataGridView_Employee.Columns[1].HeaderText = "Họ và Tên";
                dataGridView_Employee.Columns[2].HeaderText = "Số Điện Thoại";
                dataGridView_Employee.Columns[3].HeaderText = "Vị Trí";
                dataGridView_Employee.Columns[4].HeaderText = "Trạng Thái";
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                this.Hide();
            }
            finally { DBConnection.close(); }

        }

        private void btnSearch_sđt_Click(object sender, EventArgs e)
        {
            NhanVien_TKsdt();
        }
        public void NhanVien_TKsdt()
        {
            try
            {
                string value = txb_TimKiem_sdt.Text;
                string query = "exec proc_NhanVien_TK_sdt '" + value + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DBConnection.open());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView_Employee.DataSource = dataTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                DBConnection.close();
            }
        }

        ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem2 = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem3 = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem4 = new ToolStripMenuItem();

        private DataGridViewCellEventArgs mouseLocation;

        private void AddContextMenu()
        {
            toolStripItem1.Text = "Thông Tin Chi Tiết";
            toolStripItem1.Click += new EventHandler(toolStripItem1_Click);

            toolStripItem2.Text = "Chỉnh Sửa Thông Tin";
            toolStripItem2.Click += new EventHandler(toolStripItem2_Click);

            toolStripItem3.Text = "Thêm Nhân Viên";
            toolStripItem3.Click += new EventHandler(toolStripItem3_Click);

            toolStripItem4.Text = "Xóa Nhân Viên";
            toolStripItem4.Click += new EventHandler(toolStripItem4_Click);

            ContextMenuStrip strip = new ContextMenuStrip();
            foreach (DataGridViewColumn column in dataGridView_Employee.Columns)
            {

                column.ContextMenuStrip = strip;
                column.ContextMenuStrip.Items.Add(toolStripItem1);
                column.ContextMenuStrip.Items.Add(toolStripItem2);
                column.ContextMenuStrip.Items.Add(toolStripItem3);
                column.ContextMenuStrip.Items.Add(toolStripItem4);

            }
        }

        private void toolStripItem1_Click(object sender, EventArgs args)
        {
            string value = dataGridView_Employee.Rows[mouseLocation.RowIndex].Cells["idNV"].Value.ToString();
            btn_ttct.Text = "ID Nhân Viên [ " + value.Trim() + " ]";
            if(NhanVien_ThongTinChiTiet(value) is true)
            {
                dataGridView_ttnv.Columns["Ho_Ten"].HeaderText = "Họ và Tên";
                dataGridView_ttnv.Columns["NgaySinh"].HeaderText = "ngày Sinh";
                dataGridView_ttnv.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dataGridView_ttnv.Columns["soDT_NV"].HeaderText = "SĐT";
                dataGridView_ttnv.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dataGridView_ttnv.Columns["TrangThai"].HeaderText = "Trạng Thái";

                dataGridView_ttcv.Columns["idCV"].HeaderText = "ID";
                dataGridView_ttcv.Columns["TenCV"].HeaderText = "Vị Trí";
            }
            
        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void toolStripItem2_Click(object sender, EventArgs args)
        {
            string ck = "sửa";
            NhanVien_them_sua(ck);

        }
        private void toolStripItem3_Click(object sender, EventArgs args)
        {
            string ck = "thêm";
            NhanVien_them_sua(ck);

        }

        private void toolStripItem4_Click(object sender, EventArgs args)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa Nhân Viên", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                NhanVien_Xoa();
            }
            else
            {

            }

        }
        

        public void NhanVien_them_sua(string ck) 
        {
            string datarow = dataGridView_Employee.Rows[mouseLocation.RowIndex].Cells["idNV"].Value.ToString().Trim();
            FormEditNhanVien form_edit_dt = new FormEditNhanVien(dataGridView_Employee,datarow, ck);
            form_edit_dt.ShowDialog();
        }
        public static void load_refresh(DataGridView dgv)
        {
            string query = "SELECT * FROM v_nhanvien";
            try
            {
                SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                DataTable table = new DataTable();
                dap.Fill(table);
                dgv.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { DBConnection.close(); }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load_refresh(dataGridView_Employee);
            btn_ttct.Text = "ID Nhân Viên []";
            txb_TimKiem_sdt.Text = "";
            dataGridView_ttcv.DataSource = null;
            dataGridView_ttnv.DataSource = null;
        }
    }
}
