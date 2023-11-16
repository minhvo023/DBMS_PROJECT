namespace DBMS_NHOM_10.Forms_branch
{
    partial class FormEditKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditKhachHang));
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_thongbao
            // 
            this.lb_thongbao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_thongbao.AutoSize = true;
            this.lb_thongbao.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thongbao.ForeColor = System.Drawing.Color.Red;
            this.lb_thongbao.Location = new System.Drawing.Point(285, 523);
            this.lb_thongbao.Name = "lb_thongbao";
            this.lb_thongbao.Size = new System.Drawing.Size(208, 27);
            this.lb_thongbao.TabIndex = 50;
            this.lb_thongbao.Text = "Thao tác thành công";
            this.lb_thongbao.Visible = false;
            // 
            // btn_Huy
            // 
            this.btn_Huy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.Location = new System.Drawing.Point(424, 426);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(173, 58);
            this.btn_Huy.TabIndex = 49;
            this.btn_Huy.Text = "ĐÓNG";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click_1);
            // 
            // btn_luu
            // 
            this.btn_luu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luu.Location = new System.Drawing.Point(200, 426);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(173, 58);
            this.btn_luu.TabIndex = 48;
            this.btn_luu.Text = "LƯU";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click_1);
            // 
            // txb_diachi
            // 
            this.txb_diachi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_diachi.Location = new System.Drawing.Point(395, 360);
            this.txb_diachi.Name = "txb_diachi";
            this.txb_diachi.Size = new System.Drawing.Size(202, 35);
            this.txb_diachi.TabIndex = 44;
            // 
            // txb_tenKH
            // 
            this.txb_tenKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_tenKH.Location = new System.Drawing.Point(395, 227);
            this.txb_tenKH.Name = "txb_tenKH";
            this.txb_tenKH.Size = new System.Drawing.Size(202, 35);
            this.txb_tenKH.TabIndex = 43;
            // 
            // txb_sdtKH
            // 
            this.txb_sdtKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_sdtKH.Location = new System.Drawing.Point(395, 297);
            this.txb_sdtKH.Name = "txb_sdtKH";
            this.txb_sdtKH.Size = new System.Drawing.Size(202, 35);
            this.txb_sdtKH.TabIndex = 42;
            // 
            // txb_idKH
            // 
            this.txb_idKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_idKH.Location = new System.Drawing.Point(395, 155);
            this.txb_idKH.Name = "txb_idKH";
            this.txb_idKH.ReadOnly = true;
            this.txb_idKH.Size = new System.Drawing.Size(202, 35);
            this.txb_idKH.TabIndex = 41;
            // 
            // lb_diachi
            // 
            this.lb_diachi.AutoSize = true;
            this.lb_diachi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_diachi.Location = new System.Drawing.Point(195, 360);
            this.lb_diachi.Name = "lb_diachi";
            this.lb_diachi.Size = new System.Drawing.Size(86, 27);
            this.lb_diachi.TabIndex = 38;
            this.lb_diachi.Text = "Địa Chỉ";
            // 
            // lb_TenKH
            // 
            this.lb_TenKH.AutoSize = true;
            this.lb_TenKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenKH.Location = new System.Drawing.Point(195, 230);
            this.lb_TenKH.Name = "lb_TenKH";
            this.lb_TenKH.Size = new System.Drawing.Size(113, 27);
            this.lb_TenKH.TabIndex = 36;
            this.lb_TenKH.Text = "Họ và Tên";
            // 
            // lb_sdtKH
            // 
            this.lb_sdtKH.AutoSize = true;
            this.lb_sdtKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sdtKH.Location = new System.Drawing.Point(195, 300);
            this.lb_sdtKH.Name = "lb_sdtKH";
            this.lb_sdtKH.Size = new System.Drawing.Size(137, 27);
            this.lb_sdtKH.TabIndex = 35;
            this.lb_sdtKH.Text = "Số điện thoại";
            // 
            // lb_idKH
            // 
            this.lb_idKH.AutoSize = true;
            this.lb_idKH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_idKH.Location = new System.Drawing.Point(195, 158);
            this.lb_idKH.Name = "lb_idKH";
            this.lb_idKH.Size = new System.Drawing.Size(163, 27);
            this.lb_idKH.TabIndex = 33;
            this.lb_idKH.Text = "ID Khách Hàng";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(791, 45);
            this.panel4.TabIndex = 51;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 594);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 36);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(42, 549);
            this.panel3.TabIndex = 52;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(749, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(42, 549);
            this.panel1.TabIndex = 53;
            // 
            // lb_header
            // 
            this.lb_header.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_header.AutoSize = true;
            this.lb_header.Font = new System.Drawing.Font("Snap ITC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_header.Location = new System.Drawing.Point(205, 66);
            this.lb_header.Name = "lb_header";
            this.lb_header.Size = new System.Drawing.Size(381, 42);
            this.lb_header.TabIndex = 59;
            this.lb_header.Text = "Chỉnh Sửa Thông Tin";
            // 
            // FormEditKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 630);
            this.Controls.Add(this.lb_header);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÔNG TIN KHÁCH HÀNG";
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_header;
    }
}