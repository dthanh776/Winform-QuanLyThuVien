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
    public class BLL_TheLoai
    {
        DAL_TheLoai dal_theLoai = new DAL_TheLoai();
        public DataTable hienThiTheLoai()
        {
            return dal_theLoai.hienThiTheLoai("hienThiTheLoai");
        }

        public int ThemTheLoai(DTO_TheLoai theLoai)
        {
            return dal_theLoai.ThemTheLoai(theLoai);
        }

        public int SuaTheLoai(DTO_TheLoai theLoai)
        {
            return dal_theLoai.SuaTheLoai(theLoai);
        }

        public bool XoaTheLoai(string ma)
        {
            return dal_theLoai.XoaTheLoai(ma);
        }
        public bool CheckTonTai(DTO_TheLoai theLoai)
        {
            return dal_theLoai.CheckTonTai(theLoai);
        }
    }
}
