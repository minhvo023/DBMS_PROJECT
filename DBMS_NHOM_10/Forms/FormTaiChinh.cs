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

        public string NhanVien_TinhLuong_HD_DN(string a, string b, string c, string d)
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
                if(returnParameter.Value == DBNull.Value)
                {
                    decimal result = 0;
                    return result.ToString();

                }
                else
                {
                    decimal result = (decimal)returnParameter.Value;
                    return result.ToString();
                }
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

        public string SoLuong(string a, string b, string c, string d)
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

        public DataTable HienThiThongTin(string a, string b, string c, string d)
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
            btn_KQ_NV.Text = "Nhân Viên "+ cbb_idNV.Text.Trim()+ "\nLương Tháng " + cbb_ThangNV.Text.Trim() +" là: " + NhanVien_TinhLuong_HD_DN(cbb_idNV.SelectedValue.ToString().Trim(), cbb_ThangNV.Text.Trim(), "", "") + "\nTổng số ca của tháng là: " + SoLuong(cbb_idNV.SelectedValue.ToString().Trim(), cbb_ThangNV.Text.Trim(),"", "");
            dataGridView_show.DataSource = HienThiThongTin(cbb_idNV.SelectedValue.ToString().Trim(), cbb_ThangNV.Text.Trim(), "", "");
        }

        private void btn_HD_Click(object sender, EventArgs e)
        {
            btn_KQ_HD.Text = "Tổng giá trị Hóa Đơn tháng " + cbb_ThangHD.Text.Trim() + " là: " + NhanVien_TinhLuong_HD_DN("", "", cbb_ThangHD.Text.Trim(), "") + "\nTổng số Hóa Đơn của tháng là: " + SoLuong("", "", cbb_ThangHD.Text.Trim(), "");
            dataGridView_show.DataSource = HienThiThongTin("", "", cbb_ThangHD.Text.Trim(), "");
        }

        private void btn_DN_Click(object sender, EventArgs e)
        {
            btn_KQ_DN.Text = "Tổng giá trị Đơn Nhập tháng " + cbb_ThangDN.Text.Trim() + " là: " + NhanVien_TinhLuong_HD_DN("", "", "", cbb_ThangDN.Text.Trim()) + "\nTổng số Hóa Đơn của tháng là: " + SoLuong("", "", "",cbb_ThangDN.Text.Trim());
            dataGridView_show.DataSource = HienThiThongTin("", "", "", cbb_ThangDN.Text.Trim());
        }
    }
}
