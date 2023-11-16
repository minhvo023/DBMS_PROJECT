using DBMS_NHOM_10.Forms;
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
        DataGridView datagv;
        public FormEditKhachHang()
        {
            InitializeComponent();
        }

        public FormEditKhachHang(DataGridView dgv ,DataGridViewRow datarow, string ck)
        {
            InitializeComponent();

            datagv= dgv;

            if (ck == "sửa")
            {
                lb_header.Text = "Chỉnh Sửa Thông tin";
                txb_idKH.Text = datarow.Cells["idKH"].Value.ToString();
                txb_tenKH.Text = datarow.Cells["TenKH"].Value.ToString();
                txb_sdtKH.Text = datarow.Cells["soDT_KH"].Value.ToString();
                txb_diachi.Text = datarow.Cells["DiaChi"].Value.ToString();

            }
            else
            {
                lb_header.Text = "Thêm Mới Khách Hàng";

                string k = KhachHang_idMAX();
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
                SqlConnection connection = DBConnection.open();
                SqlCommand cmd = new SqlCommand("proc_KhachHang_InsertOrUpdate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idKH", txb_idKH.Text.Trim());
                cmd.Parameters.AddWithValue("@TenKH", txb_tenKH.Text.Trim());
                cmd.Parameters.AddWithValue("@soDT_KH", txb_sdtKH.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txb_diachi.Text.Trim());
                cmd.ExecuteNonQuery();
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

        public string KhachHang_idMAX()
        {
            string k = "";
            string str = "SELECT dbo.func_KhachHang_idMAX()";
            SqlCommand cmd = new SqlCommand(str, DBConnection.open());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                k = reader.GetValue(0).ToString();
            reader.Close();
            return k;
        }


        private void btn_Huy_Click_1(object sender, EventArgs e)
        {
            FormKhachHang.load_refresh(datagv);
            FormEditKhachHang.ActiveForm.Close();
        }

        private void btn_luu_Click_1(object sender, EventArgs e)
        {
            KhachHang_ThemHoacSua();
            lb_thongbao.Visible = true;
        }
    }
}
