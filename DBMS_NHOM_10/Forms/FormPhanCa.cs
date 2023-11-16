using DBMS_NHOM_10.View;
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
    public partial class FormPhanCa : Form
    {
        public FormPhanCa()
        {
            InitializeComponent();
            Functions.FillCombo("SELECT idNV, Ho_Ten FROM NhanVien WHERE idNV <> 'NV_00'", cbb_idNVCa01, "idNV", "idNV");
            cbb_idNVCa01.SelectedIndex = -1;
            Functions.FillCombo("SELECT idNV, Ho_Ten FROM NhanVien WHERE idNV <> 'NV_00'", cbb_idNVCa02, "idNV", "idNV");
            cbb_idNVCa02.SelectedIndex = -1;
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;

            int day = selectedDate.Day;
            int month = selectedDate.Month;
            int year = selectedDate.Year;


            txb_NgayCa01.Text = day.ToString();
            txb_ThangCa01.Text = month.ToString();
            txb_NamCa01.Text = year.ToString();

            txb_NgayCa02.Text = day.ToString();
            txb_ThangCa02.Text = month.ToString();
            txb_NamCa02.Text = year.ToString();
        }

        public void PhanCa_TK_Ngay_Ca(int value)
        {
            try
            {
                if(value == 1)
                {
                    string query = "SELECT * FROM func_PhanCa_TK_Date_Ca('" + txb_NgayCa01.Text.Trim() + "','" + txb_ThangCa01.Text.Trim() + "','" + txb_NamCa01.Text.Trim() + "','" + txb_ca01.Text.Trim() + "')";
                    SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                    DataTable table = new DataTable();
                    dap.Fill(table);
                    dataGridView_CA_01.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    string query = "SELECT * FROM func_PhanCa_TK_Date_Ca('" + txb_NgayCa01.Text.Trim() + "','" + txb_ThangCa01.Text.Trim() + "','" + txb_NamCa01.Text.Trim() + "','" + txb_ca02.Text.Trim() + "')";
                    SqlDataAdapter dap = new SqlDataAdapter(query, DBConnection.open());
                    DataTable table = new DataTable();
                    dap.Fill(table);
                    dataGridView_CA_02.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                DBConnection.close();
            }
        }

        public void PhanCa_ThemCa(int value)
        {
            try
            {
                string NgayLam = txb_ThangCa01.Text.Trim() + "/" + txb_NgayCa01.Text.Trim() + "/" +  txb_NamCa01.Text.Trim();
                if (value == 1)
                {
                    SqlConnection connection = DBConnection.open();
                    SqlCommand cmd = new SqlCommand("proc_PhanCa_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NgayLam", NgayLam);
                    cmd.Parameters.AddWithValue("@idCa", txb_ca01.Text.Trim());
                    cmd.Parameters.AddWithValue("@idNV", cbb_idNVCa01.Text.Trim());
                    cmd.ExecuteNonQuery();
                    PhanCa_TK_Ngay_Ca(1);

                }
                else
                {
                    SqlConnection connection = DBConnection.open();
                    SqlCommand cmd = new SqlCommand("proc_PhanCa_Insert", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NgayLam", NgayLam);
                    cmd.Parameters.AddWithValue("@idCa", txb_ca02.Text.Trim());
                    cmd.Parameters.AddWithValue("@idNV", cbb_idNVCa02.Text.Trim());
                    cmd.ExecuteNonQuery();
                    PhanCa_TK_Ngay_Ca(2);

                }

                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                DBConnection.close();
            }
        }
        private void btn_timkiemCa01_Click(object sender, EventArgs e)
        {
            PhanCa_TK_Ngay_Ca(1);
        }

        private void btn_resetTK_Click(object sender, EventArgs e)
        {
            cbb_idNVCa01.Text = "";
            txb_NamCa01.Text = "";
            txb_ThangCa01.Text = "";
            txb_NgayCa01.Text = "";
            dataGridView_CA_01.DataSource=null;
        }

        private void btn__timkiemCa02_Click(object sender, EventArgs e)
        {
            PhanCa_TK_Ngay_Ca(2);
        }

        private void btn_resetTK1_Click(object sender, EventArgs e)
        {
            cbb_idNVCa02.Text = "";
            txb_NamCa02.Text = "";
            txb_ThangCa02.Text = "";
            txb_NgayCa02.Text = "";
            dataGridView_CA_02.DataSource = null;
        }

        private void btn_themCa01_Click(object sender, EventArgs e)
        {
            PhanCa_ThemCa(1);
        }

        private void btn_themCa02_Click(object sender, EventArgs e)
        {
            PhanCa_ThemCa(2);

        }
    }
}
