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
    public class BLL_Sach
    {
        DAL_Sach dal_Sach = new DAL_Sach();
        public DataTable hienThiSach()
        {
            return dal_Sach.hienThiSach("hienThiSach");
        }
        public bool CheckTonTai(DTO_Sach sach)
        {
            return dal_Sach.CheckTonTai(sach);
        }
        public bool ThemSach(DTO_Sach sach)
        {
            return dal_Sach.ThemSach(sach);
        }
        public bool SuaSach(DTO_Sach sach)
        {
            return dal_Sach.SuaSach(sach);
        }
        public bool XoaSach(string sach)
        {
            return dal_Sach.XoaSach(sach);
        }
        public DataTable TimSach(string tenSach)
        {
            return dal_Sach.TimSach("TimSach", tenSach);
        }
        public DataTable ReportSach()
        {
            return dal_Sach.ReportSach();
        }
    }
}
