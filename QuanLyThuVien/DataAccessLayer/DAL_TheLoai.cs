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
    public class DAL_TheLoai
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable hienThiTheLoai(string tenStore)
        {
            DataTable dtResult = new DataTable();
            SqlCommand sqlCmd = new SqlCommand(tenStore, clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daSP = new SqlDataAdapter(sqlCmd);
            daSP.Fill(dtResult);
            return dtResult;
        }

        public int ThemTheLoai(DTO_TheLoai theLoai)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("ThemTheLoai", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaTheLoai", theLoai.MaTheLoai);
            sqlCmd.Parameters.AddWithValue("@TenTheThoai", theLoai.TenTheLoai);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public int SuaTheLoai(DTO_TheLoai theLoai)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("SuaTheLoai", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaTheLoai", theLoai.MaTheLoai);
            sqlCmd.Parameters.AddWithValue("@TenTheThoai", theLoai.TenTheLoai);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public bool XoaTheLoai(string ma)
        {
            bool flag = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaTheLoai";
                cmd.Connection = clData.sqlConn;
                cmd.Parameters.Add(new SqlParameter("@MaTheLoai", ma));
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

        public bool CheckTonTai(DTO_TheLoai theLoai)
        {
            dt = null;
            try
            {

                cmd = new SqlCommand("checkTonTai", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTheLoai", theLoai.MaTheLoai);
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
