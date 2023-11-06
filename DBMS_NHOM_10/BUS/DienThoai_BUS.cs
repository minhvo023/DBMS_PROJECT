using DBMS_NHOM_10.Forms_branch;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DBMS_NHOM_10.BUS
{
    public class DienThoai_BUS
    {
        /*public static void them_sua_dienthoai(PictureBox pictureBox_DT)
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
            string err = "";
            try
            {

                SqlConnection connection = DataBaseConnection.GetSqlConnection();
                SqlCommand cmd = new SqlCommand("proc_InsertOrUpdateDienThoai", connection);
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
            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK);

        }*/

        private byte[] ImageToByteArray(Image image)
        {
            throw new NotImplementedException();
        }
    }
}
