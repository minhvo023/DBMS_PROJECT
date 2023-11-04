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
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();

        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            danhsach_khachhang();
            AddContextMenu();
        }
        public void danhsach_khachhang()
        {
            string query = "SELECT * FROM v_khachhang";

            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_Customer.DataSource = table;

            dataGridView_Customer.Columns[0].HeaderText = "ID";
            dataGridView_Customer.Columns[1].HeaderText = "Họ và Tên";
            dataGridView_Customer.Columns[2].HeaderText = "Số Điện Thoại";
            dataGridView_Customer.Columns[3].HeaderText = "Địa Chỉ";
        }
        private void btnSearch_sđt_Click(object sender, EventArgs e)
        {
            string value = txb_TimKiem_sdt.Text;
            if (value == "")
            {
                string query = "exec proc_timkiemkhachhang_sdt null";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView_Customer.DataSource = dataTable;
            }
            else
            {
                string query = "exec proc_timkiemkhachhang_sdt '"+ value +"'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView_Customer.DataSource = dataTable;
            }
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

            toolStripItem3.Text = "Sửa thông tin khách hàng";
            toolStripItem3.Click += new EventHandler(toolStripItem_Sua_Click);

            toolStripItem4.Text = "Thêm mới khách hàng";
            toolStripItem4.Click += new EventHandler(toolStripItem_Them_Click);

            ContextMenuStrip strip = new ContextMenuStrip();
            foreach (DataGridViewColumn column in dataGridView_Customer.Columns)
            {

                column.ContextMenuStrip = strip;
                column.ContextMenuStrip.Items.Add(toolStripItem1);
                column.ContextMenuStrip.Items.Add(toolStripItem2);
                column.ContextMenuStrip.Items.Add(toolStripItem3);
                column.ContextMenuStrip.Items.Add(toolStripItem4);

            }
        }

        private void toolStripItem_lsmh_Click(object sender, EventArgs args)
        {
            string value = dataGridView_Customer.Rows[mouseLocation.RowIndex].Cells["idKH"].Value.ToString();

            DataTable dt = Procedure.proc_lichsumuahang(value);

            dataGridView_lsmh.DataSource = dt;
            btn_lsmh.Text = "ID Khách Hàng: " + value;

            dataGridView_lsmh.Columns[0].HeaderText = "ID Hóa Đơn";
            dataGridView_lsmh.Columns[1].HeaderText = "Ngày Mua";
            dataGridView_lsmh.Columns[2].HeaderText = "Tên Điện Thoại";
            dataGridView_lsmh.Columns[3].HeaderText = "Màu Sắc";
            dataGridView_lsmh.Columns[4].HeaderText = "Dung Lượng";
            dataGridView_lsmh.Columns[5].HeaderText = "Số Lượng";
            dataGridView_lsmh.Columns[6].HeaderText = "Tổng Tiền";

        }
        private void toolStripItem_Sua_Click(object sender, EventArgs args)
        {

            string ck = "sửa";
            DataGridViewRow datarow = dataGridView_Customer.Rows[mouseLocation.RowIndex];
            FormEditKH form_edit_dt = new FormEditKH(datarow, ck);
            form_edit_dt.ShowDialog();


        }

        private void toolStripItem_Them_Click(object sender, EventArgs args)
        {

            string ck = "thêm";
            DataGridViewRow datarow = dataGridView_Customer.Rows[mouseLocation.RowIndex];
            FormEditKH form_edit_dt = new FormEditKH(datarow, ck);
            form_edit_dt.ShowDialog();

        }

        private void toolStripItem_Xoa_Click(object sender, EventArgs args)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string sql;
                string a = dataGridView_Customer.Rows[mouseLocation.RowIndex].Cells["idKH"].Value.ToString();
                sql = "DELETE FROM KhachHang WHERE idKH = '" + a.Trim() + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataBaseConnection.GetSqlConnection();
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {

            }

        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }


    }
}
