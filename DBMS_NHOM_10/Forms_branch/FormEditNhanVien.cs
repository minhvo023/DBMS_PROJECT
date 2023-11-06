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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DBMS_NHOM_10.Forms_branch
{
    public partial class FormEditNhanVien : Form
    {

        public FormEditNhanVien()
        {
            InitializeComponent();
        }
        public FormEditNhanVien(string id, string ck)
        {
            InitializeComponent();
            dateTimePicker_ngsinhNV.Format = DateTimePickerFormat.Custom;
            dateTimePicker_ngsinhNV.CustomFormat = "dd/MM/yyyy";

            Functions.FillCombo("SELECT idCV, TenCV FROM CongViec", cbb_idCV, "idCV", "TenCV");
            cbb_idCV.SelectedIndex = -1;

            string sql = "SELECT * FROM NhanVien WHERE idNV = '" + id + "'";
            SqlDataAdapter dap = new SqlDataAdapter(sql, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            if (ck == "sửa")
            {
                

                string ngaySinhStr = table.Rows[0]["NgaySinh"].ToString();
                DateTime ngaySinh;
                DateTime.TryParse(ngaySinhStr, out ngaySinh);
                dateTimePicker_ngsinhNV.Value = ngaySinh;



                txb_idNV.Text = id;
                txb_tenNV.Text = table.Rows[0]["Ho_Ten"].ToString();
                txb_sdtNV.Text = table.Rows[0]["soDT_NV"].ToString();
                txb_diachi.Text = table.Rows[0]["DiaChi"].ToString();
                txb_Phai.Text = table.Rows[0]["GioiTinh"].ToString();
                cbb_idCV.SelectedValue = table.Rows[0]["idCV"].ToString();


            }
            else
            {

                string str = "SELECT MAX(idNV) FROM NhanVien";
                string k = Functions.GetFieldValues(str);
                Match match = Regex.Match(k, @"\d+");
                int kq = int.Parse(match.Value.ToString()) + 1;
                string formattedResult = kq.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

                txb_idNV.Text = "KH_" + formattedResult;
                txb_tenNV.Text = "";
                txb_sdtNV.Text = "";
                txb_diachi.Text = "";
                txb_Phai.Text = "";
                cbb_idCV.Text = "";

            }
        }

        public void NhanVien_ThemHoacSua()
        {

            string err;
            try
            {
                SqlConnection connection = DataBaseConnection.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("proc_NhanVien_InsertOrUpdate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", txb_idNV.Text.Trim());
                cmd.Parameters.AddWithValue("@idCV", cbb_idCV.SelectedValue);
                cmd.Parameters.AddWithValue("@Ho_Ten", txb_tenNV.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txb_diachi.Text.Trim());
                cmd.Parameters.AddWithValue("@soDT_NV", txb_sdtNV.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker_ngsinhNV.Value.ToString("MM/dd/yyyy").Trim());
                cmd.Parameters.AddWithValue("@GioiTinh", txb_Phai.Text.Trim());

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

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormEditNhanVien.ActiveForm.Close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            NhanVien_ThemHoacSua();
        }
    }
}
