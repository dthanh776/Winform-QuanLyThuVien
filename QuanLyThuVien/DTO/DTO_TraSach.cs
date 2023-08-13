using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TraSach
    {
        private string maTraSach;
        private string maMuonSach;
        private string maTheThuVien;
        private string tenDocGia;
        private string tenSach;
        private string nhanVien;
        private DateTime ngayDuTra;
        private DateTime ngayThucTra;
        private int soNgayQuaHan;
        private int tienPhat;

        public DTO_TraSach(string maTraSach, string maMuonSach, string maTheThuVien, string tenDocGia, string tenSach, string nhanVien, DateTime ngayDuTra, DateTime ngayThucTra, int soNgayQuaHan, int tienPhat)
        {
            this.MaTraSach = maTraSach;
            this.MaMuonSach = maMuonSach;
            this.MaTheThuVien = maTheThuVien;
            this.TenDocGia = tenDocGia;
            this.TenSach = tenSach;
            this.NhanVien = nhanVien;
            this.NgayDuTra = ngayDuTra;
            this.NgayThucTra = ngayThucTra;
            this.SoNgayQuaHan = soNgayQuaHan;
            this.TienPhat = tienPhat;
        }

        public string MaTraSach { get => maTraSach; set => maTraSach = value; }
        public string MaMuonSach { get => maMuonSach; set => maMuonSach = value; }
        public string MaTheThuVien { get => maTheThuVien; set => maTheThuVien = value; }
        public string TenDocGia { get => tenDocGia; set => tenDocGia = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string NhanVien { get => nhanVien; set => nhanVien = value; }
        public DateTime NgayDuTra { get => ngayDuTra; set => ngayDuTra = value; }
        public DateTime NgayThucTra { get => ngayThucTra; set => ngayThucTra = value; }
        public int SoNgayQuaHan { get => soNgayQuaHan; set => soNgayQuaHan = value; }
        public int TienPhat { get => tienPhat; set => tienPhat = value; }
    }
}
