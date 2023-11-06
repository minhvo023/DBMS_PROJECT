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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_reset = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePicker_ca = new System.Windows.Forms.DateTimePicker();
            this.btn_DateCa = new System.Windows.Forms.Button();
            this.dataGridView_ca = new System.Windows.Forms.DataGridView();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ca)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_reset
            // 
            this.btn_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset.Image = ((System.Drawing.Image)(resources.GetObject("btn_reset.Image")));
            this.btn_reset.Location = new System.Drawing.Point(0, 0);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(2);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(54, 51);
            this.btn_reset.TabIndex = 20;
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PowderBlue;
            this.panel4.Controls.Add(this.btn_refresh);
            this.panel4.Controls.Add(this.dateTimePicker_ca);
            this.panel4.Controls.Add(this.btn_DateCa);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(941, 138);
            this.panel4.TabIndex = 21;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // dateTimePicker_ca
            // 
            this.dateTimePicker_ca.Location = new System.Drawing.Point(92, 51);
            this.dateTimePicker_ca.Name = "dateTimePicker_ca";
            this.dateTimePicker_ca.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker_ca.TabIndex = 21;
            // 
            // btn_DateCa
            // 
            this.btn_DateCa.Location = new System.Drawing.Point(106, 77);
            this.btn_DateCa.Name = "btn_DateCa";
            this.btn_DateCa.Size = new System.Drawing.Size(161, 24);
            this.btn_DateCa.TabIndex = 20;
            this.btn_DateCa.Text = "Tìm kiếm";
            this.btn_DateCa.UseVisualStyleBackColor = true;
            this.btn_DateCa.Click += new System.EventHandler(this.btn_DateCa_Click);
            // 
            // dataGridView_ca
            // 
            this.dataGridView_ca.AllowUserToAddRows = false;
            this.dataGridView_ca.AllowUserToDeleteRows = false;
            this.dataGridView_ca.AllowUserToResizeColumns = false;
            this.dataGridView_ca.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_ca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ca.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_ca.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ca.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_ca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ca.Location = new System.Drawing.Point(0, 138);
            this.dataGridView_ca.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_ca.Name = "dataGridView_ca";
            this.dataGridView_ca.ReadOnly = true;
            this.dataGridView_ca.RowHeadersVisible = false;
            this.dataGridView_ca.RowHeadersWidth = 62;
            this.dataGridView_ca.RowTemplate.Height = 28;
            this.dataGridView_ca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ca.Size = new System.Drawing.Size(941, 261);
            this.dataGridView_ca.TabIndex = 22;
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(0, 0);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(45, 41);
            this.btn_refresh.TabIndex = 22;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // FormShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 399);
            this.Controls.Add(this.dataGridView_ca);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_reset);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormShift";
            this.Text = "Bảng Phân Ca";
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ca;
        private System.Windows.Forms.Button btn_DateCa;
        private System.Windows.Forms.DataGridView dataGridView_ca;
        private System.Windows.Forms.Button btn_refresh;
    }
}