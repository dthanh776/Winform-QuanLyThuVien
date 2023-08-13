using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TacGia
    {
        private string maTacGia;
        private string tenTacGia;

        public DTO_TacGia(string maTacGia, string tenTacGia)
        {
            this.MaTacGia = maTacGia;
            this.TenTacGia = tenTacGia;
        }

        public string MaTacGia { get => maTacGia; set => maTacGia = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }
    }
}
