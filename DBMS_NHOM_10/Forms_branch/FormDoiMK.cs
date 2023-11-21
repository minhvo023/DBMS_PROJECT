using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_NHOM_10.Forms_branch
{
    public partial class FormDoiMK : Form
    {
        public FormDoiMK(string value)
        {
            InitializeComponent();
            idNV = value;

        }
        public string idNV;

        public void NhanVien_DoiMK()
        {
            string err;
            try
            {
                SqlCommand cmd = new SqlCommand("proc_NhanVien_DoiMK", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", idNV);
                cmd.Parameters.AddWithValue("@mkCu", txb_mkCu.Text.Trim());
                cmd.Parameters.AddWithValue("@mkMoi", txb_mkMoi.Text.Trim());

                cmd.ExecuteNonQuery();
                err = "Đổi mật khẩu thành công";
            }
            catch (SqlException ex)
            {
                err = ex.Message;

            }
            finally
            {
                DBConnection.close();
            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            NhanVien_DoiMK();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
