namespace DBMS_NHOM_10.Forms
{
    partial class FormOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrders));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTrangThaiHD = new System.Windows.Forms.Button();
            this.cbb_timkiem_tt = new System.Windows.Forms.ComboBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btnDateHD = new System.Windows.Forms.Button();
            this.btn_cthd = new System.Windows.Forms.Button();
            this.dataGridView_CTHD_kh = new System.Windows.Forms.DataGridView();
            this.dateTimePicker_HD = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_CTDH_nv = new System.Windows.Forms.DataGridView();
            this.dataGridView_CTHD_dt = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Order = new System.Windows.Forms.DataGridView();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTHD_kh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTDH_nv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTHD_dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Order)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Controls.Add(this.dataGridView_CTHD_dt);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(17, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1448, 415);
            this.panel6.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PowderBlue;
            this.panel4.Controls.Add(this.btnTrangThaiHD);
            this.panel4.Controls.Add(this.cbb_timkiem_tt);
            this.panel4.Controls.Add(this.btn_reset);
            this.panel4.Controls.Add(this.btnDateHD);
            this.panel4.Controls.Add(this.btn_cthd);
            this.panel4.Controls.Add(this.dataGridView_CTHD_kh);
            this.panel4.Controls.Add(this.dateTimePicker_HD);
            this.panel4.Controls.Add(this.dataGridView_CTDH_nv);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1448, 212);
            this.panel4.TabIndex = 16;
            // 
            // btnTrangThaiHD
            // 
            this.btnTrangThaiHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrangThaiHD.Location = new System.Drawing.Point(128, 159);
            this.btnTrangThaiHD.Name = "btnTrangThaiHD";
            this.btnTrangThaiHD.Size = new System.Drawing.Size(151, 42);
            this.btnTrangThaiHD.TabIndex = 21;
            this.btnTrangThaiHD.Text = "Tìm Kiếm";
            this.btnTrangThaiHD.UseVisualStyleBackColor = true;
            this.btnTrangThaiHD.Click += new System.EventHandler(this.btnTrangThaiHD_Click);
            // 
            // cbb_timkiem_tt
            // 
            this.cbb_timkiem_tt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbb_timkiem_tt.FormattingEnabled = true;
            this.cbb_timkiem_tt.Location = new System.Drawing.Point(86, 120);
            this.cbb_timkiem_tt.Name = "cbb_timkiem_tt";
            this.cbb_timkiem_tt.Size = new System.Drawing.Size(255, 33);
            this.cbb_timkiem_tt.TabIndex = 20;
            // 
            // btn_reset
            // 
            this.btn_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset.Image = ((System.Drawing.Image)(resources.GetObject("btn_reset.Image")));
            this.btn_reset.Location = new System.Drawing.Point(0, 0);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(81, 79);
            this.btn_reset.TabIndex = 19;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btnDateHD
            // 
            this.btnDateHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDateHD.Location = new System.Drawing.Point(128, 58);
            this.btnDateHD.Name = "btnDateHD";
            this.btnDateHD.Size = new System.Drawing.Size(151, 42);
            this.btnDateHD.TabIndex = 18;
            this.btnDateHD.Text = "Tìm Kiếm";
            this.btnDateHD.UseVisualStyleBackColor = true;
            this.btnDateHD.Click += new System.EventHandler(this.btnDateHD_Click);
            // 
            // btn_cthd
            // 
            this.btn_cthd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cthd.BackColor = System.Drawing.Color.White;
            this.btn_cthd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cthd.ForeColor = System.Drawing.Color.Black;
            this.btn_cthd.Location = new System.Drawing.Point(397, 49);
            this.btn_cthd.Name = "btn_cthd";
            this.btn_cthd.Size = new System.Drawing.Size(287, 112);
            this.btn_cthd.TabIndex = 16;
            this.btn_cthd.Tag = "";
            this.btn_cthd.Text = "ID Hóa Đơn:";
            this.btn_cthd.UseVisualStyleBackColor = false;
            // 
            // dataGridView_CTHD_kh
            // 
            this.dataGridView_CTHD_kh.AllowUserToAddRows = false;
            this.dataGridView_CTHD_kh.AllowUserToDeleteRows = false;
            this.dataGridView_CTHD_kh.AllowUserToResizeColumns = false;
            this.dataGridView_CTHD_kh.AllowUserToResizeRows = false;
            this.dataGridView_CTHD_kh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView_CTHD_kh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_CTHD_kh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_CTHD_kh.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView_CTHD_kh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_CTHD_kh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_CTHD_kh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_CTHD_kh.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_CTHD_kh.Location = new System.Drawing.Point(702, 120);
            this.dataGridView_CTHD_kh.Name = "dataGridView_CTHD_kh";
            this.dataGridView_CTHD_kh.ReadOnly = true;
            this.dataGridView_CTHD_kh.RowHeadersVisible = false;
            this.dataGridView_CTHD_kh.RowHeadersWidth = 62;
            this.dataGridView_CTHD_kh.RowTemplate.Height = 28;
            this.dataGridView_CTHD_kh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_CTHD_kh.Size = new System.Drawing.Size(716, 74);
            this.dataGridView_CTHD_kh.TabIndex = 13;
            // 
            // dateTimePicker_HD
            // 
            this.dateTimePicker_HD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker_HD.Location = new System.Drawing.Point(86, 22);
            this.dateTimePicker_HD.Name = "dateTimePicker_HD";
            this.dateTimePicker_HD.Size = new System.Drawing.Size(255, 30);
            this.dateTimePicker_HD.TabIndex = 17;
            this.dateTimePicker_HD.Value = new System.DateTime(2023, 11, 1, 20, 0, 5, 0);
            // 
            // dataGridView_CTDH_nv
            // 
            this.dataGridView_CTDH_nv.AllowUserToAddRows = false;
            this.dataGridView_CTDH_nv.AllowUserToDeleteRows = false;
            this.dataGridView_CTDH_nv.AllowUserToResizeColumns = false;
            this.dataGridView_CTDH_nv.AllowUserToResizeRows = false;
            this.dataGridView_CTDH_nv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView_CTDH_nv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_CTDH_nv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_CTDH_nv.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView_CTDH_nv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_CTDH_nv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_CTDH_nv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_CTDH_nv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_CTDH_nv.Location = new System.Drawing.Point(702, 25);
            this.dataGridView_CTDH_nv.Name = "dataGridView_CTDH_nv";
            this.dataGridView_CTDH_nv.ReadOnly = true;
            this.dataGridView_CTDH_nv.RowHeadersVisible = false;
            this.dataGridView_CTDH_nv.RowHeadersWidth = 62;
            this.dataGridView_CTDH_nv.RowTemplate.Height = 28;
            this.dataGridView_CTDH_nv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_CTDH_nv.Size = new System.Drawing.Size(716, 74);
            this.dataGridView_CTDH_nv.TabIndex = 15;
            // 
            // dataGridView_CTHD_dt
            // 
            this.dataGridView_CTHD_dt.AllowUserToAddRows = false;
            this.dataGridView_CTHD_dt.AllowUserToDeleteRows = false;
            this.dataGridView_CTHD_dt.AllowUserToResizeColumns = false;
            this.dataGridView_CTHD_dt.AllowUserToResizeRows = false;
            this.dataGridView_CTHD_dt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView_CTHD_dt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_CTHD_dt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_CTHD_dt.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView_CTHD_dt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_CTHD_dt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_CTHD_dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_CTHD_dt.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_CTHD_dt.Location = new System.Drawing.Point(128, 243);
            this.dataGridView_CTHD_dt.Name = "dataGridView_CTHD_dt";
            this.dataGridView_CTHD_dt.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_CTHD_dt.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_CTHD_dt.RowHeadersVisible = false;
            this.dataGridView_CTHD_dt.RowHeadersWidth = 62;
            this.dataGridView_CTHD_dt.RowTemplate.Height = 28;
            this.dataGridView_CTHD_dt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_CTHD_dt.Size = new System.Drawing.Size(1211, 128);
            this.dataGridView_CTHD_dt.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(17, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1448, 17);
            this.panel5.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(17, 673);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1448, 14);
            this.panel3.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 687);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1465, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 687);
            this.panel2.TabIndex = 9;
            // 
            // dataGridView_Order
            // 
            this.dataGridView_Order.AllowUserToAddRows = false;
            this.dataGridView_Order.AllowUserToDeleteRows = false;
            this.dataGridView_Order.AllowUserToResizeColumns = false;
            this.dataGridView_Order.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_Order.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_Order.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Order.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Order.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Order.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Order.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_Order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Order.Location = new System.Drawing.Point(17, 432);
            this.dataGridView_Order.Name = "dataGridView_Order";
            this.dataGridView_Order.ReadOnly = true;
            this.dataGridView_Order.RowHeadersVisible = false;
            this.dataGridView_Order.RowHeadersWidth = 62;
            this.dataGridView_Order.RowTemplate.Height = 28;
            this.dataGridView_Order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Order.Size = new System.Drawing.Size(1448, 241);
            this.dataGridView_Order.TabIndex = 12;
            this.dataGridView_Order.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            // 
            // FormOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 687);
            this.Controls.Add(this.dataGridView_Order);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FormOrders";
            this.Text = "Danh Sách Hóa Đơn";
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTHD_kh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTDH_nv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTHD_dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Order)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_Order;
        private System.Windows.Forms.DataGridView dataGridView_CTHD_dt;
        private System.Windows.Forms.DataGridView dataGridView_CTHD_kh;
        private System.Windows.Forms.DataGridView dataGridView_CTDH_nv;
        private System.Windows.Forms.Button btn_cthd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_HD;
        private System.Windows.Forms.Button btnDateHD;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btnTrangThaiHD;
        private System.Windows.Forms.ComboBox cbb_timkiem_tt;
    }
}