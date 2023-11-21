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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBMS_NHOM_10.Forms
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon ()
        {
            InitializeComponent();
            danhsach_hoadon();

            cbb_timkiem_tt.SelectedIndex = 0;

            AddContextMenu();
        }


        public void HoaDon_ChiTietHoaDon(string value)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("proc_HoaDon_ChiTietHoaDon", DBConnection.open());
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                DBConnection.close();
            }
        }
        public void HoaDon_Xoa(int pq)
        {
            string value = dataGridView_Order.Rows[mouseLocation.RowIndex].Cells["idHD"].Value.ToString();
            string sql = "exec proc_HoaDon_Delete '" + value.Trim() + "'," + pq;
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Hóa Đơn " + value, "Thông Báo", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql,DBConnection.open());
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { DBConnection.close(); }
            }
        }
        public void HoaDon_TK_NgayHoacTrangThai()
        {
            try
            {

                string query = "SELECT * FROM func_HoaDon_TK_DateVaTrangThai('" + txb_NgayHD.Text.Trim() +"','"+ txb_ThangHD.Text.Trim() +"','"+ txb_NamHD.Text.Trim() + "', N'" + cbb_timkiem_tt.Text.Trim() + "')";
                SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                DataTable table = new DataTable();
                dap.Fill(table);
                dataGridView_Order.DataSource = table;

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally
            {
                DBConnection.close();
            }
        }

        public void danhsach_hoadon()
        {
            try
            {
                string query = "SELECT * FROM v_hoadon";

                SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                DataTable table = new DataTable();
                dap.Fill(table);
                dataGridView_Order.DataSource = table;

                dataGridView_Order.Columns[0].HeaderText = "ID Hóa Đơn";
                dataGridView_Order.Columns[1].HeaderText = "ID Nhân Viên";
                dataGridView_Order.Columns[2].HeaderText = "ID Khách Hàng";
                dataGridView_Order.Columns[3].HeaderText = "Ngày Tạo";
                dataGridView_Order.Columns[4].HeaderText = "Trị Giá";
                dataGridView_Order.Columns[5].HeaderText = "Tình Trạng";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { DBConnection.close(); }

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

            
            btn_cthd.Text = "ID Hóa Đơn [ "+value.Trim()+" ]\nTrạng Thái: "+value1+"\nTổng Số Lượng: " + HoaDon_TongSL(value.Trim());
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

        public string HoaDon_TongSL(string value)
        {
            string sum="";
            try
            {
                string str = "SELECT dbo.func_HoaDon_TongSL('" + value + "')";
                SqlCommand cmd = new SqlCommand(str, DBConnection.open());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    sum = reader.GetValue(0).ToString();
                reader.Close();
                return sum;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return sum;
            }
            finally
            {
                DBConnection.close();
            }
        }
        private void toolStripItem2_Click(object sender, EventArgs args)
        {
            if ("Quản Lý" == Functions.GetFieldValues("SELECT TenCV FROM CongViec join NhanVien ON NhanVien.idCV = CongViec.idCV WHERE idNV ='" + DBConnection.pq + "'"))
            {
                HoaDon_Xoa(1);
                load_refresh();
            }
            else
            {
                HoaDon_Xoa(0);
                load_refresh();
            }

        }

        
        private void dataGridView_CellMouseEnter(object sender,DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void btn_timkiemHD_Click(object sender, EventArgs e)
        {

            HoaDon_TK_NgayHoacTrangThai();

            btn_cthd.Text = "ID Hóa Đơn:";
            dataGridView_CTDH_nv.DataSource = null;
            dataGridView_CTHD_dt.DataSource = null;
            dataGridView_CTHD_kh.DataSource = null;
        }

        public void load_refresh()
        {
            string query = "SELECT * FROM v_hoadon";

            btn_cthd.Text = "ID Hóa Đơn:";
            cbb_timkiem_tt.SelectedIndex = 0;

            dataGridView_CTDH_nv.DataSource = null;
            dataGridView_CTHD_dt.DataSource = null;
            dataGridView_CTHD_kh.DataSource = null;

            SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_Order.DataSource = table;

            DBConnection.close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            load_refresh();

        }

    }
}
