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
    public class BLL_TheThuVien
    {
        DAL_TheThuVien dAL_TheThuVien =  new DAL_TheThuVien();
        public DataTable hienThiTheThuVien()
        {
            return dAL_TheThuVien.hienThiTheThuVien("hienThiTheThuVien");
        }

        public int ThemTheThuVien(DTO_TheThuVien dg)
        {
            return dAL_TheThuVien.ThemTheThuVien(dg);
        }

        public int SuaTheThuVien(DTO_TheThuVien dg)
        {
            return dAL_TheThuVien.SuaTheThuVien(dg);
        }

        public bool XoaTheThuVien(string ma)
        {
            return dAL_TheThuVien.XoaTheThuVien(ma);
        }
        public bool CheckTonTai(DTO_TheThuVien dg)
        {
            return dAL_TheThuVien.CheckTonTai(dg);
        }
    }
}
