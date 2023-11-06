namespace DBMS_NHOM_10.Forms
{
    partial class FormShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShift));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.dateTimePicker_ca = new System.Windows.Forms.DateTimePicker();
            this.btn_DateCa = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.dataGridView_ca = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ca)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PowderBlue;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.btn_refresh);
            this.panel4.Controls.Add(this.dateTimePicker_ca);
            this.panel4.Controls.Add(this.btn_DateCa);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1306, 239);
            this.panel4.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(600, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nhập tên việc làm cần tìm kiếm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(600, 78);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(319, 26);
            this.textBox1.TabIndex = 23;
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(0, 0);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(68, 63);
            this.btn_refresh.TabIndex = 22;
            this.btn_refresh.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_ca
            // 
            this.dateTimePicker_ca.Location = new System.Drawing.Point(138, 78);
            this.dateTimePicker_ca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_ca.Name = "dateTimePicker_ca";
            this.dateTimePicker_ca.Size = new System.Drawing.Size(278, 26);
            this.dateTimePicker_ca.TabIndex = 21;
            // 
            // btn_DateCa
            // 
            this.btn_DateCa.Location = new System.Drawing.Point(159, 118);
            this.btn_DateCa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_DateCa.Name = "btn_DateCa";
            this.btn_DateCa.Size = new System.Drawing.Size(242, 37);
            this.btn_DateCa.TabIndex = 20;
            this.btn_DateCa.Text = "Tìm kiếm";
            this.btn_DateCa.UseVisualStyleBackColor = true;
            this.btn_DateCa.Click += new System.EventHandler(this.btn_DateCa_Click_1);
            // 
            // btn_reset
            // 
            this.btn_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset.Image = ((System.Drawing.Image)(resources.GetObject("btn_reset.Image")));
            this.btn_reset.Location = new System.Drawing.Point(0, 0);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(81, 78);
            this.btn_reset.TabIndex = 23;
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ca
            // 
            this.dataGridView_ca.AllowUserToAddRows = false;
            this.dataGridView_ca.AllowUserToDeleteRows = false;
            this.dataGridView_ca.AllowUserToResizeColumns = false;
            this.dataGridView_ca.AllowUserToResizeRows = false;
            this.dataGridView_ca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ca.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ca.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_ca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ca.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_ca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ca.Location = new System.Drawing.Point(0, 239);
            this.dataGridView_ca.Name = "dataGridView_ca";
            this.dataGridView_ca.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ca.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_ca.RowHeadersVisible = false;
            this.dataGridView_ca.RowHeadersWidth = 62;
            this.dataGridView_ca.RowTemplate.Height = 28;
            this.dataGridView_ca.Size = new System.Drawing.Size(1306, 427);
            this.dataGridView_ca.TabIndex = 27;
            // 
            // FormShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 666);
            this.Controls.Add(this.dataGridView_ca);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_reset);
            this.Name = "FormShift";
            this.Text = "Bảng Phân Ca";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ca;
        private System.Windows.Forms.Button btn_DateCa;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.DataGridView dataGridView_ca;
    }
}