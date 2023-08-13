using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        private string maNhanVien;
        private string tenNhanVien;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string dienThoai;

        public DTO_NhanVien(string maNhanVien, string tenNhanVien, DateTime ngaySinh, string gioiTinh, string dienThoai)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DienThoai = dienThoai;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
    }
}
