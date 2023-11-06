using DBMS_NHOM_10.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DBMS_NHOM_10.Forms_branch
{
    public partial class FormEditKhachHang : Form
    {
        public FormEditKhachHang()
        {
            InitializeComponent();
        }

        public FormEditKhachHang(DataGridViewRow datarow, string ck)
        {
            InitializeComponent();

            if (ck == "sửa")
            {
                txb_idKH.Text = datarow.Cells["idKH"].Value.ToString();
                txb_tenKH.Text = datarow.Cells["TenKH"].Value.ToString();
                txb_sdtKH.Text = datarow.Cells["soDT_KH"].Value.ToString();
                txb_diachi.Text = datarow.Cells["DiaChi"].Value.ToString();

            }
            else
            {

                string str = "SELECT MAX(idKH) FROM KhachHang";
                string k = Functions.GetFieldValues(str);
                Match match = Regex.Match(k, @"\d+");
                int kq = int.Parse(match.Value.ToString()) + 1;
                string formattedResult = kq.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

                txb_idKH.Text = "KH_" + formattedResult;
                txb_tenKH.Text = "";
                txb_sdtKH.Text = "";
                txb_diachi.Text = "";
            }
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
                cmd.Parameters.AddWithValue("@TenKH", txb_tenKH.Text.Trim());
                cmd.Parameters.AddWithValue("@soDT_KH", txb_sdtKH.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txb_diachi.Text.Trim());
                cmd.ExecuteNonQuery();
                err = "Thao tác Thành Công!";
                FormEditDienThoai.ActiveForm.Close();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Huy_Click_1(object sender, EventArgs e)
        {
            FormEditKhachHang.ActiveForm.Close();
        }

        private void btn_luu_Click_1(object sender, EventArgs e)
        {
            KhachHang_ThemHoacSua();
        }
    }
}
