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
    public class BLL_TacGia
    {
        DAL_TacGia dal_tacGia = new DAL_TacGia();

        public DataTable hienThiTacGia()
        {
            return dal_tacGia.hienThiTacGia("hienThiTacGia");
        }

        public int ThemTacGia(DTO_TacGia tacGia)
        {
            return dal_tacGia.ThemTacGia(tacGia);
        }

        public int SuaTacGia(DTO_TacGia tacGia)
        {
            return dal_tacGia.SuaTacGia(tacGia);
        }

        public bool XoaTacGia(string ma)
        {
            return dal_tacGia.XoaTacGia(ma);
        }
        public bool CheckTonTai(DTO_TacGia tacGia)
        {
            return dal_tacGia.CheckTonTai(tacGia);
        }
    }
}
