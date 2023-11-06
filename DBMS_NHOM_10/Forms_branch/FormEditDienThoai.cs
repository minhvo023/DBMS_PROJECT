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

namespace DBMS_NHOM_10.Forms_branch
{
    public partial class FormEditDienThoai : Form
    {
        public string check;
        public FormEditDienThoai()
        {
            InitializeComponent();
        }
        public FormEditDienThoai(DataGridViewRow datarow, string ck)
        {
            InitializeComponent();

            if(ck == "sửa")
            {
                check = "Sửa";
                Functions.FillCombo("SELECT TenHangDT FROM HangDienThoai", cbbHang, "TenHangDT", "TenHangDT");
                cbbHang.SelectedIndex = -1;

                Functions.FillCombo("SELECT DISTINCT DungLuong FROM DienThoai", cbbDungLuong, "DungLuong", "DungLuong");
                cbbHang.SelectedIndex = -1;

                txb_id.Text = datarow.Cells["idDienThoai"].Value.ToString();
                txb_ten.Text = datarow.Cells["TenDienThoai"].Value.ToString();
                cbbHang.Text = datarow.Cells["TenHangDT"].Value.ToString();
                txb_mausac.Text = datarow.Cells["MauSac"].Value.ToString();
                cbbDungLuong.Text = datarow.Cells["DungLuong"].Value.ToString();
                txb_gia.Text = datarow.Cells["GiaBan"].Value.ToString();
                txb_soluong.Text = datarow.Cells["SoLuong"].Value.ToString();
                txb_tinhtrang.Text = datarow.Cells["TrangThai"].Value.ToString();
                if (datarow.Cells[8].Value is byte[] imageData) // Kiểm tra xem giá trị là dãy byte (hình ảnh)
                {
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(stream);
                        pictureBox_DT.Image = image; // Gán hình ảnh cho PictureBox
                    }
                }
            }
            else
            {
                check = "Thêm";

                string str = "SELECT MAX(idDienThoai) FROM DienThoai";
                string k = Functions.GetFieldValues(str);
                Match match = Regex.Match(k, @"\d+");
                int kq = int.Parse(match.Value.ToString()) + 1;
                string formattedResult = kq.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

                Functions.FillCombo("SELECT TenHangDT FROM HangDienThoai", cbbHang, "TenHangDT", "TenHangDT");
                cbbHang.SelectedIndex = -1;
                Functions.FillCombo("SELECT DISTINCT DungLuong FROM DienThoai", cbbDungLuong, "DungLuong", "DungLuong");
                cbbDungLuong.SelectedIndex = -1;

                txb_id.Text = "DT_" + formattedResult;
                txb_ten.Text = ""; ;
                cbbHang.Text = "";
                txb_mausac.Text = "";
                cbbDungLuong.Text = "";
                txb_gia.Text = "";
                txb_soluong.Text = "";
                txb_tinhtrang.Text = "";
                pictureBox_DT.Image = null;
            }
        }

        
        private void btn_luu_Click(object sender, EventArgs e)
        {

            byte[] ImageToByteArray(Image image)
            {
                MemoryStream stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
            byte[] b = null;
            if (pictureBox_DT.Image != null)
            {
                b = ImageToByteArray(pictureBox_DT.Image);
            }

            them_sua_dienthoai(b);
            
        }

        public void them_sua_dienthoai(Byte[] b)
        {
            
            string err = "";
            try
            {

                SqlConnection connection = DataBaseConnection.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("proc_DienThoai_InsertOrUpdate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDienThoai", txb_id.Text.Trim());
                cmd.Parameters.AddWithValue("@TenDienThoai", txb_ten.Text.Trim());
                cmd.Parameters.AddWithValue("@TenHangDT", cbbHang.SelectedValue);
                cmd.Parameters.AddWithValue("@MauSac", txb_mausac.Text.Trim());
                cmd.Parameters.AddWithValue("@DungLuong", cbbDungLuong.SelectedValue);
                cmd.Parameters.AddWithValue("@GiaBan", txb_gia.Text.Trim());
                cmd.Parameters.AddWithValue("@SoLuong", txb_soluong.Text.Trim());
                cmd.Parameters.AddWithValue("@TinhTrang", txb_tinhtrang.Text.Trim());
                cmd.Parameters.AddWithValue("@HinhAnh", b);

                cmd.ExecuteNonQuery();
                err = "Lưu thông tin thành công";
                FormEditDienThoai.ActiveForm.Close();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            FormEditDienThoai.ActiveForm.Close();
        }

        private void btn_openimg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox_DT.Image = Image.FromFile(ofd.FileName);
                this.Text = ofd.FileName;
            }
        }

    }
}
