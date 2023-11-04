using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_NHOM_10.Forms_branch;
using DBMS_NHOM_10.View;

namespace DBMS_NHOM_10.Forms
{
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
            danhsach_dienthoai();
            CollapseMenu();
            CollapseMenuGia();

            AddContextMenu();
        }


        public void danhsach_dienthoai()
        {
            string query = "SELECT * FROM DienThoai";
            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_Product.DataSource = table;

            dataGridView_Product.Columns[0].HeaderText = "ID";
            dataGridView_Product.Columns[1].HeaderText = "Hãng";
            dataGridView_Product.Columns[2].HeaderText = "Tên";
            dataGridView_Product.Columns[3].HeaderText = "Màu sắc";
            dataGridView_Product.Columns[4].HeaderText = "Dung lượng";
            dataGridView_Product.Columns[5].HeaderText = "Giá";
            dataGridView_Product.Columns[6].HeaderText = "Số lượng";
            dataGridView_Product.Columns[7].HeaderText = "Trạng Thái";
            dataGridView_Product.Columns[8].HeaderText = "Hình ảnh";
        }

        private void btnHang_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Tag = 0;

        }
        private void CollapseMenu()
        {
            if (this.panelSearch.Height > 40)
            {
                this.panelSearch.Height = 37;
                this.panelSearch.Width = 130;
                btnHang.Dock = DockStyle.Top;
            }
            else
            {
                this.panelSearch.Height = 140;
                this.panelSearch.Width = 200;

                btnHang.Dock = DockStyle.Top;
            }
        }

        private void btnHang1_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Text = btnHang1.Text;
            btnHang.Tag = btnHang1.Text;

        }

        private void btnHang2_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Text = btnHang2.Text;
            btnHang.Tag = btnHang2.Text;

        }

        private void btnHang3_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Text = btnHang3.Text;
            btnHang.Tag = btnHang3.Text;

        }

        private void btnHang4_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Text = btnHang4.Text;
            btnHang.Tag = btnHang4.Text;

        }

        private void btnHang5_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Text = btnHang5.Text;
            btnHang.Tag = btnHang5.Text;

        }

        private void btnHang6_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Text = btnHang6.Text;
            btnHang.Tag = btnHang6.Text;

        }

        private void btnHangAll_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            btnHang.Text = btnHangAll.Text;
            btnHang.Tag = 0;

        }

        private void btnGia_Click(object sender, EventArgs e)
        {
            CollapseMenuGia();
            btnGia.Tag = 0;
        }

        private void CollapseMenuGia()
        {
            if (this.panelGia.Height > 40)
            {
                this.panelGia.Height = 37;
                this.panelGia.Width = 100;
                btnGia.Dock = DockStyle.Top;
            }
            else
            {
                this.panelGia.Height = 140;
                this.panelGia.Width = 150;

                btnGia.Dock = DockStyle.Top;
            }
        }

        private void btnGiaAll_Click(object sender, EventArgs e)
        {
            CollapseMenuGia();
            btnGia.Text = btnGiaAll.Text;
            btnGia.Tag = 0;

        }

        private void btnGia1_Click(object sender, EventArgs e)
        {
            CollapseMenuGia();
            btnGia.Text = btnGia1.Text;
            btnGia.Tag = btnGia1.Text;

        }

        private void btnGia2_Click(object sender, EventArgs e)
        {
            CollapseMenuGia();
            btnGia.Text = btnGia2.Text;
            btnGia.Tag = btnGia2.Text;

        }

        private void btnGia3_Click(object sender, EventArgs e)
        {
            CollapseMenuGia();
            btnGia.Text = btnGia3.Text;
            btnGia.Tag = btnGia3.Text;

        }

        private void btnTimKiem_Hang_Gia_Click(object sender, EventArgs e)
        {
            timkiemDT_hang_gia();
        }

        private void btnTimKiem_TenDT_Click(object sender, EventArgs e)
        {
            timkiemDT_Ten();
        }
        public void timkiemDT_hang_gia()
        {
            string value1 = btnHang.Tag.ToString();
            string value2 = btnGia.Tag.ToString();

            string query = "exec proc_TimKiemHangGiaDT " + value1 + "," + "'" + value2 + "'" + "";

            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            DataTable dt = table;
            dataGridView_Product.DataSource = dt;
        }
        public void timkiemDT_Ten()
        {
            string value = txbSearch.Text;
            string query;
            btnGia.Text = "Giá";
            btnHang.Text = "Hãng Điện Thoại";

            if (value == "")
            {
                query = "exec proc_TimKiemTenDT null ";

            }
            else
            {
                query = "exec proc_TimKiemTenDT '" + value + "'";
            }
            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            DataTable dt = table;
            dataGridView_Product.DataSource = dt;
        }

        private DataGridViewCellEventArgs mouseLocation;
        DataTable dt = new DataTable();

        ToolStripMenuItem toolStripItem_themgh = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem_sua = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem_themsp = new ToolStripMenuItem();
        ToolStripMenuItem toolStripItem_xoa = new ToolStripMenuItem();

        private void AddContextMenu()
        {
            toolStripItem_themgh.Text = "Thêm vào giỏ hàng";
            toolStripItem_themgh.Click += new EventHandler(toolStripItem_themgh_Click);

            toolStripItem_sua.Text = "Chính sửa thông tin";
            toolStripItem_sua.Click += new EventHandler(toolStripItem_sua_Click);

            toolStripItem_themsp.Text = "Thêm sản phẩm";
            toolStripItem_themsp.Click += new EventHandler(toolStripItem_themsp_Click);

            toolStripItem_xoa.Text = "Xóa sản phẩm";
            toolStripItem_xoa.Click += new EventHandler(toolStripItem_xoa_Click);

            ContextMenuStrip strip = new ContextMenuStrip();

            foreach (DataGridViewColumn column in dataGridView_Product.Columns)
            {

                column.ContextMenuStrip = strip;
                column.ContextMenuStrip.Items.Add(toolStripItem_themgh);
                column.ContextMenuStrip.Items.Add(toolStripItem_sua);
                column.ContextMenuStrip.Items.Add(toolStripItem_themsp);
                column.ContextMenuStrip.Items.Add(toolStripItem_xoa);

            }
        }

        

        private void toolStripItem_themgh_Click(object sender, EventArgs args)
        {
            string a = dataGridView_Product.Rows[mouseLocation.RowIndex].Cells["idDienThoai"].Value.ToString();
            string checktrangthai = "Select TrangThai from DienThoai where idDienThoai = N'" + a + "'";
            if (Functions.GetFieldValues(checktrangthai) == "Hết hàng")
            {
                MessageBox.Show("Sản phẩm đã hết hàng ", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                soluong slg = new soluong();
                slg.sl = new soluong.ssoluong(loadData);
                slg.ShowDialog();

                void loadData(string soluong)
                {
                    string b = soluong;

                    string checksoluong = "Select SoLuong from DienThoai where idDienThoai = N'" + a + "'";

                    if (int.Parse(Functions.GetFieldValues(checksoluong)) >= int.Parse(b) && int.Parse(b) > 0)
                    {
                        string query = "exec proc_themgiohang " + a + "," + b;

                        SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                        DataTable dt_giohang = new DataTable();

                        adapter.Fill(dt_giohang);
                        dt.Merge(dt_giohang);

                        dataGridView_GioHang.DataSource = dt;
                        dataGridView_GioHang.Columns[0].HeaderText = "ID";
                        dataGridView_GioHang.Columns[1].HeaderText = "Tên Điện Thoại";
                        dataGridView_GioHang.Columns[2].HeaderText = "Giá Bán";
                        dataGridView_GioHang.Columns[3].HeaderText = "Số Lượng";

                        slg.Close();

                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số lượng > 0 và <= " + Functions.GetFieldValues(checksoluong), "Thông Báo", MessageBoxButtons.OK);
                    }
                }
            }
            

        }


        private void toolStripItem_sua_Click(object sender, EventArgs args)
        {
            string ck = "sửa";
            DataGridViewRow datarow = dataGridView_Product.Rows[mouseLocation.RowIndex];
            FormEditDienThoai form_edit_dt = new FormEditDienThoai(datarow, ck);
            form_edit_dt.ShowDialog();

        }

        private void toolStripItem_themsp_Click(object sender, EventArgs args)
        {
            string ck = "thêm";
            DataGridViewRow datarow = dataGridView_Product.Rows[mouseLocation.RowIndex];
            FormEditDienThoai form_edit_dt = new FormEditDienThoai(datarow, ck);
            form_edit_dt.ShowDialog();

        }


        private void toolStripItem_xoa_Click(object sender, EventArgs args)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm", "thông báo", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                string sql;
                string a = dataGridView_Product.Rows[mouseLocation.RowIndex].Cells["idDienThoai"].Value.ToString();
                sql = "exec proc_XoaDienThoai '" + a.Trim() + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DataBaseConnection.GetSqlConnection();
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {

            }
        }



        private void dataGridView_CellMouseEnter(object sender,DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void btn_TaoHoaDon_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm");

            }
            else
            {
                FormTaoHoaDon form_thd = new FormTaoHoaDon(dt);
                form_thd.ShowDialog();
                dt.Clear();
            }
        }

    }
}
