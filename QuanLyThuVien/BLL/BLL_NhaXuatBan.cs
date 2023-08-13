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
    public class BLL_NhaXuatBan
    {
        DAL_NhaXuatBan dal_nxb = new DAL_NhaXuatBan();
        public DataTable getData()
        {
            return dal_nxb.getDataSP("layNXB");
        }

        public int ThemNXB(DTO_NXB nxb)
        {
            return dal_nxb.ThemNXB(nxb);
        }

        public int SuaNXB(DTO_NXB nxb)
        {
            return dal_nxb.SuaNXB(nxb);
        }

        public bool XoaNXB(string ma)
        {
            return dal_nxb.XoaNXB(ma);
        }
        public bool CheckTonTai(DTO_NXB nxb)
        {
            return dal_nxb.CheckTonTai(nxb);
        }
    }
}
