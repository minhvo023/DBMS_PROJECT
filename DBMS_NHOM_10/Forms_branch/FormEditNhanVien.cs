using DBMS_NHOM_10.Forms;
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
        DataGridView datagv;
        public FormEditNhanVien()
        {
            InitializeComponent();
        }
        public FormEditNhanVien(DataGridView dgv,string id, string ck)
        {
            InitializeComponent();

            datagv= dgv;

            dateTimePicker_ngsinhNV.Format = DateTimePickerFormat.Custom;
            dateTimePicker_ngsinhNV.CustomFormat = "dd/MM/yyyy";

            Functions.FillCombo("SELECT idCV, TenCV FROM CongViec", cbb_idCV, "idCV", "TenCV");
            cbb_idCV.SelectedIndex = -1;

            string sql = "SELECT * FROM NhanVien WHERE idNV = '" + id + "'";
            SqlDataAdapter dap = new SqlDataAdapter(sql, DBConnection.open());
            DataTable table = new DataTable();
            dap.Fill(table);
            DBConnection.close();

            if (ck == "sửa")
            {
                lb_header.Text = "Chỉnh Sửa Thông Tin";

                string ngaySinhStr = table.Rows[0]["NgaySinh"].ToString();
                DateTime ngaySinh;
                DateTime.TryParse(ngaySinhStr, out ngaySinh);
                dateTimePicker_ngsinhNV.Value = ngaySinh;



                txb_idNV.Text = id;
                txb_tenNV.Text = table.Rows[0]["Ho_Ten"].ToString();
                txb_sdtNV.Text = table.Rows[0]["soDT_NV"].ToString();
                txb_diachi.Text = table.Rows[0]["DiaChi"].ToString();
                cbb_Phai.Text = table.Rows[0]["GioiTinh"].ToString();
                cbb_idCV.SelectedValue = table.Rows[0]["idCV"].ToString();


            }
            else
            {
                lb_header.Text = "Thêm Mới Nhân Viên";

                string k = NhanVien_idMAX();

                Match match = Regex.Match(k, @"\d+");
                int kq = int.Parse(match.Value.ToString()) + 1;
                string formattedResult = kq.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

                txb_idNV.Text = "NV_" + formattedResult;
                txb_tenNV.Text = "";
                txb_sdtNV.Text = "";
                txb_diachi.Text = "";
                cbb_Phai.Text = "";
                cbb_idCV.Text = "";

            }
        }

        public string NhanVien_idMAX()
        {
            string k = "";
            try
            {
                string str = "SELECT dbo.func_NhanVien_idMAX()";
                SqlCommand cmd = new SqlCommand(str, DBConnection.open());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    k = reader.GetValue(0).ToString();
                reader.Close();
                return k;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return k;
            }
            finally
            {
                DBConnection.close();
            }
        }

        public void NhanVien_ThemHoacSua()
        {
            string err;
            try 
            {
                SqlCommand cmd = new SqlCommand("proc_NhanVien_InsertOrUpdate", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", txb_idNV.Text.Trim());
                cmd.Parameters.AddWithValue("@idCV", cbb_idCV.SelectedValue);
                cmd.Parameters.AddWithValue("@Ho_Ten", txb_tenNV.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txb_diachi.Text.Trim());
                cmd.Parameters.AddWithValue("@soDT_NV", txb_sdtNV.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dateTimePicker_ngsinhNV.Value.ToString("MM/dd/yyyy").Trim());
                cmd.Parameters.AddWithValue("@GioiTinh", cbb_Phai.Text.Trim());

                cmd.ExecuteNonQuery();

                lb_thongbao.Visible = true;


            }
            catch (SqlException ex)
            {
                err = ex.Message;

                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                DBConnection.close();
            }

        }


        private void btn_Huy_Click(object sender, EventArgs e)
        {
            FormNhanVien.load_refresh(datagv);
            FormEditNhanVien.ActiveForm.Close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            NhanVien_ThemHoacSua();
        }
    }
}
