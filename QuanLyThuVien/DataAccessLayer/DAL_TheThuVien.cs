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
    public class DAL_TheThuVien
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable hienThiTheThuVien(string tenStore)
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

        public int ThemTheThuVien(DTO_TheThuVien theThuVien)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("ThemTheThuVien", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaTheThuVien", theThuVien.MaTheThuVien);
            sqlCmd.Parameters.AddWithValue("@HoTenDocGia", theThuVien.TenDocGia);
            sqlCmd.Parameters.AddWithValue("@NgaySinh", theThuVien.NgaySinh);
            sqlCmd.Parameters.AddWithValue("@GioiTinh", theThuVien.GioiTinh);
            sqlCmd.Parameters.AddWithValue("@MaSach", theThuVien.SachYeuThich);
            sqlCmd.Parameters.AddWithValue("@MaNhanVien", theThuVien.NhanVienTao);

            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public int SuaTheThuVien(DTO_TheThuVien theThuVien)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("SuaTheThuVien", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaTheThuVien", theThuVien.MaTheThuVien);
            sqlCmd.Parameters.AddWithValue("@HoTenDocGia", theThuVien.TenDocGia);
            sqlCmd.Parameters.AddWithValue("@NgaySinh", theThuVien.NgaySinh);
            sqlCmd.Parameters.AddWithValue("@GioiTinh", theThuVien.GioiTinh);
            sqlCmd.Parameters.AddWithValue("@MaSach", theThuVien.SachYeuThich);
            sqlCmd.Parameters.AddWithValue("@MaNhanVien", theThuVien.NhanVienTao);

            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public bool XoaTheThuVien(string ma)
        {
            bool flag = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaTheThuVien";
                cmd.Connection = clData.sqlConn;
                cmd.Parameters.Add(new SqlParameter("@MaTheThuVien", ma));
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
        public bool CheckTonTai(DTO_TheThuVien theThuVien)
        {
            dt = null;
            try
            {

                cmd = new SqlCommand("checkTonTaiTheThuVien", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTheThuVien", theThuVien.MaTheThuVien);
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
