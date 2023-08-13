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
    public class BLL_MuonSach
    {
        DAL_MuonSach dAL_MuonSach = new DAL_MuonSach();
        public DataTable hienThiMuonSach()
        {
            return dAL_MuonSach.hienThiMuonSach("hienThiMuonSach");
        }
        public int ThemMuonSach(DTO_MuonSach ms)
        {
            return dAL_MuonSach.ThemMuonSach(ms);
        }
        public DataTable layTenDocGia(string ms)
        {
            return dAL_MuonSach.layTenDocGia(ms);
        }
        public bool CheckTonTai(DTO_MuonSach ms)
        {
            return dAL_MuonSach.CheckTonTai(ms);
        }
        public bool checkTonTaiMaThe(string ms)
        {
            return dAL_MuonSach.CheckTonTaiMaThe(ms);
        }
    }
}
