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

                txb_id.Text = datarow.Cells[0].Value.ToString();
                txb_ten.Text = datarow.Cells[1].Value.ToString();
                cbbHang.Text = datarow.Cells[2].Value.ToString();
                txb_mausac.Text = datarow.Cells[3].Value.ToString();
                cbbDungLuong.Text = datarow.Cells[4].Value.ToString();
                txb_gia.Text = datarow.Cells[5].Value.ToString();
                txb_soluong.Text = datarow.Cells[6].Value.ToString();
                txb_tinhtrang.Text = datarow.Cells[7].Value.ToString();
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

                string str;
                str = "SELECT count(idDienThoai) FROM DienThoai";
                int k = int.Parse(Functions.GetFieldValues(str)) + 1;
                string formattedResult = k.ToString("D2"); // Định dạng số nguyên k với 2 chữ số

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

        byte[] ImageToByteArray(Image image)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            byte[] b = ImageToByteArray(pictureBox_DT.Image);

            using (SqlConnection connection = DataBaseConnection.GetSqlConnection())
            using (SqlCommand cmd = new SqlCommand("proc_InsertOrUpdateDienThoai", connection))
            {
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
            }
            MessageBox.Show("Lưu thông tin thành công - Hãy REFRESH", "Thông báo", MessageBoxButtons.OK);
            FormEditDienThoai.ActiveForm.Close();
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
