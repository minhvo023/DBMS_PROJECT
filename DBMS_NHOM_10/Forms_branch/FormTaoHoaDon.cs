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
using System.Text.RegularExpressions;
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

            txb_TriGiaHD.Text = "0";

            Functions.FillCombo("SELECT idNV, Ho_Ten FROM NhanVien", cbo_idNV, "idNV", "idNV");
            cbo_idNV.SelectedIndex = -1;

            foreach (DataGridViewRow row in dgv_giohangdt.Rows)
            {
                string value = row.Cells[0].Value.ToString().Trim();
                cbo_idDT.Items.Add(value);   
            }
            cbo_idDT.SelectedIndex = -1;

            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.idDienThoai, b.TenDienThoai, a.SoLuong, b.GiaBan,a.TongTien " +
                "FROM ChiTietHoaDon AS a, DienThoai AS b WHERE a.idHD = N'" + txb_idHD.Text.Trim() + "' AND a.idDienThoai=b.idDienThoai";
            tblCTHDB = Functions.GetDataToTable(sql);

            dgvHDBanHang.DataSource = tblCTHDB;
            dgvHDBanHang.Columns[0].HeaderText = "ID";
            dgvHDBanHang.Columns[1].HeaderText = "Tên";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[4].HeaderText = "Thành tiền";
        }
        
        private void openControl()
        {
            txb_Ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cbo_idDT.Enabled= true;
            cbo_idNV.Enabled= true;
            btn_Tim_sdtKH.Enabled= true;
            txb_Tim_KH.ReadOnly=false;
            cbo_idDT.Text = "";
            txb_SoLuong.Text = "";
            txb_TenDT.Text = "";
            txb_DonGia.Text = "";
            txb_ThanhTien.Text = "0";
        }


        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_idNV.Text == "")
                txb_TenNV.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select Ho_Ten from NhanVien where idNV = N'" + cbo_idNV.SelectedValue + "'";
            txb_TenNV.Text = Functions.GetFieldValues(str);
        }



        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_idDT.Text == "")
            {
                txb_TenDT.Text = "";
                txb_DonGia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenDienThoai FROM DienThoai WHERE idDienThoai =N'" + cbo_idDT.Text + "'";
            txb_TenDT.Text = Functions.GetFieldValues(str);
            str = "SELECT GiaBan FROM DienThoai WHERE idDienThoai =N'" + cbo_idDT.Text + "'";
            txb_DonGia.Text = Functions.GetFieldValues(str);

            int selectedIndex = cbo_idDT.SelectedIndex;
            string value = dgv_giohangdt.Rows[selectedIndex].Cells["SoLuong"].Value.ToString().Trim();
            txb_SoLuong.Text = value;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            openControl();

            string str = "SELECT MAX(idHD) FROM HoaDon";
            string k = Functions.GetFieldValues(str);
            Match match = Regex.Match(k, @"\d+");
            int kq = int.Parse(match.Value.ToString()) + 1;
            string formattedResult = kq.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

            txb_idHD.Text = "HD_" + formattedResult;
            LoadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            tao_hoadon_cthd();
        }

        public void tao_hoadon_cthd()
        {

            string err = "";
            
            try
            {
                tong = Convert.ToDouble(txb_ThanhTien.Text);
                Tongmoi = tong + Tongmoi;
                txb_TriGiaHD.Text = Tongmoi.ToString();

                SqlConnection connection = DataBaseConnection.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("proc_HoaDon_Insert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHD", txb_idHD.Text.Trim());
                cmd.Parameters.AddWithValue("@idNV", cbo_idNV.Text.Trim());
                cmd.Parameters.AddWithValue("@idKH", txb_idKH.Text.Trim());
                cmd.Parameters.AddWithValue("@idDienThoai", cbo_idDT.Text.Trim());
                cmd.Parameters.AddWithValue("@Ngay", txb_Ngay.Text.Trim());
                cmd.Parameters.AddWithValue("@TriGiaHD", txb_TriGiaHD.Text.Trim());
                cmd.Parameters.AddWithValue("@SoLuong", txb_SoLuong.Text.Trim());
                cmd.Parameters.AddWithValue("@DonGia", txb_DonGia.Text.Trim());
                cmd.Parameters.AddWithValue("@TongTien", txb_ThanhTien.Text.Trim());

                cmd.ExecuteNonQuery();
                lblBangChu.Text = "Bằng chữ: " + Functions.NumberToWords((int)Tongmoi);

                err = "Lưu thông tin thành công";
                ResetValuesHang();

            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txb_SoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txb_SoLuong.Text);
            if (txb_DonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txb_DonGia.Text);

            tt = sl * dg;

            txb_ThanhTien.Text = tt.ToString();
            
        }



        private void ResetValuesHang()
        {
            cbo_idDT.Items.Remove(cbo_idDT.Text);
            dgv_giohangdt.Rows.RemoveAt(cbo_idDT.SelectedIndex+1);
            cbo_idDT.Text = "";
            txb_SoLuong.Text = "";
            txb_TenDT.Text = "";
            txb_DonGia.Text = "";
            txb_ThanhTien.Text = "0";
            if (cbo_idDT.Items.Count == 0)
            {
                MessageBox.Show("Hóa Đơn Đã Hoàn Thành", "Thông báo", MessageBoxButtons.OK);
                btn_dongForm.Visible= true;
            }
        }

        private void btn_LuuKH_Click(object sender, EventArgs e)
        {
            KhachHang_ThemHoacSua();

        }

        public void KhachHang_ThemHoacSua()
        {

            string err;
            try
            {
                SqlConnection connection = DataBaseConnection.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("proc_KhachHang_InsertOrUpdate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idKH", txb_idKH.Text.Trim());
                cmd.Parameters.AddWithValue("@TenKH", txb_TenKH.Text.Trim());
                cmd.Parameters.AddWithValue("@soDT_KH", txb_sdtKH.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txb_DiaChiKH.Text.Trim());
                cmd.ExecuteNonQuery();
                err = "Thao tác Thành Công!";
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            string value = txb_Tim_KH.Text.Trim();
            try
            {
                string query = "exec proc_KhachHang_TK_sdt '" + value + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                DataRow r = dataTable.Rows[0];
                txb_idKH.Text = r["idKH"].ToString();
                txb_TenKH.Text = r["TenKH"].ToString();
                txb_sdtKH.Text = r["soDT_KH"].ToString();
                txb_DiaChiKH.Text = r["DiaChi"].ToString();


            }
            catch(Exception ex)
            {
                if(ex.Message == "Không tìm thấy! - Hãy tạo thông tin!")
                {
                    string str = "SELECT MAX(idKH) FROM KhachHang";
                    string k = Functions.GetFieldValues(str);
                    Match match = Regex.Match(k, @"\d+");
                    int kq = int.Parse(match.Value.ToString()) + 1;
                    string formattedResult = kq.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

                    txb_idKH.Text = "KH_" + formattedResult;
                    txb_sdtKH.Text = value;

                    txb_TenKH.Text = "";
                    txb_DiaChiKH.Text = "";
                    txb_TenKH.ReadOnly = false;
                    txb_DiaChiKH.ReadOnly = false;
                    btn_LuuKH.Visible = true;
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}

