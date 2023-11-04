namespace DBMS_NHOM_10.Forms_branch
{
    partial class FormEditDienThoai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_ID = new System.Windows.Forms.Label();
            this.lb_Ten = new System.Windows.Forms.Label();
            this.lb_Hang = new System.Windows.Forms.Label();
            this.lb_Gia = new System.Windows.Forms.Label();
            this.lb_mausac = new System.Windows.Forms.Label();
            this.lb_dungluong = new System.Windows.Forms.Label();
            this.lb_soluong = new System.Windows.Forms.Label();
            this.lb_tinhtrang = new System.Windows.Forms.Label();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.txb_ten = new System.Windows.Forms.TextBox();
            this.txb_gia = new System.Windows.Forms.TextBox();
            this.txb_mausac = new System.Windows.Forms.TextBox();
            this.txb_soluong = new System.Windows.Forms.TextBox();
            this.txb_tinhtrang = new System.Windows.Forms.TextBox();
            this.btn_openimg = new System.Windows.Forms.Button();
            this.pictureBox_DT = new System.Windows.Forms.PictureBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.lb_thongbao = new System.Windows.Forms.Label();
            this.cbbHang = new System.Windows.Forms.ComboBox();
            this.cbbDungLuong = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DT)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_ID
            // 
            this.lb_ID.AutoSize = true;
            this.lb_ID.Location = new System.Drawing.Point(43, 68);
            this.lb_ID.Name = "lb_ID";
            this.lb_ID.Size = new System.Drawing.Size(106, 20);
            this.lb_ID.TabIndex = 8;
            this.lb_ID.Text = "ID Điện Thoại";
            // 
            // lb_Ten
            // 
            this.lb_Ten.AutoSize = true;
            this.lb_Ten.Location = new System.Drawing.Point(43, 163);
            this.lb_Ten.Name = "lb_Ten";
            this.lb_Ten.Size = new System.Drawing.Size(116, 20);
            this.lb_Ten.TabIndex = 9;
            this.lb_Ten.Text = "Tên Điện Thoại";
            // 
            // lb_Hang
            // 
            this.lb_Hang.AutoSize = true;
            this.lb_Hang.Location = new System.Drawing.Point(43, 246);
            this.lb_Hang.Name = "lb_Hang";
            this.lb_Hang.Size = new System.Drawing.Size(128, 20);
            this.lb_Hang.TabIndex = 10;
            this.lb_Hang.Text = "Hãng Điện Thoại";
            // 
            // lb_Gia
            // 
            this.lb_Gia.AutoSize = true;
            this.lb_Gia.Location = new System.Drawing.Point(43, 337);
            this.lb_Gia.Name = "lb_Gia";
            this.lb_Gia.Size = new System.Drawing.Size(67, 20);
            this.lb_Gia.TabIndex = 11;
            this.lb_Gia.Text = "Giá Bán";
            // 
            // lb_mausac
            // 
            this.lb_mausac.AutoSize = true;
            this.lb_mausac.Location = new System.Drawing.Point(450, 68);
            this.lb_mausac.Name = "lb_mausac";
            this.lb_mausac.Size = new System.Drawing.Size(72, 20);
            this.lb_mausac.TabIndex = 12;
            this.lb_mausac.Text = "Màu Sắc";
            // 
            // lb_dungluong
            // 
            this.lb_dungluong.AutoSize = true;
            this.lb_dungluong.Location = new System.Drawing.Point(450, 163);
            this.lb_dungluong.Name = "lb_dungluong";
            this.lb_dungluong.Size = new System.Drawing.Size(97, 20);
            this.lb_dungluong.TabIndex = 13;
            this.lb_dungluong.Text = "Dung Lượng";
            // 
            // lb_soluong
            // 
            this.lb_soluong.AutoSize = true;
            this.lb_soluong.Location = new System.Drawing.Point(450, 249);
            this.lb_soluong.Name = "lb_soluong";
            this.lb_soluong.Size = new System.Drawing.Size(78, 20);
            this.lb_soluong.TabIndex = 14;
            this.lb_soluong.Text = "Số Lượng";
            // 
            // lb_tinhtrang
            // 
            this.lb_tinhtrang.AutoSize = true;
            this.lb_tinhtrang.Location = new System.Drawing.Point(450, 337);
            this.lb_tinhtrang.Name = "lb_tinhtrang";
            this.lb_tinhtrang.Size = new System.Drawing.Size(84, 20);
            this.lb_tinhtrang.TabIndex = 15;
            this.lb_tinhtrang.Text = "Tình Trạng";
            // 
            // txb_id
            // 
            this.txb_id.Location = new System.Drawing.Point(176, 65);
            this.txb_id.Name = "txb_id";
            this.txb_id.ReadOnly = true;
            this.txb_id.Size = new System.Drawing.Size(202, 26);
            this.txb_id.TabIndex = 16;
            // 
            // txb_ten
            // 
            this.txb_ten.Location = new System.Drawing.Point(176, 160);
            this.txb_ten.Name = "txb_ten";
            this.txb_ten.Size = new System.Drawing.Size(202, 26);
            this.txb_ten.TabIndex = 18;
            // 
            // txb_gia
            // 
            this.txb_gia.Location = new System.Drawing.Point(176, 334);
            this.txb_gia.Name = "txb_gia";
            this.txb_gia.Size = new System.Drawing.Size(202, 26);
            this.txb_gia.TabIndex = 20;
            // 
            // txb_mausac
            // 
            this.txb_mausac.Location = new System.Drawing.Point(572, 65);
            this.txb_mausac.Name = "txb_mausac";
            this.txb_mausac.Size = new System.Drawing.Size(158, 26);
            this.txb_mausac.TabIndex = 21;
            // 
            // txb_soluong
            // 
            this.txb_soluong.Location = new System.Drawing.Point(572, 243);
            this.txb_soluong.Name = "txb_soluong";
            this.txb_soluong.Size = new System.Drawing.Size(158, 26);
            this.txb_soluong.TabIndex = 23;
            // 
            // txb_tinhtrang
            // 
            this.txb_tinhtrang.Location = new System.Drawing.Point(572, 334);
            this.txb_tinhtrang.Name = "txb_tinhtrang";
            this.txb_tinhtrang.ReadOnly = true;
            this.txb_tinhtrang.Size = new System.Drawing.Size(158, 26);
            this.txb_tinhtrang.TabIndex = 24;
            // 
            // btn_openimg
            // 
            this.btn_openimg.Location = new System.Drawing.Point(30, 438);
            this.btn_openimg.Name = "btn_openimg";
            this.btn_openimg.Size = new System.Drawing.Size(119, 39);
            this.btn_openimg.TabIndex = 25;
            this.btn_openimg.Text = "Choose img";
            this.btn_openimg.UseVisualStyleBackColor = true;
            this.btn_openimg.Click += new System.EventHandler(this.btn_openimg_Click);
            // 
            // pictureBox_DT
            // 
            this.pictureBox_DT.Location = new System.Drawing.Point(176, 385);
            this.pictureBox_DT.Name = "pictureBox_DT";
            this.pictureBox_DT.Size = new System.Drawing.Size(183, 136);
            this.pictureBox_DT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_DT.TabIndex = 26;
            this.pictureBox_DT.TabStop = false;
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(427, 419);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(173, 58);
            this.btn_luu.TabIndex = 27;
            this.btn_luu.Text = "LƯU";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(631, 419);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(173, 58);
            this.btn_huy.TabIndex = 28;
            this.btn_huy.Text = "ĐÓNG";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // lb_thongbao
            // 
            this.lb_thongbao.AutoSize = true;
            this.lb_thongbao.Location = new System.Drawing.Point(511, 492);
            this.lb_thongbao.Name = "lb_thongbao";
            this.lb_thongbao.Size = new System.Drawing.Size(199, 20);
            this.lb_thongbao.TabIndex = 29;
            this.lb_thongbao.Text = "Đã Chỉnh Sửa Thành Công";
            this.lb_thongbao.Visible = false;
            // 
            // cbbHang
            // 
            this.cbbHang.FormattingEnabled = true;
            this.cbbHang.Location = new System.Drawing.Point(177, 238);
            this.cbbHang.Name = "cbbHang";
            this.cbbHang.Size = new System.Drawing.Size(201, 28);
            this.cbbHang.TabIndex = 30;
            // 
            // cbbDungLuong
            // 
            this.cbbDungLuong.FormattingEnabled = true;
            this.cbbDungLuong.Location = new System.Drawing.Point(572, 163);
            this.cbbDungLuong.Name = "cbbDungLuong";
            this.cbbDungLuong.Size = new System.Drawing.Size(158, 28);
            this.cbbDungLuong.TabIndex = 31;
            // 
            // FormEditDienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 570);
            this.Controls.Add(this.cbbDungLuong);
            this.Controls.Add(this.cbbHang);
            this.Controls.Add(this.lb_thongbao);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.pictureBox_DT);
            this.Controls.Add(this.btn_openimg);
            this.Controls.Add(this.txb_tinhtrang);
            this.Controls.Add(this.txb_soluong);
            this.Controls.Add(this.txb_mausac);
            this.Controls.Add(this.txb_gia);
            this.Controls.Add(this.txb_ten);
            this.Controls.Add(this.txb_id);
            this.Controls.Add(this.lb_tinhtrang);
            this.Controls.Add(this.lb_soluong);
            this.Controls.Add(this.lb_dungluong);
            this.Controls.Add(this.lb_mausac);
            this.Controls.Add(this.lb_Gia);
            this.Controls.Add(this.lb_Hang);
            this.Controls.Add(this.lb_Ten);
            this.Controls.Add(this.lb_ID);
            this.Name = "FormEditDienThoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditDienThoai";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_ID;
        private System.Windows.Forms.Label lb_Ten;
        private System.Windows.Forms.Label lb_Hang;
        private System.Windows.Forms.Label lb_Gia;
        private System.Windows.Forms.Label lb_mausac;
        private System.Windows.Forms.Label lb_dungluong;
        private System.Windows.Forms.Label lb_soluong;
        private System.Windows.Forms.Label lb_tinhtrang;
        private System.Windows.Forms.TextBox txb_id;
        private System.Windows.Forms.TextBox txb_ten;
        private System.Windows.Forms.TextBox txb_gia;
        private System.Windows.Forms.TextBox txb_mausac;
        private System.Windows.Forms.TextBox txb_soluong;
        private System.Windows.Forms.TextBox txb_tinhtrang;
        private System.Windows.Forms.Button btn_openimg;
        private System.Windows.Forms.PictureBox pictureBox_DT;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Label lb_thongbao;
        private System.Windows.Forms.ComboBox cbbHang;
        private System.Windows.Forms.ComboBox cbbDungLuong;
    }
}