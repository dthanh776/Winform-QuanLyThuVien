using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_MuonSach
    {
        private string maMuonSach;
        private string maTheThuVien;
        private string tenDocGia;
        private string tenSach;
        private string nhanVien;
        private DateTime ngayMuon;
        private DateTime ngayTra;
        private string trangThai;

        public DTO_MuonSach(string maMuonSach, string maTheThuVien, string tenDocGia, string tenSach, string nhanVien, DateTime ngayMuon, DateTime ngayTra, string trangThai)
        {
            this.MaMuonSach = maMuonSach;
            this.MaTheThuVien = maTheThuVien;
            this.TenDocGia = tenDocGia;
            this.TenSach = tenSach;
            this.NhanVien = nhanVien;
            this.NgayMuon = ngayMuon;
            this.NgayTra = ngayTra;
            this.TrangThai = trangThai;
        }

        public string MaMuonSach { get => maMuonSach; set => maMuonSach = value; }
        public string MaTheThuVien { get => maTheThuVien; set => maTheThuVien = value; }
        public string TenDocGia { get => tenDocGia; set => tenDocGia = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string NhanVien { get => nhanVien; set => nhanVien = value; }
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
