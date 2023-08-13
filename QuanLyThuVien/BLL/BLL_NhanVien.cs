using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;
using System.Data;
namespace BLL
{
    public class BLL_NhanVien
    {
        DAL_NhanVien dAL_NhanVien = new DAL_NhanVien();
        public DataTable hienThiNhanVien()
        {
            return dAL_NhanVien.hienThiNhanVien("hienThiNhanVien");
        }

        public int ThemNhanVien(DTO_NhanVien nv)
        {
            return dAL_NhanVien.ThemNhanVien(nv);
        }

        public int SuaNhanVien(DTO_NhanVien nv)
        {
            return dAL_NhanVien.SuaNhanVien(nv);
        }

        public bool XoaNhanVien(string ma)
        {
            return dAL_NhanVien.XoaNhanVien(ma);
        }
        public bool CheckTonTai(DTO_NhanVien nv)
        {
            return dAL_NhanVien.CheckTonTai(nv);
        }
    }
}
