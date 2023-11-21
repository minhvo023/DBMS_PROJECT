using DBMS_NHOM_10.Forms;
using DBMS_NHOM_10.Forms_branch;
using DBMS_NHOM_10.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_NHOM_10
{
    public partial class FormMainMenu : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;


        public FormMainMenu()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDienThoai(), sender);
        }
        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormHoaDon(), sender);

        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKhachHang(), sender);

        }
        private void btnReporting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormNhanVien(), sender);

        }

        private void btnNotifications_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPhanCa(), sender);

        }


        private void btnSalary_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormTaiChinh(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();

            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "THÔNG TIN";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btn_Mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 140) //Collapse menu
            {
                panelMenu.Width = 80;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 187;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void txb_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txb_password_TextChanged(object sender, EventArgs e)
        {

        }
        
        public void login()
        {
            string username = txb_username.Text;
            string password = txb_password.Text;
            try
            {
                SqlCommand cmd = new SqlCommand("proc_CheckLogin", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlParameter returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                int returnValue = (int)returnParam.Value;

                if (returnValue == 1080)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    panel_thongtin.Visible = false;
                    lblTitle.Text = "THÔNG TIN";
                    panel_login.Visible = false;
                    panel_thongtin.Visible = true;
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btn_login_Click(object sender, EventArgs e)
        {
            if (checklogin() != "")
            {
                kiemtra();
            }
        }
        public void kiemtra()
        {
            
            lblTitle.Text = "THÔNG TIN";
            panel_login.Visible = false;
            panel_thongtin.Visible = true;
            panelLogo.Visible = true;
            btnSalary.Visible = true;
            btnBangPhanCa.Visible = true;
            btnEmployee.Visible = true;
            btnCustomer.Visible = true;
            btnOrders.Visible = true;
            btnProducts.Visible = true;


            txb_idNV.Text = Functions.GetFieldValues("SELECT idNV FROM NhanVien WHERE idNV ='" + txb_username.Text.Trim() + "'");
            txb_TenCV.Text = Functions.GetFieldValues("SELECT TenCV FROM CongViec join NhanVien ON NhanVien.idCV = CongViec.idCV WHERE idNV ='" + txb_username.Text.Trim() + "'");
            txb_nameNV.Text = Functions.GetFieldValues("SELECT Ho_Ten FROM NhanVien WHERE idNV ='" + txb_username.Text.Trim() + "'");
            txb_diachi.Text = Functions.GetFieldValues("SELECT DiaChi FROM NhanVien WHERE idNV ='" + txb_username.Text.Trim() + "'");
            txb_Phai.Text = Functions.GetFieldValues("SELECT GioiTinh FROM NhanVien WHERE idNV ='" + txb_username.Text.Trim() + "'");
            txb_sdtNV.Text = Functions.GetFieldValues("SELECT soDT_NV FROM NhanVien WHERE idNV ='" + txb_username.Text.Trim() + "'");

            string day = Functions.GetFieldValues("SELECT NgaySinh FROM NhanVien WHERE idNV ='" + txb_username.Text.Trim() + "'");


            DateTime ngaySinhFromDatabase = Convert.ToDateTime(day);
            txb_NgaySinh.Text = ngaySinhFromDatabase.ToString("dd/MM/yyyy");
        }
        public string checklogin()
        {
            string err;
            string rs = "";

            try
            {
                DBConnection.connn(txb_username.Text);
                SqlCommand cmd = new SqlCommand("proc_NhanVien_DangNhap", DBConnection.open());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", txb_username.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txb_password.Text.Trim());

                SqlParameter returnParam = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.ReturnValue;

                // Execute the stored procedure
                if(DBConnection.conn.State != ConnectionState.Closed)
                {
                    cmd.ExecuteNonQuery();

                    // Retrieve the return value
                    int returnValue = (int)returnParam.Value;
                    if (returnValue == 0)
                    {
                        MessageBox.Show("'Quản Lý' Đăng nhập thành công!");
                    }
                    else if (returnValue == 1)
                    {
                        MessageBox.Show("'Nhân Viên' Đăng nhập thành công");
                    }
                    rs = "login";
                }
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
            return rs;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            txb_username.Text = String.Empty;
            txb_password.Text = String.Empty;

            lblTitle.Text = "Đăng Nhập";
            panel_login.Visible = true;
            panel_thongtin.Visible = false;
            panelLogo.Visible = false;
            btnSalary.Visible = false;
            btnBangPhanCa.Visible = false;
            btnEmployee.Visible = false;
            btnCustomer.Visible = false;
            btnOrders.Visible = false;
            btnProducts.Visible = false;
        }

        private void btn_DoiMK_Click(object sender, EventArgs e)
        {
            FormDoiMK formDoiMK = new FormDoiMK(txb_idNV.Text.Trim());
            formDoiMK.ShowDialog();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            btn_Luu.Visible = true;
            txb_nameNV.ReadOnly = false;
            txb_diachi.ReadOnly = false;
            txb_sdtNV.ReadOnly = false;
            txb_NgaySinh.ReadOnly = false;
            txb_Phai.ReadOnly = false;
        }

        public void NhanVien_cstt()
        {
            string err;
            try
            {
                SqlCommand cmd = new SqlCommand("proc_NhanVien_ChinhSuaThongTinCaNha", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", txb_idNV.Text.Trim());
                cmd.Parameters.AddWithValue("@Ho_Ten", txb_nameNV.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txb_diachi.Text.Trim());
                cmd.Parameters.AddWithValue("@soDT_NV", txb_sdtNV.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", txb_NgaySinh.Text.Trim());
                cmd.Parameters.AddWithValue("@GioiTinh", txb_Phai.Text.Trim());

                cmd.ExecuteNonQuery();

                err = "Thay đổi thành công!";
            }
            catch (SqlException ex)
            {
                err = "Thay đổi thất bại!  " + ex.Message ;


            }
            finally
            {
                DBConnection.close();

            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            NhanVien_cstt();
            btn_Luu.Visible = false;
            txb_nameNV.ReadOnly = true;
            txb_diachi.ReadOnly = true;
            txb_sdtNV.ReadOnly = true;
            txb_NgaySinh.ReadOnly = true;
            txb_Phai.ReadOnly = true;
            kiemtra();
        }

        private void btn_DiemDanh_Click(object sender, EventArgs e)
        {
            NhanVien_DiemDanh();
        }
        public void NhanVien_DiemDanh()
        {
            string err;
            try
            {
                SqlCommand cmd = new SqlCommand("proc_NhanVien_DiemDanh", DBConnection.open());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNV", txb_idNV.Text.Trim());

                cmd.ExecuteNonQuery();

                err = "Điểm danh thành công!";
                btn_DiemDanh.Visible= false;
            }
            catch (SqlException ex)
            {
                err = "Điểm danh thất bại!  " + ex.Message;

            }
            finally
            {
                DBConnection.close();

            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void NhanVien_CaLamTuongLai()
        {
            string err;
            try
            {
                string query = "exec proc_NhanVien_CaLam " + txb_idNV.Text.Trim();
                SqlDataAdapter adapter = new SqlDataAdapter(query, DBConnection.open());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView_CaNV.DataSource = dt;
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

        private void btn_CaLam_Click(object sender, EventArgs e)
        {
            NhanVien_CaLamTuongLai();
        }
    }
}
