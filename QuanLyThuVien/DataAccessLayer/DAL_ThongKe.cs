using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DataAccessLayer
{
    public class DAL_ThongKe
    {
        private DataTable dt;
        private SqlCommand sqlCmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable SachDangDuocMuon()
        {
            dt = null;
            try
            {
                sqlCmd = new SqlCommand("SachDangDuocMuon", clData.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(sqlCmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable DocGiaQuaHanTraSach()
        {
            dt = null;
            try
            {
                sqlCmd = new SqlCommand("DocGiaQuaHanTraSach", clData.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(sqlCmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
