namespace DBMS_NHOM_10.Forms_branch
{
    partial class FormEditKH
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
            this.lb_thongbao = new System.Windows.Forms.Label();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.txb_diachi = new System.Windows.Forms.TextBox();
            this.txb_tenKH = new System.Windows.Forms.TextBox();
            this.txb_sdtKH = new System.Windows.Forms.TextBox();
            this.txb_idKH = new System.Windows.Forms.TextBox();
            this.lb_diachi = new System.Windows.Forms.Label();
            this.lb_TenKH = new System.Windows.Forms.Label();
            this.lb_sdtKH = new System.Windows.Forms.Label();
            this.lb_idKH = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_thongbao
            // 
            this.lb_thongbao.AutoSize = true;
            this.lb_thongbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thongbao.Location = new System.Drawing.Point(278, 467);
            this.lb_thongbao.Name = "lb_thongbao";
            this.lb_thongbao.Size = new System.Drawing.Size(250, 25);
            this.lb_thongbao.TabIndex = 50;
            this.lb_thongbao.Text = "Đã Chỉnh Sửa Thành Công";
            this.lb_thongbao.Visible = false;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Location = new System.Drawing.Point(487, 348);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(173, 58);
            this.btn_Huy.TabIndex = 49;
            this.btn_Huy.Text = "ĐÓNG";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click_1);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(164, 348);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(173, 58);
            this.btn_luu.TabIndex = 48;
            this.btn_luu.Text = "LƯU";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click_1);
            // 
            // txb_diachi
            // 
            this.txb_diachi.Location = new System.Drawing.Point(572, 235);
            this.txb_diachi.Name = "txb_diachi";
            this.txb_diachi.Size = new System.Drawing.Size(158, 26);
            this.txb_diachi.TabIndex = 44;
            // 
            // txb_tenKH
            // 
            this.txb_tenKH.Location = new System.Drawing.Point(572, 152);
            this.txb_tenKH.Name = "txb_tenKH";
            this.txb_tenKH.Size = new System.Drawing.Size(158, 26);
            this.txb_tenKH.TabIndex = 43;
            // 
            // txb_sdtKH
            // 
            this.txb_sdtKH.Location = new System.Drawing.Point(176, 235);
            this.txb_sdtKH.Name = "txb_sdtKH";
            this.txb_sdtKH.Size = new System.Drawing.Size(202, 26);
            this.txb_sdtKH.TabIndex = 42;
            // 
            // txb_idKH
            // 
            this.txb_idKH.Location = new System.Drawing.Point(176, 152);
            this.txb_idKH.Name = "txb_idKH";
            this.txb_idKH.ReadOnly = true;
            this.txb_idKH.Size = new System.Drawing.Size(202, 26);
            this.txb_idKH.TabIndex = 41;
            // 
            // lb_diachi
            // 
            this.lb_diachi.AutoSize = true;
            this.lb_diachi.Location = new System.Drawing.Point(450, 241);
            this.lb_diachi.Name = "lb_diachi";
            this.lb_diachi.Size = new System.Drawing.Size(60, 20);
            this.lb_diachi.TabIndex = 38;
            this.lb_diachi.Text = "Địa Chỉ";
            // 
            // lb_TenKH
            // 
            this.lb_TenKH.AutoSize = true;
            this.lb_TenKH.Location = new System.Drawing.Point(450, 155);
            this.lb_TenKH.Name = "lb_TenKH";
            this.lb_TenKH.Size = new System.Drawing.Size(81, 20);
            this.lb_TenKH.TabIndex = 36;
            this.lb_TenKH.Text = "Họ và Tên";
            // 
            // lb_sdtKH
            // 
            this.lb_sdtKH.AutoSize = true;
            this.lb_sdtKH.Location = new System.Drawing.Point(43, 238);
            this.lb_sdtKH.Name = "lb_sdtKH";
            this.lb_sdtKH.Size = new System.Drawing.Size(102, 20);
            this.lb_sdtKH.TabIndex = 35;
            this.lb_sdtKH.Text = "Số điện thoại";
            // 
            // lb_idKH
            // 
            this.lb_idKH.AutoSize = true;
            this.lb_idKH.Location = new System.Drawing.Point(43, 155);
            this.lb_idKH.Name = "lb_idKH";
            this.lb_idKH.Size = new System.Drawing.Size(118, 20);
            this.lb_idKH.TabIndex = 33;
            this.lb_idKH.Text = "ID Khách Hàng";
            // 
            // FormEditKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 570);
            this.Controls.Add(this.lb_thongbao);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.txb_diachi);
            this.Controls.Add(this.txb_tenKH);
            this.Controls.Add(this.txb_sdtKH);
            this.Controls.Add(this.txb_idKH);
            this.Controls.Add(this.lb_diachi);
            this.Controls.Add(this.lb_TenKH);
            this.Controls.Add(this.lb_sdtKH);
            this.Controls.Add(this.lb_idKH);
            this.Name = "FormEditKH";
            this.Text = "FormEditKH";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_thongbao;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.TextBox txb_diachi;
        private System.Windows.Forms.TextBox txb_tenKH;
        private System.Windows.Forms.TextBox txb_sdtKH;
        private System.Windows.Forms.TextBox txb_idKH;
        private System.Windows.Forms.Label lb_diachi;
        private System.Windows.Forms.Label lb_TenKH;
        private System.Windows.Forms.Label lb_sdtKH;
        private System.Windows.Forms.Label lb_idKH;
    }
}