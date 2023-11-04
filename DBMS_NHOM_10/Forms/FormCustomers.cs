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
                DataTable dt = Procedure.proc_timkiemkhachhang_sdt("null");
                dataGridView_Customer.DataSource = dt;
            }
            else
            {
                DataTable dt = Procedure.proc_timkiemkhachhang_sdt(value);
                dataGridView_Customer.DataSource = dt;
            }
        }

        ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
        private DataGridViewCellEventArgs mouseLocation;

        private void AddContextMenu()
        {
            toolStripItem1.Text = "Lịch Sử Mua Hàng";
            toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
            ContextMenuStrip strip = new ContextMenuStrip();
            foreach (DataGridViewColumn column in dataGridView_Customer.Columns)
            {

                column.ContextMenuStrip = strip;
                column.ContextMenuStrip.Items.Add(toolStripItem1);
            }
        }

        private void toolStripItem1_Click(object sender, EventArgs args)
        {
            string value = dataGridView_Customer.Rows[mouseLocation.RowIndex].Cells["idKH"].Value.ToString();

            DataTable dt = Procedure.proc_lichsumuahang(value);

            dataGridView_lsmh.DataSource = dt;
            btn_lsmh.Text = "ID Khách Hàng: " + value;
            dataGridView_lsmh.Columns[0].HeaderText = "Ngày Mua";
            dataGridView_lsmh.Columns[1].HeaderText = "Tên Điện Thoại";
            dataGridView_lsmh.Columns[2].HeaderText = "Màu Sắc";
            dataGridView_lsmh.Columns[3].HeaderText = "Dung Lượng";
            dataGridView_lsmh.Columns[4].HeaderText = "Số Lượng";
            dataGridView_lsmh.Columns[5].HeaderText = "Tổng Tiền";

        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }


    }
}
