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
    public class DAL_NhaXuatBan
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable getDataSP(string tenStore)
        {
            dt = null;
            try
            {
            cmd = new SqlCommand(tenStore, clData.sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return dt;
        }

        public int ThemNXB(DTO_NXB nxb)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("ThemNXB", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaNXB", nxb.MaNXB);
            sqlCmd.Parameters.AddWithValue("@TenNXB", nxb.TenNXB);
            sqlCmd.Parameters.AddWithValue("@SoDienThoai", nxb.SoDienThoai);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public int SuaNXB(DTO_NXB nxb)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("SuaNXB", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaNXB", nxb.MaNXB);
            sqlCmd.Parameters.AddWithValue("@TenNXB", nxb.TenNXB);
            sqlCmd.Parameters.AddWithValue("@SoDienThoai", nxb.SoDienThoai);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public bool XoaNXB(string ma)
        {
            bool flag = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaNXB";
                cmd.Connection = clData.sqlConn;
                cmd.Parameters.Add(new SqlParameter("@MaNXB", ma));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return flag;
        }
        public bool CheckTonTai(DTO_NXB nxb)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("checkTonTaiNXB", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNXB", nxb.MaNXB);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
