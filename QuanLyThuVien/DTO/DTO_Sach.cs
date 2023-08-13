using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Sach
    {
        private string maSach;
        private string tenSach;
        private int namXuatBan;
        private string maNXB;
        private string maTheLoai;
        private string maTacGia;

        public DTO_Sach(string maSach, string tenSach, int namXuatBan, string maNXB, string maTheLoai, string maTacGia)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.namXuatBan = namXuatBan;
            this.maNXB = maNXB;
            this.maTheLoai = maTheLoai;
            this.maTacGia = maTacGia;
        }

        public string MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public int NamXuatBan { get => namXuatBan; set => namXuatBan = value; }
        public string MaNXB { get => maNXB; set => maNXB = value; }
        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string MaTacGia { get => maTacGia; set => maTacGia = value; }
    }
}
