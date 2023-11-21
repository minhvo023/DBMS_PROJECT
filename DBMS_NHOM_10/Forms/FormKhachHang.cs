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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();

        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            danhsach_khachhang();
            AddContextMenu();
        }

        public void KhachHang_TKsdt()
        {
            try
            {
                string value = txb_TimKiem_sdt.Text;
                string query = "exec proc_KhachHang_TK_sdt '" + value + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DBConnection.open());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView_Customer.DataSource = dataTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_refresh(dataGridView_Customer);
            }
            finally
            {
                DBConnection.close();
            }
        }
        public void KhachHang_lsmh()
        {
            try
            {
                string value = dataGridView_Customer.Rows[mouseLocation.RowIndex].Cells["idKH"].Value.ToString();

                string query = "exec proc_KhachHang_lsmh N'" + value.Trim() + "'";
                SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                DataTable table = new DataTable();
                dap.Fill(table);
                DataTable dt = table;
                dataGridView_lsmh.DataSource = dt;
                btn_lsmh.Text = "ID Khách Hàng [ " + value + " ]";

                dataGridView_lsmh.Columns[0].HeaderText = "ID Hóa Đơn";
                dataGridView_lsmh.Columns[1].HeaderText = "Ngày Mua";
                dataGridView_lsmh.Columns[2].HeaderText = "Tên Điện Thoại";
                dataGridView_lsmh.Columns[3].HeaderText = "Màu Sắc";
                dataGridView_lsmh.Columns[4].HeaderText = "Dung Lượng";
                dataGridView_lsmh.Columns[5].HeaderText = "Số Lượng";
                dataGridView_lsmh.Columns[6].HeaderText = "Tổng Tiền";

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_lsmh.Text = "ID Khách Hàng [ ]";
                dataGridView_lsmh.DataSource = null;
            }
            finally
            {
                DBConnection.close();
            }
        }

        public void KhachHang_Xoa()
        {
            string err;
            try
            {
                string sql;
                string a = dataGridView_Customer.Rows[mouseLocation.RowIndex].Cells["idKH"].Value.ToString();
                sql = "exec proc_KhachHang_XoaKH '" + a.Trim() + "'";
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


        public void danhsach_khachhang()
        {
            try
            {
                string query = "SELECT * FROM v_khachhang";

                SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                DataTable table = new DataTable();
                dap.Fill(table);
                dataGridView_Customer.DataSource = table;

                dataGridView_Customer.Columns[0].HeaderText = "ID";
                dataGridView_Customer.Columns[1].HeaderText = "Họ và Tên";
                dataGridView_Customer.Columns[2].HeaderText = "Số Điện Thoại";
                dataGridView_Customer.Columns[3].HeaderText = "Địa Chỉ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { DBConnection.close(); }
        }
        private void btnSearch_sđt_Click(object sender, EventArgs e)
        {
            KhachHang_TKsdt();
            dataGridView_lsmh.DataSource = null;
        }

        
        ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem2 = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem3 = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem4 = new ToolStripMenuItem();


        private DataGridViewCellEventArgs mouseLocation;

        private void AddContextMenu()
        {
            toolStripItem1.Text = "Lịch Sử Mua Hàng";
            toolStripItem1.Click += new EventHandler(toolStripItem_lsmh_Click);

            toolStripItem2.Text = "Xóa Khách Hàng";
            toolStripItem2.Click += new EventHandler(toolStripItem_Xoa_Click);

            toolStripItem3.Text = "Chỉnh Sửa Thông Tin";
            toolStripItem3.Click += new EventHandler(toolStripItem_Sua_Click);

            toolStripItem4.Text = "Thêm mới khách hàng";
            toolStripItem4.Click += new EventHandler(toolStripItem_Them_Click);

            ContextMenuStrip strip = new ContextMenuStrip();
            foreach (DataGridViewColumn column in dataGridView_Customer.Columns)
            {

                column.ContextMenuStrip = strip;
                column.ContextMenuStrip.Items.Add(toolStripItem1);
                column.ContextMenuStrip.Items.Add(toolStripItem4);
                column.ContextMenuStrip.Items.Add(toolStripItem3);
                column.ContextMenuStrip.Items.Add(toolStripItem2);

            }
        }

        private void toolStripItem_lsmh_Click(object sender, EventArgs args)
        {
            KhachHang_lsmh();

        }
        
        private void toolStripItem_Sua_Click(object sender, EventArgs args)
        {

            string ck = "sửa";
            KhachHang_them_sua(ck);


        }

        private void toolStripItem_Them_Click(object sender, EventArgs args)
        {

            string ck = "thêm";
            KhachHang_them_sua(ck);

        }
        public void KhachHang_them_sua(string ck)
        {
            DataGridViewRow datarow = dataGridView_Customer.Rows[mouseLocation.RowIndex];
            FormEditKhachHang form_edit_nv = new FormEditKhachHang(dataGridView_Customer,datarow, ck);
            form_edit_nv.ShowDialog();
        }
        private void toolStripItem_Xoa_Click(object sender, EventArgs args)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                KhachHang_Xoa();
            }
            else
            {

            }

        }
        

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load_refresh(dataGridView_Customer);
            txb_TimKiem_sdt.Text = "";

        }
        public static void load_refresh(DataGridView dgv)
        {
            string query = "SELECT * FROM v_khachhang";
            SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
            DataTable table = new DataTable();
            dap.Fill(table);
            DBConnection.close();

            dgv.DataSource = table;
        }
    }
}
