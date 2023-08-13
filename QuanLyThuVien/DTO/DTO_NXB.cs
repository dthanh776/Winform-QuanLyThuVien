using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NXB
    {
        private string maNXB;
        private string tenNXB;
        private string soDienThoai;

        public DTO_NXB(string maNXB, string tenNXB, string soDienThoai)
        {
            this.MaNXB = maNXB;
            this.TenNXB = tenNXB;
            this.SoDienThoai = soDienThoai;
        }

        public string MaNXB { get => maNXB; set => maNXB = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
    }
}
