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
    public class DAL_TacGia
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable hienThiTacGia(string tenStore)
        {
            DataTable dtResult = new DataTable();
            SqlCommand sqlCmd = new SqlCommand(tenStore, clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daSP = new SqlDataAdapter(sqlCmd);
            daSP.Fill(dtResult);
            return dtResult;
        }

        public int ThemTacGia (DTO_TacGia tacGia)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("ThemTacGia", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaTacGia", tacGia.MaTacGia);
            sqlCmd.Parameters.AddWithValue("@HoTenTG", tacGia.TenTacGia);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public int SuaTacGia(DTO_TacGia tacGia)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("SuaTacGia", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaTacGia", tacGia.MaTacGia);
            sqlCmd.Parameters.AddWithValue("@HoTenTG", tacGia.TenTacGia);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public bool XoaTacGia(string ma)
        {
            bool flag = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaTacGia";
                cmd.Connection = clData.sqlConn;
                cmd.Parameters.Add(new SqlParameter("@MaTacGia", ma));
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
        public bool CheckTonTai(DTO_TacGia tacGia)
        {
            dt = null;
            try
            {

                cmd = new SqlCommand("checkTonTaiTacGia", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTacGia", tacGia.MaTacGia);
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
