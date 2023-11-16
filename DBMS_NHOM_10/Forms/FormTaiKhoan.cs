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

namespace DBMS_NHOM_10.Forms
{
    public partial class FormTaiKhoan : Form
    {
        public FormTaiKhoan()
        {
            InitializeComponent();
        }

        public void TaiKhoan_DiemDanh()
        {

            try
            {

                SqlCommand cmd = new SqlCommand("proc_PhanCa_DiemDanh", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                DBConnection.close();
            }
        }

        private void btn_DiemDanh_Click(object sender, EventArgs e)
        {
            TaiKhoan_DiemDanh();
            btn_DiemDanh.Enabled = false;

        }
    }
}
