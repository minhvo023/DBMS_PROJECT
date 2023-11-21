namespace DBMS_NHOM_10.Forms
{
    partial class FormNhanVien
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_ttcv = new System.Windows.Forms.DataGridView();
            this.btn_ttct = new System.Windows.Forms.Button();
            this.dataGridView_ttnv = new System.Windows.Forms.DataGridView();
            this.txb_TimKiem_sdt = new System.Windows.Forms.TextBox();
            this.btnSearch_sđt = new System.Windows.Forms.Button();
            this.dataGridView_Employee = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ttcv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ttnv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panel6.Controls.Add(this.btn_reset);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.dataGridView_ttcv);
            this.panel6.Controls.Add(this.btn_ttct);
            this.panel6.Controls.Add(this.dataGridView_ttnv);
            this.panel6.Controls.Add(this.txb_TimKiem_sdt);
            this.panel6.Controls.Add(this.btnSearch_sđt);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(17, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1274, 341);
            this.panel6.TabIndex = 20;
            // 
            // btn_reset
            // 
            this.btn_reset.FlatAppearance.BorderSize = 0;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.White;
            this.btn_reset.Image = global::DBMS_NHOM_10.Properties.Resources.Loading;
            this.btn_reset.Location = new System.Drawing.Point(6, 6);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(52, 49);
            this.btn_reset.TabIndex = 26;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Số Điện Thoại";
            // 
            // dataGridView_ttcv
            // 
            this.dataGridView_ttcv.AllowUserToAddRows = false;
            this.dataGridView_ttcv.AllowUserToDeleteRows = false;
            this.dataGridView_ttcv.AllowUserToResizeColumns = false;
            this.dataGridView_ttcv.AllowUserToResizeRows = false;
            this.dataGridView_ttcv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ttcv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ttcv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ttcv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ttcv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ttcv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ttcv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ttcv.Location = new System.Drawing.Point(621, 201);
            this.dataGridView_ttcv.Name = "dataGridView_ttcv";
            this.dataGridView_ttcv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ttcv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ttcv.RowHeadersVisible = false;
            this.dataGridView_ttcv.RowHeadersWidth = 62;
            this.dataGridView_ttcv.RowTemplate.Height = 28;
            this.dataGridView_ttcv.Size = new System.Drawing.Size(407, 75);
            this.dataGridView_ttcv.TabIndex = 4;
            // 
            // btn_ttct
            // 
            this.btn_ttct.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_ttct.Location = new System.Drawing.Point(680, 28);
            this.btn_ttct.Name = "btn_ttct";
            this.btn_ttct.Size = new System.Drawing.Size(284, 42);
            this.btn_ttct.TabIndex = 3;
            this.btn_ttct.Text = "ID Nhân Viên [ ]";
            this.btn_ttct.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ttnv
            // 
            this.dataGridView_ttnv.AllowUserToAddRows = false;
            this.dataGridView_ttnv.AllowUserToDeleteRows = false;
            this.dataGridView_ttnv.AllowUserToResizeColumns = false;
            this.dataGridView_ttnv.AllowUserToResizeRows = false;
            this.dataGridView_ttnv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ttnv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ttnv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ttnv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ttnv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_ttnv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ttnv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_ttnv.Location = new System.Drawing.Point(388, 77);
            this.dataGridView_ttnv.Name = "dataGridView_ttnv";
            this.dataGridView_ttnv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ttnv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_ttnv.RowHeadersVisible = false;
            this.dataGridView_ttnv.RowHeadersWidth = 62;
            this.dataGridView_ttnv.RowTemplate.Height = 28;
            this.dataGridView_ttnv.Size = new System.Drawing.Size(868, 102);
            this.dataGridView_ttnv.TabIndex = 2;
            // 
            // txb_TimKiem_sdt
            // 
            this.txb_TimKiem_sdt.Location = new System.Drawing.Point(26, 93);
            this.txb_TimKiem_sdt.Name = "txb_TimKiem_sdt";
            this.txb_TimKiem_sdt.Size = new System.Drawing.Size(293, 30);
            this.txb_TimKiem_sdt.TabIndex = 1;
            // 
            // btnSearch_sđt
            // 
            this.btnSearch_sđt.Location = new System.Drawing.Point(74, 141);
            this.btnSearch_sđt.Name = "btnSearch_sđt";
            this.btnSearch_sđt.Size = new System.Drawing.Size(184, 38);
            this.btnSearch_sđt.TabIndex = 0;
            this.btnSearch_sđt.Text = "Tìm Kiếm";
            this.btnSearch_sđt.UseVisualStyleBackColor = true;
            this.btnSearch_sđt.Click += new System.EventHandler(this.btnSearch_sđt_Click);
            // 
            // dataGridView_Employee
            // 
            this.dataGridView_Employee.AllowUserToAddRows = false;
            this.dataGridView_Employee.AllowUserToDeleteRows = false;
            this.dataGridView_Employee.AllowUserToResizeColumns = false;
            this.dataGridView_Employee.AllowUserToResizeRows = false;
            this.dataGridView_Employee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Employee.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Employee.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Employee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Employee.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Employee.Location = new System.Drawing.Point(17, 358);
            this.dataGridView_Employee.Name = "dataGridView_Employee";
            this.dataGridView_Employee.ReadOnly = true;
            this.dataGridView_Employee.RowHeadersVisible = false;
            this.dataGridView_Employee.RowHeadersWidth = 62;
            this.dataGridView_Employee.RowTemplate.Height = 28;
            this.dataGridView_Employee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Employee.Size = new System.Drawing.Size(1274, 294);
            this.dataGridView_Employee.TabIndex = 25;
            this.dataGridView_Employee.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(17, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1274, 17);
            this.panel5.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(17, 652);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1274, 14);
            this.panel3.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 666);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1291, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 666);
            this.panel2.TabIndex = 22;
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 666);
            this.Controls.Add(this.dataGridView_Employee);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FormNhanVien";
            this.Text = "Danh Sách Nhân Viên";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ttcv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ttnv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_ttct;
        private System.Windows.Forms.DataGridView dataGridView_ttnv;
        private System.Windows.Forms.TextBox txb_TimKiem_sdt;
        private System.Windows.Forms.Button btnSearch_sđt;
        private System.Windows.Forms.DataGridView dataGridView_Employee;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_ttcv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reset;
    }
}