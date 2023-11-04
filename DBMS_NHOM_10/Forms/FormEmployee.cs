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
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            danhsach_nhanvien();
            AddContextMenu();
        }
        public void danhsach_nhanvien()
        {
            string query = "SELECT * FROM v_nhanvien";

            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_Employee.DataSource = table;

            dataGridView_Employee.Columns[0].HeaderText = "ID";
            dataGridView_Employee.Columns[1].HeaderText = "Họ và Tên";
            dataGridView_Employee.Columns[2].HeaderText = "Số Điện Thoại";
            dataGridView_Employee.Columns[3].HeaderText = "Vị Trí";

        }

        private void btnSearch_sđt_Click(object sender, EventArgs e)
        {

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
            toolStripItem2.Click += new EventHandler(toolStripItem1_Click);

            toolStripItem3.Text = "Thêm Nhân Viên";
            toolStripItem3.Click += new EventHandler(toolStripItem1_Click);

            toolStripItem4.Text = "Xóa Nhân Viên";
            toolStripItem4.Click += new EventHandler(toolStripItem1_Click);

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

            DataTable dt = Procedure.proc_lichsumuahang(value);

            /*dataGridView_lsmh.DataSource = dt;
            btn_lsmh.Text = "ID Khách Hàng: " + value;
            dataGridView_lsmh.Columns[0].HeaderText = "Ngày Mua";
            dataGridView_lsmh.Columns[1].HeaderText = "Tên Điện Thoại";
            dataGridView_lsmh.Columns[2].HeaderText = "Màu Sắc";
            dataGridView_lsmh.Columns[3].HeaderText = "Dung Lượng";
            dataGridView_lsmh.Columns[4].HeaderText = "Số Lượng";
            dataGridView_lsmh.Columns[5].HeaderText = "Tổng Tiền";*/

        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }
    }
}
