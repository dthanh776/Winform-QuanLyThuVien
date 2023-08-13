using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TheThuVien
    {
        private string maTheThuVien;
        private string tenDocGia;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string sachYeuThich;
        private string nhanVienTao;

        public DTO_TheThuVien(string maTheThuVien, string tenDocGia, DateTime ngaySinh, string gioiTinh, string sachYeuThich, string nhanVienTao)
        {
            this.MaTheThuVien = maTheThuVien;
            this.TenDocGia = tenDocGia;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.SachYeuThich = sachYeuThich;
            this.NhanVienTao = nhanVienTao;
        }

        public string MaTheThuVien { get => maTheThuVien; set => maTheThuVien = value; }
        public string TenDocGia { get => tenDocGia; set => tenDocGia = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SachYeuThich { get => sachYeuThich; set => sachYeuThich = value; }
        public string NhanVienTao { get => nhanVienTao; set => nhanVienTao = value; }
    }
}
