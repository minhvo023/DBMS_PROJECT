using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_NHOM_10
{
    public class DataBaseConnection
    {
        public static SqlConnection GetSqlConnection()
        {
            string connString = "Data Source=DESKTOP-UUOMSSN;Initial Catalog=QuanLyCuaHangDienThoai;User ID=sa;Password=123456";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }

    }
}
