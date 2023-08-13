using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TheLoai
    {
        private string maTheLoai;
        private string tenTheLoai;

        public DTO_TheLoai(string maTheLoai, string tenTheLoai)
        {
            this.MaTheLoai = maTheLoai;
            this.TenTheLoai = tenTheLoai;
        }

        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }
    }
}
