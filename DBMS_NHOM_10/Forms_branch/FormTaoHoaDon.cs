using DBMS_NHOM_10.Forms;
using DBMS_NHOM_10.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBMS_NHOM_10.Forms_branch
{
    public partial class FormTaoHoaDon : Form
    {
        DataTable tblCTHDB;
        public double SLcon, tong, Tongmoi = 0;
        public FormTaoHoaDon()
        {
            InitializeComponent();
        }
        public FormTaoHoaDon(DataTable giaTriTuFormCha)
        {
            InitializeComponent();
            dgv_giohangdt.DataSource = giaTriTuFormCha;
            dgv_giohangdt.Columns[0].HeaderText = "ID";
            dgv_giohangdt.Columns[1].HeaderText = "Tên";
            dgv_giohangdt.Columns[2].HeaderText = "Giá Bán";
            dgv_giohangdt.Columns[3].HeaderText = "Số lượng";
        }
        private void FormTaoHoaDon_Load(object sender, EventArgs e)
        {

            txtTongTien.Text = "0";

            Functions.FillCombo("SELECT idNV, Ho_Ten FROM NhanVien", cboMaNhanVien, "idNV", "idNV");
            cboMaNhanVien.SelectedIndex = -1;

            foreach (DataGridViewRow row in dgv_giohangdt.Rows)
            {
                string value = row.Cells[0].Value.ToString().Trim();
                cboMaHang.Items.Add(value);   
            }
            cboMaHang.SelectedIndex = -1;

            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.idDienThoai, b.TenDienThoai, a.SoLuong, b.GiaBan,a.TongTien " +
                "FROM ChiTietHoaDon AS a, DienThoai AS b WHERE a.idHD = N'" + txtMaHDBan.Text.Trim() + "' AND a.idDienThoai=b.idDienThoai";
            tblCTHDB = Functions.GetDataToTable(sql);

            dgvHDBanHang.DataSource = tblCTHDB;
            dgvHDBanHang.Columns[0].HeaderText = "ID";
            dgvHDBanHang.Columns[1].HeaderText = "Tên";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Thành tiền";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            openControl();
            string str = "SELECT count(idHD) FROM HoaDon";
            int k = int.Parse(Functions.GetFieldValues(str)) + 1;
            string formattedResult = k.ToString("D2"); // Định dạng số nguyên k với 2 chữ số
            txtMaHDBan.Text = "HD_" + formattedResult;
            LoadDataGridView();
        }

        
        private void openControl()
        {
            txtNgayBan.Text = DateTime.Now.ToShortDateString();
            cboMaHang.Enabled= true;
            cboMaNhanVien.Enabled= true;
            btn_Tim.Enabled= true;
            txb_TimKH.ReadOnly=false;
        }


        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNhanVien.Text == "")
                txtTenNhanVien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select Ho_Ten from NhanVien where idNV =N'" + cboMaNhanVien.SelectedValue + "'";
            txtTenNhanVien.Text = Functions.GetFieldValues(str);
        }



        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaHang.Text == "")
            {
                txtTenHang.Text = "";
                txtDonGiaBan.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenDienThoai FROM DienThoai WHERE idDienThoai =N'" + cboMaHang.Text + "'";
            txtTenHang.Text = Functions.GetFieldValues(str);
            str = "SELECT GiaBan FROM DienThoai WHERE idDienThoai =N'" + cboMaHang.Text + "'";
            txtDonGiaBan.Text = Functions.GetFieldValues(str);

            int selectedIndex = cboMaHang.SelectedIndex;
            string value = dgv_giohangdt.Rows[selectedIndex].Cells["SoLuong"].Value.ToString().Trim();
            txtSoLuong.Text = value;

        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
            if (cboMaNhanVien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNhanVien.Focus();
                return;
            }
            if (txbMaKhach.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaKhach.Focus();
                return;
            }

            if (cboMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }

            tao_hoadon_cthd();
            ResetValuesHang();
        }

        public void tao_hoadon_cthd()
        {
            string sql;
            double sl;

            sql = "INSERT INTO HoaDon(idHD,idNV,idKH, Ngay, TriGiaHD, TrangThai) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
               cboMaNhanVien.Text.Trim() +"','"+txbMaKhach.Text.Trim() +"','"+
                Functions.ConvertDateTime(txtNgayBan.Text.Trim()) + "'," + txtTongTien.Text + ", '" + "Đã thanh toán" + "')";
            Functions.RunSQL(sql);

            sql = "INSERT INTO ChiTietHoaDon(idHD,idDienThoai,SoLuong,DonGia,TongTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMaHang.Text + "'," + txtSoLuong.Text + "," + txtDonGiaBan.Text + "," + txtThanhTien.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();

            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SoLuong FROM DienThoai WHERE idDienThoai = N'" + cboMaHang.Text + "'"));
            SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
            sql = "UPDATE DienThoai SET SoLuong =" + SLcon + " WHERE idDienThoai= N'" + cboMaHang.Text + "'";
            Functions.RunSQL(sql);

            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(txtThanhTien.Text);
            Tongmoi = tong + Tongmoi;
            txtTongTien.Text = Tongmoi.ToString();
            sql = "UPDATE HoaDon SET TriGiaHD =" + Tongmoi + " WHERE idHD = N'" + txtMaHDBan.Text.Trim() + "'";
            Functions.RunSQL(sql);

            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }



        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);

            tt = sl * dg;

            txtThanhTien.Text = tt.ToString();
            
        }



        private void ResetValuesHang()
        {
            cboMaHang.Items.Remove(cboMaHang.Text);
            dgv_giohangdt.Rows.RemoveAt(cboMaHang.SelectedIndex+1);
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtTenHang.Text = "";
            txtDonGiaBan.Text = "";
            txtThanhTien.Text = "0";
            if (cboMaHang.Items.Count == 0)
            {
                MessageBox.Show("Hóa Đơn Đã Hoàn Thành", "Thông báo", MessageBoxButtons.OK);
                btn_dongForm.Visible= true;
            }
        }

        private void btn_LuuKH_Click(object sender, EventArgs e)
        {
            if(txtTenKhach.Text == "" || txtDiaChiKH.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = "INSERT INTO KhachHang(idKH,TenKH,soDT_KH,DiaChi) VALUES(N'" + txbMaKhach.Text.Trim() + "',N'" + txtTenKhach.Text + "','" + txtSDT_KH.Text + "','" + txtDiaChiKH.Text + "')";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataBaseConnection.GetSqlConnection(); //Gán kết nối
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("TÊN ĐÃ TỒN TẠI");
                }
            }

        }

        private void btn_dongForm_Click(object sender, EventArgs e)
        {
            FormTaoHoaDon.ActiveForm.Close();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            Search_KhachHang();
        }
        public void Search_KhachHang()
        {
            string value = txb_TimKH.Text.Trim();
            if (value.Length != 10)
            {
                MessageBox.Show("Số điện thoại không chính xác");
            }
            else
            {
                string query = "exec proc_timkiemkhachhang_sdt '" + value +"'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if(dataTable.Rows.Count > 0)
                {
                    DataRow r = dataTable.Rows[0];
                    txbMaKhach.Text = r["idKH"].ToString();
                    txtTenKhach.Text = r["TenKH"].ToString();
                    txtSDT_KH.Text = r["soDT_KH"].ToString();
                    txtDiaChiKH.Text = r["DiaChi"].ToString();
                }
                else
                {
                    string str = "SELECT count(idKH) FROM KhachHang";
                    int k = int.Parse(Functions.GetFieldValues(str)) + 1;
                    string formattedResult = k.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

                    txbMaKhach.Text = "KH_" + formattedResult;
                    txtSDT_KH.Text = value;

                    lb_tb.Visible= true;
                    txtTenKhach.ReadOnly= false;
                    txtSDT_KH.ReadOnly = false;
                    txtDiaChiKH.ReadOnly = false;
                    btn_LuuKH.Visible = true;
                }
            }
        }
    }
}

