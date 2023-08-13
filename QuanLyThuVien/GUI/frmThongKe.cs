using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frmThongKe : Form
    {
        BLL_ThongKe bLL_ThongKe = new BLL_ThongKe();
        public frmThongKe()
        {
            InitializeComponent();
        }
        public void combobox1()
        {
            DataTable data = bLL_ThongKe.SachDangDuocMuon();
            if (data != null)
            {
                dtaThongKe.DataSource = data;
            }
            dtaThongKe.Columns[0].HeaderText = "Họ tên độc giả";
            dtaThongKe.Columns[1].HeaderText = "Mã sách";
            dtaThongKe.Columns[2].HeaderText = "Tên sách";
            dtaThongKe.Columns[3].HeaderText = "Năm xuất bản";
            dtaThongKe.Columns[4].HeaderText = "Họ tên tác giả";
        }
        public void combobox2()
        {
            DataTable data = bLL_ThongKe.DocGiaQuaHanTraSach();
            if (data != null)
            {
                dtaThongKe.DataSource = data;
            }
            dtaThongKe.Columns[0].HeaderText = "Họ tên độc giả";
            dtaThongKe.Columns[1].HeaderText = "Mã sách";
            dtaThongKe.Columns[2].HeaderText = "Tên sách";
            dtaThongKe.Columns[3].HeaderText = "Ngày trả";
            dtaThongKe.Columns[4].HeaderText = "Số ngày quá hạn";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbbThongKe.Text == "Độc giả đang mượn sách")
            {
                combobox1();
            }
            else if (cbbThongKe.Text ==  "Độc giả quá hạn trả sách")
            {
                combobox2();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongKe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
