using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_NHOM_10.Forms
{
    public partial class FormShift : Form
    {
        public FormShift()
        {
            InitializeComponent();
            danhsach_ca();
        }
        
        public void danhsach_ca()
        {
            string query = "SELECT * FROM v_phancong";

            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_ca.DataSource = table;
            dataGridView_ca.Columns[0].HeaderText = "ID Ca";
            dataGridView_ca.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView_ca.Columns[2].HeaderText = "Tên công việc";
            dataGridView_ca.Columns[3].HeaderText = "Giờ bắt đầu";
            dataGridView_ca.Columns[4].HeaderText = "Giờ kết thúc";
            dataGridView_ca.Columns[5].HeaderText = "Ngày làm";

            dateTimePicker_ca.Format = DateTimePickerFormat.Custom;
            dateTimePicker_ca.CustomFormat = "dd/MM/yyyy";
            DateTime dateTime = DateTime.Now;
            dateTimePicker_ca.Value = dateTime;
        }
        public void timkiemca()
        {
            DateTime dateTime = dateTimePicker_ca.Value;
            string dateString = dateTime.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                string query = "exec proc_timkiemphancong_ca " + " N'" + dateString + "',null";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView_ca.DataSource = dataTable;
            }
            else
            {
                string query = "exec proc_timkiemphancong_ca " + " N'" + dateString + "', N'" + textBox1.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView_ca.DataSource = dataTable;
            }
            
        }
        
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_DateCa_Click(object sender, EventArgs e)
        {
            timkiemca();
        }


        public void load_refresh()
        {
            string query = "SELECT * FROM v_phancong";

            SqlDataAdapter dap = new SqlDataAdapter(query, DataBaseConnection.GetSqlConnection());
            DataTable table = new DataTable();
            dap.Fill(table);
            dataGridView_ca.DataSource = table;
            dataGridView_ca.Columns[0].HeaderText = "ID Ca";
            dataGridView_ca.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView_ca.Columns[2].HeaderText = "Tên công việc";
            dataGridView_ca.Columns[3].HeaderText = "Giờ bắt đầu";
            dataGridView_ca.Columns[4].HeaderText = "Giờ kết thúc";
            dataGridView_ca.Columns[5].HeaderText = "Ngày làm";

            dateTimePicker_ca.Format = DateTimePickerFormat.Custom;
            dateTimePicker_ca.CustomFormat = "dd/MM/yyyy";
            DateTime dateTime = DateTime.Now;
            dateTimePicker_ca.Value = dateTime;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
