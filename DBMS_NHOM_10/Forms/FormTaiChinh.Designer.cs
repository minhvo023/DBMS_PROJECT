namespace DBMS_NHOM_10.Forms
{
    partial class FormTaiChinh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_KQ_HD = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_KQ_DN = new System.Windows.Forms.Button();
            this.cbb_ThangDN = new System.Windows.Forms.ComboBox();
            this.btn_DN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbb_ThangHD = new System.Windows.Forms.ComboBox();
            this.btn_HD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_ThangNV = new System.Windows.Forms.ComboBox();
            this.cbb_idNV = new System.Windows.Forms.ComboBox();
            this.btn_NV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_KQ_NV = new System.Windows.Forms.Button();
            this.dataGridView_show = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel6.Controls.Add(this.btn_reset);
            this.panel6.Controls.Add(this.btn_KQ_HD);
            this.panel6.Controls.Add(this.groupBox3);
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.groupBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(17, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1274, 231);
            this.panel6.TabIndex = 26;
            // 
            // btn_reset
            // 
            this.btn_reset.FlatAppearance.BorderSize = 0;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.White;
            this.btn_reset.Image = global::DBMS_NHOM_10.Properties.Resources.Loading;
            this.btn_reset.Location = new System.Drawing.Point(3, 3);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(52, 49);
            this.btn_reset.TabIndex = 32;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_KQ_HD
            // 
            this.btn_KQ_HD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_KQ_HD.Enabled = false;
            this.btn_KQ_HD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KQ_HD.Location = new System.Drawing.Point(470, 231);
            this.btn_KQ_HD.Name = "btn_KQ_HD";
            this.btn_KQ_HD.Size = new System.Drawing.Size(345, 138);
            this.btn_KQ_HD.TabIndex = 31;
            this.btn_KQ_HD.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.btn_KQ_DN);
            this.groupBox3.Controls.Add(this.cbb_ThangDN);
            this.groupBox3.Controls.Add(this.btn_DN);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(863, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 369);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tổng Đơn Nhập";
            // 
            // btn_KQ_DN
            // 
            this.btn_KQ_DN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_KQ_DN.Enabled = false;
            this.btn_KQ_DN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KQ_DN.Location = new System.Drawing.Point(4, 206);
            this.btn_KQ_DN.Name = "btn_KQ_DN";
            this.btn_KQ_DN.Size = new System.Drawing.Size(345, 138);
            this.btn_KQ_DN.TabIndex = 32;
            this.btn_KQ_DN.UseVisualStyleBackColor = true;
            // 
            // cbb_ThangDN
            // 
            this.cbb_ThangDN.FormattingEnabled = true;
            this.cbb_ThangDN.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbb_ThangDN.Location = new System.Drawing.Point(131, 44);
            this.cbb_ThangDN.Name = "cbb_ThangDN";
            this.cbb_ThangDN.Size = new System.Drawing.Size(178, 33);
            this.cbb_ThangDN.TabIndex = 29;
            // 
            // btn_DN
            // 
            this.btn_DN.Location = new System.Drawing.Point(97, 93);
            this.btn_DN.Name = "btn_DN";
            this.btn_DN.Size = new System.Drawing.Size(119, 39);
            this.btn_DN.TabIndex = 24;
            this.btn_DN.Text = "OK";
            this.btn_DN.UseVisualStyleBackColor = true;
            this.btn_DN.Click += new System.EventHandler(this.btn_DN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Tháng";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(156, 440);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(0, 0);
            this.button7.TabIndex = 30;
            this.button7.Text = "Điểm Danh";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.cbb_ThangHD);
            this.groupBox2.Controls.Add(this.btn_HD);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(466, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 369);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tổng Hóa Đơn";
            // 
            // cbb_ThangHD
            // 
            this.cbb_ThangHD.FormattingEnabled = true;
            this.cbb_ThangHD.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbb_ThangHD.Location = new System.Drawing.Point(131, 46);
            this.cbb_ThangHD.Name = "cbb_ThangHD";
            this.cbb_ThangHD.Size = new System.Drawing.Size(178, 33);
            this.cbb_ThangHD.TabIndex = 29;
            // 
            // btn_HD
            // 
            this.btn_HD.Location = new System.Drawing.Point(97, 94);
            this.btn_HD.Name = "btn_HD";
            this.btn_HD.Size = new System.Drawing.Size(119, 39);
            this.btn_HD.TabIndex = 24;
            this.btn_HD.Text = "OK";
            this.btn_HD.UseVisualStyleBackColor = true;
            this.btn_HD.Click += new System.EventHandler(this.btn_HD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tháng";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(110, 254);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(0, 0);
            this.button4.TabIndex = 29;
            this.button4.Text = "Điểm Danh";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cbb_ThangNV);
            this.groupBox1.Controls.Add(this.cbb_idNV);
            this.groupBox1.Controls.Add(this.btn_NV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_KQ_NV);
            this.groupBox1.Location = new System.Drawing.Point(73, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 369);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lương Nhân Viên";
            // 
            // cbb_ThangNV
            // 
            this.cbb_ThangNV.FormattingEnabled = true;
            this.cbb_ThangNV.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbb_ThangNV.Location = new System.Drawing.Point(131, 90);
            this.cbb_ThangNV.Name = "cbb_ThangNV";
            this.cbb_ThangNV.Size = new System.Drawing.Size(178, 33);
            this.cbb_ThangNV.TabIndex = 29;
            // 
            // cbb_idNV
            // 
            this.cbb_idNV.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbb_idNV.FormattingEnabled = true;
            this.cbb_idNV.Location = new System.Drawing.Point(131, 41);
            this.cbb_idNV.Name = "cbb_idNV";
            this.cbb_idNV.Size = new System.Drawing.Size(178, 33);
            this.cbb_idNV.TabIndex = 28;
            // 
            // btn_NV
            // 
            this.btn_NV.Location = new System.Drawing.Point(97, 139);
            this.btn_NV.Name = "btn_NV";
            this.btn_NV.Size = new System.Drawing.Size(119, 39);
            this.btn_NV.TabIndex = 24;
            this.btn_NV.Text = "OK";
            this.btn_NV.UseVisualStyleBackColor = true;
            this.btn_NV.Click += new System.EventHandler(this.btn_TinhLuong_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "ID";
            // 
            // btn_KQ_NV
            // 
            this.btn_KQ_NV.Enabled = false;
            this.btn_KQ_NV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KQ_NV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_KQ_NV.Location = new System.Drawing.Point(5, 221);
            this.btn_KQ_NV.Name = "btn_KQ_NV";
            this.btn_KQ_NV.Size = new System.Drawing.Size(345, 109);
            this.btn_KQ_NV.TabIndex = 28;
            this.btn_KQ_NV.UseVisualStyleBackColor = true;
            // 
            // dataGridView_show
            // 
            this.dataGridView_show.AllowUserToAddRows = false;
            this.dataGridView_show.AllowUserToDeleteRows = false;
            this.dataGridView_show.AllowUserToResizeColumns = false;
            this.dataGridView_show.AllowUserToResizeRows = false;
            this.dataGridView_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_show.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_show.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_show.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_show.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_show.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView_show.Location = new System.Drawing.Point(17, 248);
            this.dataGridView_show.Name = "dataGridView_show";
            this.dataGridView_show.ReadOnly = true;
            this.dataGridView_show.RowHeadersVisible = false;
            this.dataGridView_show.RowHeadersWidth = 62;
            this.dataGridView_show.RowTemplate.Height = 28;
            this.dataGridView_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_show.Size = new System.Drawing.Size(1274, 404);
            this.dataGridView_show.TabIndex = 31;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(17, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1274, 17);
            this.panel5.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(17, 652);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1274, 14);
            this.panel3.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 666);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1291, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 666);
            this.panel2.TabIndex = 28;
            // 
            // FormTaiChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 666);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.dataGridView_show);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FormTaiChinh";
            this.Text = "Tài Chính";
            this.panel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridView_show;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_KQ_DN;
        private System.Windows.Forms.Button btn_KQ_HD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbb_ThangDN;
        private System.Windows.Forms.Button btn_DN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbb_ThangHD;
        private System.Windows.Forms.Button btn_HD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_KQ_NV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_ThangNV;
        private System.Windows.Forms.ComboBox cbb_idNV;
        private System.Windows.Forms.Button btn_NV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reset;
    }
}