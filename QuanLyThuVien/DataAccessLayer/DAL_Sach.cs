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
    public class DAL_Sach
    {
        private DataTable dt;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        clsDataBase clData = new clsDataBase();

        public DataTable hienThiSach(string tenStore)
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
        public bool CheckTonTai(DTO_Sach sach)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("checkTonTaiSach", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSach", sach.MaSach);
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

        public bool ThemSach (DTO_Sach sach)
        {
            try
            {
                cmd = new SqlCommand("ThemSach", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaSach", sach.MaSach));
                cmd.Parameters.Add(new SqlParameter("@TenSach", sach.TenSach));
                cmd.Parameters.Add(new SqlParameter("@NamXuatBan", sach.NamXuatBan));
                cmd.Parameters.Add(new SqlParameter("@MaNXB", sach.MaNXB));
                cmd.Parameters.Add(new SqlParameter("@MaTheLoai", sach.MaTheLoai));
                cmd.Parameters.Add(new SqlParameter("@MaTacGia", sach.MaTacGia));
                if (cmd.ExecuteNonQuery() > 0)
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
        public bool SuaSach(DTO_Sach sach)
        {
            try
            {
                cmd = new SqlCommand("SuaSach", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaSach", sach.MaSach));
                cmd.Parameters.Add(new SqlParameter("@TenSach", sach.TenSach));
                cmd.Parameters.Add(new SqlParameter("@NamXuatBan", sach.NamXuatBan));
                cmd.Parameters.Add(new SqlParameter("@MaNXB", sach.MaNXB));
                cmd.Parameters.Add(new SqlParameter("@MaTheLoai", sach.MaTheLoai));
                cmd.Parameters.Add(new SqlParameter("@MaTacGia", sach.MaTacGia));
                if (cmd.ExecuteNonQuery() > 0)
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
        public bool XoaSach(string sach)
        {
            try
            {
                cmd = new SqlCommand("XoaSach", clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MaSach", sach));

                if (cmd.ExecuteNonQuery() > 0)
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
        public DataTable TimSach(string a, string tenSach)
        {
            dt = null;
            try
            {
                cmd = new SqlCommand(a, clData.sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TenSach", tenSach));
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
        public DataTable ReportSach()
        {
            dt = null;
            try
            {
                cmd = new SqlCommand("ReportSach", clData.sqlConn);
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
    }
}
