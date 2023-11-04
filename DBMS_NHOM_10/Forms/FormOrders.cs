using DBMS_NHOM_10.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_NHOM_10.Forms
{
    public partial class FormOrders : Form
    {

        public FormOrders ()
        {
            InitializeComponent();
            danhsach_hoadon();
            Functions.FillCombo("SELECT DISTINCT TrangThai FROM HoaDon", cbb_timkiem_tt, "TrangThai", "TrangThai");
            cbb_timkiem_tt.SelectedIndex = -1;
            AddContextMenu();
        }

        public void danhsach_hoadon()
        {
            string query = "SELECT * FROM HoaDon";

            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_Order.DataSource = table;

            dataGridView_Order.Columns[0].HeaderText = "ID Hóa Đơn";
            dataGridView_Order.Columns[1].HeaderText = "ID Nhân Viên";
            dataGridView_Order.Columns[2].HeaderText = "ID Khách Hàng";
            dataGridView_Order.Columns[3].HeaderText = "Ngày Tạo";
            dataGridView_Order.Columns[4].HeaderText = "Trị Giá";
            dataGridView_Order.Columns[5].HeaderText = "Tình Trạng";

            dateTimePicker_HD.Format = DateTimePickerFormat.Custom;
            dateTimePicker_HD.CustomFormat = "dd/MM/yyyy";
            DateTime dateTime = DateTime.Now;
            dateTimePicker_HD.Value = dateTime;
        }

        ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem2 = new ToolStripMenuItem();

        private void AddContextMenu()
        {
            toolStripItem1.Text = "Chi Tiết Hóa Đơn";
            toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
            toolStripItem2.Text = "Xóa Hóa Đơn";
            toolStripItem2.Click += new EventHandler(toolStripItem2_Click);
            ContextMenuStrip strip = new ContextMenuStrip();

            foreach (DataGridViewColumn column in dataGridView_Order.Columns)
            {

                column.ContextMenuStrip = strip;
                column.ContextMenuStrip.Items.Add(toolStripItem1);
                column.ContextMenuStrip.Items.Add(toolStripItem2);

            }
        }

        private DataGridViewCellEventArgs mouseLocation;

        private void toolStripItem1_Click(object sender, EventArgs args)
        {
            string value = dataGridView_Order.Rows[mouseLocation.RowIndex].Cells["idHD"].Value.ToString();
            string value1 = dataGridView_Order.Rows[mouseLocation.RowIndex].Cells["TrangThai"].Value.ToString();

            
            btn_cthd.Text = "ID Hóa Đơn: "+value+"\nTrạng Thái: "+value1;


            using (SqlConnection connection = DataBaseConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand("proc_ChiTietHoaDon", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_hoadon", value); // Thay thế yourHoaDonID bằng giá trị thực tế.


                // Khởi tạo các DataTable cho từng bảng kết quả
                DataTable khachHangTable = new DataTable();
                DataTable nhanVienTable = new DataTable();
                DataTable dienThoaiTable = new DataTable();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Đọc và lưu trữ bảng kết quả Khách hàng
                    khachHangTable.Load(reader);

                    // Chuyển sang bảng kết quả Nhân viên
                    nhanVienTable.Load(reader);

                    // Chuyển sang bảng kết quả Điện thoại
                    dienThoaiTable.Load(reader);
                }

                // Hiển thị dữ liệu từ các DataTable trên các iều khiển DataGridView hoặc ListView, ListBox, ...
                dataGridView_CTHD_kh.DataSource = khachHangTable;
                dataGridView_CTDH_nv.DataSource = nhanVienTable;
                dataGridView_CTHD_dt.DataSource = dienThoaiTable;
            }

        }

        private void toolStripItem2_Click(object sender, EventArgs args)
        {
            string value = dataGridView_Order.Rows[mouseLocation.RowIndex].Cells["idHD"].Value.ToString();
            string sql = "DELETE FROM HoaDon WHERE idHD = '" + value + "'";
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Hóa Đơn "+value, "Thông Báo", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataBaseConnection.GetSqlConnection(); //Gán kết nối
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                load_refresh();
            }
            Refresh();

        }

        private void dataGridView_CellMouseEnter(object sender,DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void btnDateHD_Click(object sender, EventArgs e)
        {

            timkiemhoadon_date();

            btn_cthd.Text = "ID Hóa Đơn:";
            dataGridView_CTDH_nv.DataSource = null;
            dataGridView_CTHD_dt.DataSource = null;
            dataGridView_CTHD_kh.DataSource = null;
        }
        public void timkiemhoadon_date()
        {
            DateTime dateTime = dateTimePicker_HD.Value;

            string dateString = dateTime.ToString();
            string query = "exec proc_timkiemhoadon_date_and_status" + " N'" + dateString + "',null";

            SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView_Order.DataSource= dataTable;
        }
        private void btnTrangThaiHD_Click(object sender, EventArgs e)
        {
            timkiemhoadon_status();
            btn_cthd.Text = "ID Hóa Đơn:";
            dataGridView_CTDH_nv.DataSource = null;
            dataGridView_CTHD_dt.DataSource = null;
            dataGridView_CTHD_kh.DataSource = null;

        }
        public void timkiemhoadon_status()
        {
            
            string query = "exec proc_timkiemhoadon_date_and_status" + " null,N'" + cbb_timkiem_tt.SelectedValue + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView_Order.DataSource = dataTable;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load_refresh();
        }
        public void load_refresh()
        {
            string query = "SELECT * FROM HoaDon";

            btn_cthd.Text = "ID Hóa Đơn:";
            cbb_timkiem_tt.Text = "";
            dataGridView_CTDH_nv.DataSource = null;
            dataGridView_CTHD_dt.DataSource = null;
            dataGridView_CTHD_kh.DataSource = null;

            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_Order.DataSource = table;

            DateTime dateTime = DateTime.Now;
            dateTimePicker_HD.Value = dateTime;
        }

    }
}
