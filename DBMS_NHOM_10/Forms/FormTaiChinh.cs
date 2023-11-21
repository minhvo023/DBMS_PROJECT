using DBMS_NHOM_10.View;
using System;
using System.Collections;
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
    public partial class FormTaiChinh : Form
    {
        public FormTaiChinh()
        {
            InitializeComponent();
            Functions.FillCombo("SELECT idNV, Ho_Ten FROM NhanVien WHERE idNV <> 'NV_00'", cbb_idNV, "idNV", "Ho_Ten");
            cbb_idNV.SelectedIndex = -1;

        }

        public string NhanVien_TinhLuong_HD_DN(object a, string b, string c, string d)
        {            
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.func_TinhLuong_HD_DN", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", a);
                cmd.Parameters.AddWithValue("@thang", b);
                cmd.Parameters.AddWithValue("@thangHD", c);
                cmd.Parameters.AddWithValue("@thangDN", d);

                SqlParameter returnParameter = cmd.Parameters.Add("@result", SqlDbType.Decimal);
                returnParameter.Direction = ParameterDirection.ReturnValue;


                cmd.ExecuteNonQuery(); // Thực hiện hàm
                decimal result = (decimal)returnParameter.Value;
                return result.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "oo";
            }
            finally
            {
                DBConnection.close();
            }
        }

        public string SoLuong(object a, string b, string c, string d)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.func_TongSo", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", a);
                cmd.Parameters.AddWithValue("@thangNV", b);
                cmd.Parameters.AddWithValue("@thangHD", c);
                cmd.Parameters.AddWithValue("@thangDN", d);

                SqlParameter returnParameter = cmd.Parameters.Add("@SoLuong", SqlDbType.Decimal);
                returnParameter.Direction = ParameterDirection.ReturnValue;


                cmd.ExecuteNonQuery(); // Thực hiện hàm

                int SoLuong = (int)returnParameter.Value;
                return SoLuong.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return "ERROR";
            }
            finally
            {
                DBConnection.close();
            }
        }

        public DataTable HienThiThongTin(object a, string b, string c, string d)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("proc_HienThiThongTin", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", a);
                cmd.Parameters.AddWithValue("@thang", b);
                cmd.Parameters.AddWithValue("@thangHD", c);
                cmd.Parameters.AddWithValue("@thangDN", d);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return null;
            }
            finally
            {
                DBConnection.close();
            }
        }

        private void btn_TinhLuong_Click(object sender, EventArgs e)
        {
            btn_KQ_NV.Text = "Nhân Viên [ " + cbb_idNV.Text.ToString().Trim() + " ]\nLương Tháng [ " + cbb_ThangNV.Text.ToString().Trim() + " ] là: " + NhanVien_TinhLuong_HD_DN(cbb_idNV.SelectedValue, cbb_ThangNV.Text.ToString().Trim(), "", "") + "\nTổng số ca là: " + SoLuong(cbb_idNV.SelectedValue, cbb_ThangNV.Text.ToString().Trim(), "", "");
            dataGridView_show.DataSource = HienThiThongTin(cbb_idNV.SelectedValue, cbb_ThangNV.Text.Trim(), "", "");
        }

        private void btn_HD_Click(object sender, EventArgs e)
        {
            btn_KQ_HD.Text = "Tổng giá trị Hóa Đơn tháng [ " + cbb_ThangHD.Text.Trim() + " ] là: " + NhanVien_TinhLuong_HD_DN("", "", cbb_ThangHD.Text.Trim(), "") + "\nTổng số Hóa Đơn là: " + SoLuong("", "", cbb_ThangHD.Text.Trim(), "");
            dataGridView_show.DataSource = HienThiThongTin("", "", cbb_ThangHD.Text.Trim(), "");
        }

        private void btn_DN_Click(object sender, EventArgs e)
        {
            btn_KQ_DN.Text = "Tổng giá trị Đơn Nhập tháng [ " + cbb_ThangDN.Text.Trim() + " ] là: " + NhanVien_TinhLuong_HD_DN("", "", "", cbb_ThangDN.Text.Trim()) + "\nTổng số Đơn Nhập là: " + SoLuong("", "", "",cbb_ThangDN.Text.Trim());
            dataGridView_show.DataSource = HienThiThongTin("", "", "", cbb_ThangDN.Text.Trim());
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            cbb_idNV.Text = string.Empty;
            cbb_ThangDN.Text = string.Empty;
            cbb_ThangHD.Text = string.Empty;
            cbb_ThangNV.Text = string.Empty;
            dataGridView_show.DataSource = null;

            btn_KQ_NV.Text = string.Empty;
            btn_KQ_HD.Text = string.Empty;
            btn_KQ_DN.Text= string.Empty;
        }
    }
}
