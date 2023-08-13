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
    public class BLL_ThongKe
    {
        DAL_ThongKe dAL_ThongKe = new DAL_ThongKe();
        public DataTable SachDangDuocMuon()
        {
            return dAL_ThongKe.SachDangDuocMuon();
        }
        public DataTable DocGiaQuaHanTraSach()
        {
            return dAL_ThongKe.DocGiaQuaHanTraSach();
        }
    }
}
