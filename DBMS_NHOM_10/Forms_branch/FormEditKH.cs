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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DBMS_NHOM_10.Forms_branch
{
    public partial class FormEditKH : Form
    {
        public string check;
        public FormEditKH()
        {
            InitializeComponent();
        }

        public FormEditKH(DataGridViewRow datarow, string ck)
        {
            InitializeComponent();

            if (ck == "sửa")
            {
                check = "Sửa";

                txb_idKH.Text = datarow.Cells["idKH"].Value.ToString();
                txb_tenKH.Text = datarow.Cells["TenKH"].Value.ToString();
                txb_sdtKH.Text = datarow.Cells["soDT_KH"].Value.ToString();
                txb_diachi.Text = datarow.Cells["DiaChi"].Value.ToString();

            }
            else
            {
                check = "Thêm";

                string str;
                str = "SELECT count(idKH) FROM KhachHang";
                int k = int.Parse(Functions.GetFieldValues(str)) + 1;
                string formattedResult = k.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

                txb_idKH.Text = "KH_" + formattedResult;
                txb_tenKH.Text = "";
                txb_sdtKH.Text = "";
                txb_diachi.Text = "";
            }
        }

        public void them_sua_khachhang()
        {
            SqlConnection connection = DataBaseConnection.GetSqlConnection();
            SqlCommand cmd = new SqlCommand("proc_InsertOrUpdateKhachHang", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idKH", txb_idKH.Text.Trim());
            cmd.Parameters.AddWithValue("@TenKH", txb_tenKH.Text.Trim());
            cmd.Parameters.AddWithValue("@soDT_KH", txb_sdtKH.Text.Trim());
            cmd.Parameters.AddWithValue("@DiaChi", txb_diachi.Text.Trim());

            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
                MessageBox.Show("Lưu thông tin thành công - Hãy REFRESH", "Thông báo", MessageBoxButtons.OK);
                FormEditDienThoai.ActiveForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_Huy_Click_1(object sender, EventArgs e)
        {
            FormEditKH.ActiveForm.Close();
        }

        private void btn_luu_Click_1(object sender, EventArgs e)
        {
            if (txb_tenKH.Text == "" || txb_diachi.Text == "" || txb_sdtKH.Text == "")
            {
                MessageBox.Show("VUi lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }

            else
            {
                them_sua_khachhang();
            }
        }
    }
}
