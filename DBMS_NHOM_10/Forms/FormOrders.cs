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

            cbb_timkiem_tt.Items.Add("Hoàn Thành");
            cbb_timkiem_tt.Items.Add("Đã Hủy");

            AddContextMenu();
        }

        public void danhsach_hoadon()
        {
            string query = "SELECT * FROM v_hoadon";

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

        ToolStripMenuItem toolStripItem3 = new ToolStripMenuItem();


        private void AddContextMenu()
        {
            toolStripItem1.Text = "Chi Tiết Hóa Đơn";
            toolStripItem1.Click += new EventHandler(toolStripItem1_Click);
            toolStripItem2.Text = "Xóa Hóa Đơn - NV";
            toolStripItem2.Click += new EventHandler(toolStripItem2_Click);
            toolStripItem3.Text = "Xóa Hóa Đơn - QL";
            toolStripItem3.Click += new EventHandler(toolStripItem3_Click);
            ContextMenuStrip strip = new ContextMenuStrip();

            foreach (DataGridViewColumn column in dataGridView_Order.Columns)
            {

                column.ContextMenuStrip = strip;
                column.ContextMenuStrip.Items.Add(toolStripItem1);
                column.ContextMenuStrip.Items.Add(toolStripItem2);
                column.ContextMenuStrip.Items.Add(toolStripItem3);
            }
        }

        private DataGridViewCellEventArgs mouseLocation;

        private void toolStripItem1_Click(object sender, EventArgs args)
        {
            string value = dataGridView_Order.Rows[mouseLocation.RowIndex].Cells["idHD"].Value.ToString();
            string value1 = dataGridView_Order.Rows[mouseLocation.RowIndex].Cells["TrangThai"].Value.ToString();

            
            btn_cthd.Text = "ID Hóa Đơn: "+value.Trim()+"\nTrạng Thái: "+value1;
            HoaDon_ChiTietHoaDon(value);

            dataGridView_CTHD_kh.Columns["idKH"].HeaderText = "ID Khách";
            dataGridView_CTHD_kh.Columns["TenKH"].HeaderText = "Họ và Tên";
            dataGridView_CTHD_kh.Columns["soDT_KH"].HeaderText = "SĐT";
            dataGridView_CTHD_kh.Columns["DiaChi"].HeaderText = "Địa Chỉ";

            dataGridView_CTDH_nv.Columns["idNV"].HeaderText = "ID Nhân Viên";
            dataGridView_CTDH_nv.Columns["Ho_Ten"].HeaderText = "Họ và Tên";
            dataGridView_CTDH_nv.Columns["TenCV"].HeaderText = "Vị Trí";

            dataGridView_CTHD_dt.Columns["idDienThoai"].HeaderText = "ID Điện Thoại";
            dataGridView_CTHD_dt.Columns["TenDienThoai"].HeaderText = "Tên";
            dataGridView_CTHD_dt.Columns["TenHangDT"].HeaderText = "Hãng";
            dataGridView_CTHD_dt.Columns["MauSac"].HeaderText = "Màu sắc";
            dataGridView_CTHD_dt.Columns["DungLuong"].HeaderText = "Dung lượng";
            dataGridView_CTHD_dt.Columns["GiaBan"].HeaderText = "Giá";
            dataGridView_CTHD_dt.Columns["SoLuong"].HeaderText = "Số lượng";

        }

        public void HoaDon_ChiTietHoaDon(string value)
        {
            try
            {
                SqlConnection connection = DataBaseConnection.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("proc_HoaDon_ChiTietHoaDon", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_hoadon", value);

                DataTable khachHangTable = new DataTable();
                DataTable nhanVienTable = new DataTable();
                DataTable dienThoaiTable = new DataTable();

                SqlDataReader reader = cmd.ExecuteReader();
                // Đọc và lưu trữ bảng kết quả Khách hàng
                khachHangTable.Load(reader);

                // Chuyển sang bảng kết quả Nhân viên
                nhanVienTable.Load(reader);

                // Chuyển sang bảng kết quả Điện thoại
                dienThoaiTable.Load(reader);

                dataGridView_CTHD_kh.DataSource = khachHangTable;
                dataGridView_CTDH_nv.DataSource = nhanVienTable;
                dataGridView_CTHD_dt.DataSource = dienThoaiTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripItem2_Click(object sender, EventArgs args)
        {
            Xoa_HoaDon(0);
            load_refresh();

        }
        private void toolStripItem3_Click(object sender, EventArgs args)
        {
            Xoa_HoaDon(1);
            load_refresh();

        }

        public void Xoa_HoaDon(int pq)
        {
            string value = dataGridView_Order.Rows[mouseLocation.RowIndex].Cells["idHD"].Value.ToString();
            string sql = "exec proc_HoaDon_Delete '" + value + "'," + pq;
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Hóa Đơn " + value, "Thông Báo", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataBaseConnection.GetSqlConnection(); ;
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dataGridView_CellMouseEnter(object sender,DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void btn_timkiemHD_Click(object sender, EventArgs e)
        {

            TimKiemHD_NgayHoacTrangThai();

            btn_cthd.Text = "ID Hóa Đơn:";
            dataGridView_CTDH_nv.DataSource = null;
            dataGridView_CTHD_dt.DataSource = null;
            dataGridView_CTHD_kh.DataSource = null;
        }
        public void TimKiemHD_NgayHoacTrangThai()
        {
            try
            {
                DateTime dateTime = dateTimePicker_HD.Value;

                string dateString = dateTime.ToString("dd/MM/yyyy");
                string query = "exec proc_HoaDon_TK_NgayHoacTrangThai" + " N'" + dateString + "', N'"+ cbb_timkiem_tt.Text.Trim() +"'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView_Order.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                cbb_timkiem_tt.Text = "";
                DateTime dateTime = DateTime.Now;
                dateTimePicker_HD.Value = dateTime;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load_refresh();
        }
        public void load_refresh()
        {
            string query = "SELECT * FROM v_hoadon";

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
