using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_NHOM_10
{
    public class DBConnection
    {

        private static string ConnStr = @"Data Source=localhost;Initial Catalog=QuanLyCuaHangDienThoai;User ID=sa;Password=123456";
        private static SqlConnection conn = new SqlConnection(ConnStr);

        public static SqlConnection open()
        {
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
                return conn;
            }
            else { return conn; }
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
