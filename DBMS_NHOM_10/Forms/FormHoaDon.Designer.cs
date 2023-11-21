namespace DBMS_NHOM_10.Forms
{
    partial class FormHoaDon
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_NamHD = new System.Windows.Forms.TextBox();
            this.txb_ThangHD = new System.Windows.Forms.TextBox();
            this.txb_NgayHD = new System.Windows.Forms.TextBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.cbb_timkiem_tt = new System.Windows.Forms.ComboBox();
            this.btn_timkiemHD = new System.Windows.Forms.Button();
            this.btn_cthd = new System.Windows.Forms.Button();
            this.dataGridView_CTHD_kh = new System.Windows.Forms.DataGridView();
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
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txb_NamHD);
            this.panel4.Controls.Add(this.txb_ThangHD);
            this.panel4.Controls.Add(this.txb_NgayHD);
            this.panel4.Controls.Add(this.btn_reset);
            this.panel4.Controls.Add(this.cbb_timkiem_tt);
            this.panel4.Controls.Add(this.btn_timkiemHD);
            this.panel4.Controls.Add(this.btn_cthd);
            this.panel4.Controls.Add(this.dataGridView_CTHD_kh);
            this.panel4.Controls.Add(this.dataGridView_CTDH_nv);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1448, 212);
            this.panel4.TabIndex = 16;
           // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "/";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 22);
            this.label3.TabIndex = 33;
            this.label3.Text = "(Ngày / Tháng / Năm)";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "/";
            // 
            // txb_NamHD
            // 
            this.txb_NamHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txb_NamHD.Location = new System.Drawing.Point(246, 36);
            this.txb_NamHD.Name = "txb_NamHD";
            this.txb_NamHD.Size = new System.Drawing.Size(78, 30);
            this.txb_NamHD.TabIndex = 30;
            // 
            // txb_ThangHD
            // 
            this.txb_ThangHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txb_ThangHD.Location = new System.Drawing.Point(156, 36);
            this.txb_ThangHD.Name = "txb_ThangHD";
            this.txb_ThangHD.Size = new System.Drawing.Size(43, 30);
            this.txb_ThangHD.TabIndex = 29;
            // 
            // txb_NgayHD
            // 
            this.txb_NgayHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txb_NgayHD.Location = new System.Drawing.Point(69, 36);
            this.txb_NgayHD.Name = "txb_NgayHD";
            this.txb_NgayHD.Size = new System.Drawing.Size(43, 30);
            this.txb_NgayHD.TabIndex = 28;
            // 
            // btn_reset
            // 
            this.btn_reset.FlatAppearance.BorderSize = 0;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.White;
            this.btn_reset.Image = global::DBMS_NHOM_10.Properties.Resources.Loading1;
            this.btn_reset.Location = new System.Drawing.Point(6, 6);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(52, 49);
            this.btn_reset.TabIndex = 27;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // cbb_timkiem_tt
            // 
            this.cbb_timkiem_tt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbb_timkiem_tt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_timkiem_tt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_timkiem_tt.FormattingEnabled = true;
            this.cbb_timkiem_tt.Items.AddRange(new object[] {
            "Tất Cả",
            "Hoàn Thành",
            "Đã hủy"});
            this.cbb_timkiem_tt.Location = new System.Drawing.Point(69, 107);
            this.cbb_timkiem_tt.Name = "cbb_timkiem_tt";
            this.cbb_timkiem_tt.Size = new System.Drawing.Size(255, 35);
            this.cbb_timkiem_tt.TabIndex = 20;
            // 
            // btn_timkiemHD
            // 
            this.btn_timkiemHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_timkiemHD.Location = new System.Drawing.Point(109, 152);
            this.btn_timkiemHD.Name = "btn_timkiemHD";
            this.btn_timkiemHD.Size = new System.Drawing.Size(151, 42);
            this.btn_timkiemHD.TabIndex = 18;
            this.btn_timkiemHD.Text = "Tìm Kiếm";
            this.btn_timkiemHD.UseVisualStyleBackColor = true;
            this.btn_timkiemHD.Click += new System.EventHandler(this.btn_timkiemHD_Click);
            // 
            // btn_cthd
            // 
            this.btn_cthd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cthd.BackColor = System.Drawing.Color.White;
            this.btn_cthd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cthd.ForeColor = System.Drawing.Color.Black;
            this.btn_cthd.Location = new System.Drawing.Point(408, 51);
            this.btn_cthd.Name = "btn_cthd";
            this.btn_cthd.Size = new System.Drawing.Size(287, 112);
            this.btn_cthd.TabIndex = 16;
            this.btn_cthd.Tag = "";
            this.btn_cthd.Text = "ID Hóa Đơn [ ]";
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
            this.dataGridView_CTHD_kh.BackgroundColor = System.Drawing.Color.White;
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
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_CTHD_kh.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_CTHD_kh.Location = new System.Drawing.Point(719, 120);
            this.dataGridView_CTHD_kh.Name = "dataGridView_CTHD_kh";
            this.dataGridView_CTHD_kh.ReadOnly = true;
            this.dataGridView_CTHD_kh.RowHeadersVisible = false;
            this.dataGridView_CTHD_kh.RowHeadersWidth = 62;
            this.dataGridView_CTHD_kh.RowTemplate.Height = 28;
            this.dataGridView_CTHD_kh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_CTHD_kh.Size = new System.Drawing.Size(699, 74);
            this.dataGridView_CTHD_kh.TabIndex = 13;
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
            this.dataGridView_CTDH_nv.BackgroundColor = System.Drawing.Color.White;
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
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_CTDH_nv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_CTDH_nv.Location = new System.Drawing.Point(719, 25);
            this.dataGridView_CTDH_nv.Name = "dataGridView_CTDH_nv";
            this.dataGridView_CTDH_nv.ReadOnly = true;
            this.dataGridView_CTDH_nv.RowHeadersVisible = false;
            this.dataGridView_CTDH_nv.RowHeadersWidth = 62;
            this.dataGridView_CTDH_nv.RowTemplate.Height = 28;
            this.dataGridView_CTDH_nv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_CTDH_nv.Size = new System.Drawing.Size(699, 74);
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
            this.dataGridView_CTHD_dt.BackgroundColor = System.Drawing.Color.White;
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
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
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
            this.dataGridView_CTHD_dt.Size = new System.Drawing.Size(1211, 146);
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
            // FormHoaDon
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
            this.Name = "FormHoaDon";
            this.Text = "Danh Sách Hóa Đơn";
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Button btn_timkiemHD;
        private System.Windows.Forms.ComboBox cbb_timkiem_tt;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_NamHD;
        private System.Windows.Forms.TextBox txb_ThangHD;
        private System.Windows.Forms.TextBox txb_NgayHD;
        private System.Windows.Forms.Label label4;
    }
}