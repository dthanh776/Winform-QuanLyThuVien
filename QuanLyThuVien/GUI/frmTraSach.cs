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
    public partial class frmTraSach : Form
    {
        public frmTraSach()
        {
            InitializeComponent();
        }
        BLL_NhanVien bLL_NhanVien = new BLL_NhanVien();
        BLL_TraSach bLL_TraSach = new BLL_TraSach();

        private void frmTraSach_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTraSach_Load(object sender, EventArgs e)
        {
            dtaTraSach.DataSource = bLL_TraSach.hienThiTraSach();
            hienThiCbb();

            dtaTraSach.Columns["MaTraSach"].HeaderText = "Mã trả sách";
            dtaTraSach.Columns["MaMuonSach"].HeaderText = "Mã mượn sách";
            dtaTraSach.Columns["MaTheThuVien"].HeaderText = "Thẻ thư viện";
            dtaTraSach.Columns["HoTenDocGia"].HeaderText = "Tên độc giả";
            dtaTraSach.Columns["MaSach"].HeaderText = "Mã sách";
            dtaTraSach.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dtaTraSach.Columns["NgayDuTra"].HeaderText = "Ngày trả dự kiến";
            dtaTraSach.Columns["NgayThucTra"].HeaderText = "Ngày trả thực tế";
            dtaTraSach.Columns["SoNgayQuaHan"].HeaderText = "Số ngày quá hạn";
            dtaTraSach.Columns["Tienphat"].HeaderText = "Tiền phạt";
        }
        public void hienThiCbb()
        {
            // Doc Gia
            cbbNhanVien.DataSource = bLL_NhanVien.hienThiNhanVien();
            cbbNhanVien.DisplayMember = "HoTenNV"; // MaNhanVien
            cbbNhanVien.ValueMember = "MaNhanVien"; // HoTenNV
            // Ten Sach

        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            txtMaMuonSach.Text = "";
            txtMaTheThuVien.Text = "";
            txtMaTraSach.Text = "";
            txtSoNgayQuaHan.Text = "";
            txtTenDocGia.Text = "";
            txtTenSach.Text = "";
            txtTienPhat.Text = "";
            cbbNhanVien.SelectedIndex = 0;
            dtaNgayDuTra.ResetText();
            dtaNgayThucTra.ResetText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable data = bLL_TraSach.layTenMuonSach(txtMaMuonSach.Text);

            if (bLL_TraSach.checkTonTaiMuonSach(txtMaMuonSach.Text))
            {
                txtTenSach.Text = data.Rows[0]["MaSach"].ToString();
                dtaNgayDuTra.Text = data.Rows[0]["NgayTra"].ToString();
                txtMaTheThuVien.Text = data.Rows[0]["MaTheThuVien"].ToString();
                txtTenDocGia.Text = data.Rows[0]["HoTenDocGia"].ToString();
            }
            else
            {
                MessageBox.Show("Mã mượn sách chưa đúng");
                Reset();
            }

            ChenhLechNgay();
            TienPhat();
        }
        public void TienPhat()
        {
            int tienPhat = int.Parse(txtSoNgayQuaHan.Text) * 5000;
            if (tienPhat < 0)
            {
                txtTienPhat.Text = 0.ToString();
            }
            else
            {
                txtTienPhat.Text = tienPhat.ToString();
            }
        }
        public void ChenhLechNgay()
        {
            DateTime ngayThucTra = dtaNgayThucTra.Value.Date;
            DateTime ngayDuTra = dtaNgayDuTra.Value.Date;
            TimeSpan chenhLech = ngayThucTra - ngayDuTra;
            int days = chenhLech.Days;

            if (days < 0)
            {
                txtSoNgayQuaHan.Text = 0.ToString();
            }
            else
            {
                txtSoNgayQuaHan.Text = days.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaMuonSach.Text == "" || txtMaTraSach.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {  // dtpNgaySinhDocGia.Value, gt, cbbSach.SelectedValue.ToString(),
                    DTO_TraSach traSach = new DTO_TraSach(txtMaTraSach.Text, txtMaMuonSach.Text, txtMaTheThuVien.Text, txtTenDocGia.Text,
                        txtTenSach.Text, cbbNhanVien.SelectedValue.ToString(), dtaNgayDuTra.Value, dtaNgayThucTra.Value, int.Parse(txtSoNgayQuaHan.Text), int.Parse(txtTienPhat.Text));
                    if (bLL_TraSach.CheckTonTai(traSach))
                    {
                        MessageBox.Show("Đã tồn tại mã trả sách này");
                    }
                    else
                    {
                        if (bLL_TraSach.ThemTraSach(traSach) > 0)
                        {
                            bLL_TraSach.SuaTrangThai(traSach.MaMuonSach);
                            MessageBox.Show("Thêm thành công");
                            dtaTraSach.DataSource = bLL_TraSach.hienThiTraSach();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtaTraSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtaTraSach.CurrentCell.RowIndex;
            txtMaTraSach.Text = dtaTraSach.Rows[index].Cells[0].Value.ToString();
            txtMaMuonSach.Text = dtaTraSach.Rows[index].Cells[1].Value.ToString();
            txtMaTheThuVien.Text = dtaTraSach.Rows[index].Cells[2].Value.ToString();
            txtTenDocGia.Text = dtaTraSach.Rows[index].Cells[3].Value.ToString();
            txtTenSach.Text = dtaTraSach.Rows[index].Cells[4].Value.ToString();
            cbbNhanVien.SelectedValue = dtaTraSach.Rows[index].Cells[5].Value.ToString();
            dtaNgayDuTra.Text = dtaTraSach.Rows[index].Cells[6].Value.ToString();
            dtaNgayThucTra.Text = dtaTraSach.Rows[index].Cells[7].Value.ToString();
            txtSoNgayQuaHan.Text = dtaTraSach.Rows[index].Cells[8].Value.ToString();
            txtTienPhat.Text = dtaTraSach.Rows[index].Cells[9].Value.ToString();
        }
    }
}
