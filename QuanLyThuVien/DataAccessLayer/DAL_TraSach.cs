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
    public class DAL_TraSach
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable hienThiTraSach(string tenStore)
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
        public bool CheckTonTai(DTO_TraSach traSach)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("checkTonTaiTraSach", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTraSach", traSach.MaTraSach);
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
        public int ThemTraSach(DTO_TraSach traSach)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("ThemTraSach", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaTraSach", traSach.MaTraSach);
            sqlCmd.Parameters.AddWithValue("@MaMuonSach", traSach.MaMuonSach);
            sqlCmd.Parameters.AddWithValue("@MaTheThuVien", traSach.MaTheThuVien);
            sqlCmd.Parameters.AddWithValue("@HoTenDocGia", traSach.TenDocGia);
            sqlCmd.Parameters.AddWithValue("@MaSach", traSach.TenSach);
            sqlCmd.Parameters.AddWithValue("@MaNhanVien", traSach.NhanVien);
            sqlCmd.Parameters.AddWithValue("@NgayDuTra", traSach.NgayDuTra);
            sqlCmd.Parameters.AddWithValue("@NgayThucTra", traSach.NgayThucTra);
            sqlCmd.Parameters.AddWithValue("@SoNgayQuaHan", traSach.SoNgayQuaHan);
            sqlCmd.Parameters.AddWithValue("@TienPhat", traSach.TienPhat);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public DataTable layTenMuonSach(string tenStore)
        {
            dt = null;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("layTenMuonSach", clData.sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@MaMuonSach", tenStore);
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
        public bool CheckTonMaMuonSach(string muon)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("checkTonTaiMuonSach", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaMuonSach", muon);
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
        public bool SuaTrangThai(string muon)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("SuaTrangThai", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaMuonSach", muon);
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
