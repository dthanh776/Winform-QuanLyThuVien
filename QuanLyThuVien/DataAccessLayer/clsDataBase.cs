using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    class clsDataBase
    {
        public SqlConnection sqlConn = new SqlConnection();
        string sConnection = @"Data Source=DESKTOP-FAJNC15\SQLEXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public clsDataBase()
        {
            try
            {
                sqlConn.ConnectionString = sConnection;
                sqlConn.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
