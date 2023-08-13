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
    public class DAL_NhanVien
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable hienThiNhanVien(string tenStore)
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

        public int ThemNhanVien(DTO_NhanVien nhanVien)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("ThemNhanVien", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
            sqlCmd.Parameters.AddWithValue("@HoTenNV", nhanVien.TenNhanVien);
            sqlCmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
            sqlCmd.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
            sqlCmd.Parameters.AddWithValue("@DienThoai", nhanVien.DienThoai);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public int SuaNhanVien(DTO_NhanVien nhanVien)
        {
            int iKetqua;
            SqlCommand sqlCmd = new SqlCommand("SuaNhanVien", clData.sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
            sqlCmd.Parameters.AddWithValue("@HoTenNV", nhanVien.TenNhanVien);
            sqlCmd.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh);
            sqlCmd.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
            sqlCmd.Parameters.AddWithValue("@DienThoai", nhanVien.DienThoai);
            iKetqua = sqlCmd.ExecuteNonQuery();
            return iKetqua;
        }

        public bool XoaNhanVien(string ma)
        {
            bool flag = false;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaNhanVien";
                cmd.Connection = clData.sqlConn;
                cmd.Parameters.Add(new SqlParameter("@MaNhanVien", ma));
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
        public bool CheckTonTai(DTO_NhanVien nhanVien)
        {
            dt = null;
            try
            {

                cmd = new SqlCommand("checkTonTaiNhanVien", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNhanVien", nhanVien.MaNhanVien);
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
