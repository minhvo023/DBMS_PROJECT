using DBMS_NHOM_10.Forms_branch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_NHOM_10
{
    public class DBConnection
    {
        public static SqlConnection conn;
        public static string pq;
        public static void connn( string a)
        {
            string ConnStr = @"Data Source=localhost;Initial Catalog=QuanLyCuaHangDienThoai;User ID=" + a + "; Password=123456";
            conn = new SqlConnection(ConnStr);
            pq = a;
        }
        public static SqlConnection open()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    return conn;
                }
                else
                {
                    return conn;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("User đăng nhập không tồn tại: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return conn;
            }
        }
        public static SqlConnection close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                return conn;
            }
            else { return conn; }
        }

    }
}
