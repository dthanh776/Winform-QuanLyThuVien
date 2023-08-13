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
    public class DAL_MuonSach
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable hienThiMuonSach(string tenStore)
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
        public bool CheckTonTai(DTO_MuonSach muonSach)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("checkTonTaiMuonSach", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaMuonSach", muonSach.MaMuonSach);
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
        public int ThemMuonSach(DTO_MuonSach muonSach)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("ThemMuonSach", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaMuonSach", muonSach.MaMuonSach);
            sqlCmd.Parameters.AddWithValue("@MaTheThuVien", muonSach.MaTheThuVien);
            sqlCmd.Parameters.AddWithValue("@HoTenDocGia", muonSach.TenDocGia);
            sqlCmd.Parameters.AddWithValue("@MaSach", muonSach.TenSach);
            sqlCmd.Parameters.AddWithValue("@MaNhanVien", muonSach.NhanVien);
            sqlCmd.Parameters.AddWithValue("@NgayMuon", muonSach.NgayMuon);
            sqlCmd.Parameters.AddWithValue("@NgayTra", muonSach.NgayTra);
            sqlCmd.Parameters.AddWithValue("@TrangThai", muonSach.TrangThai);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public DataTable layTenDocGia(string tenStore)
        {
            dt = null;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("LayTenDocGia", clData.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MaTheThuVien", tenStore);
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
        public bool CheckTonTaiMaThe(string the)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("checkTonTaiTheThuVien", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTheThuVien", the);
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
