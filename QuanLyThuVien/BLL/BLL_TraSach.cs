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
    public class BLL_TraSach
    {
        DAL_TraSach dAL_TraSach = new DAL_TraSach();
        public DataTable hienThiTraSach()
        {
            return dAL_TraSach.hienThiTraSach("hienThiTraSach");
        }
        public int ThemTraSach(DTO_TraSach ts)
        {
            return dAL_TraSach.ThemTraSach(ts);
        }
        public DataTable layTenMuonSach(string ts)
        {
            return dAL_TraSach.layTenMuonSach(ts);
        }
        public bool CheckTonTai(DTO_TraSach ts)
        {
            return dAL_TraSach.CheckTonTai(ts);
        }
        public bool checkTonTaiMuonSach(string ts)
        {
            return dAL_TraSach.CheckTonMaMuonSach(ts);
        }
        public bool SuaTrangThai(string ts)
        {
            return dAL_TraSach.SuaTrangThai(ts);
        }
    }
}
