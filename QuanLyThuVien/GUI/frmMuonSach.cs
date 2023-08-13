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
    public partial class frmMuonSach : Form
    {
        public frmMuonSach()
        {
            InitializeComponent();
        }
        BLL_NhanVien bLL_NhanVien = new BLL_NhanVien();
        BLL_Sach bLL_Sach = new BLL_Sach();
        BLL_TheThuVien bLL_TheThuVien = new BLL_TheThuVien();
        BLL_MuonSach bLL_MuonSach = new BLL_MuonSach();

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmaMuonSach.Text == "" || txtMaThe.Text == "" || txtTenDocGia.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {  // dtpNgaySinhDocGia.Value, gt, cbbSach.SelectedValue.ToString(),
                    DTO_MuonSach muonSach = new DTO_MuonSach(txtmaMuonSach.Text, txtMaThe.Text, txtTenDocGia.Text, cbbTenSach.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString(), dtpNgayMuon.Value, dtpNgayTra.Value, "Đang mượn");
                    if (bLL_MuonSach.CheckTonTai(muonSach))
                    {
                        MessageBox.Show("Đã tồn tại mã mượn sách này");
                    }
                    else
                    {
                        if (bLL_MuonSach.ThemMuonSach(muonSach) > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                            dtaMuonSach.DataSource = bLL_MuonSach.hienThiMuonSach();
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

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            dtaMuonSach.DataSource = bLL_MuonSach.hienThiMuonSach();
            hienThiCbb();

            dtaMuonSach.Columns["MaMuonSach"].HeaderText = "Mã mượn sách";
            dtaMuonSach.Columns["MaTheThuVien"].HeaderText = "Thẻ thư viện";
            dtaMuonSach.Columns["HoTenDocGia"].HeaderText = "Tên độc giả";
            dtaMuonSach.Columns["MaSach"].HeaderText = "Mã sách";
            dtaMuonSach.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dtaMuonSach.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            dtaMuonSach.Columns["NgayTra"].HeaderText = "Ngày trả";
            dtaMuonSach.Columns["TrangThai"].HeaderText = "Trạng thái";
        }
        public void hienThiCbb()
        {
            // Doc Gia
            cbbNhanVien.DataSource = bLL_NhanVien.hienThiNhanVien();
            cbbNhanVien.DisplayMember = "HoTenNV"; // MaNhanVien
            cbbNhanVien.ValueMember = "MaNhanVien"; // HoTenNV
            // Ten Sach
            cbbTenSach.DataSource = bLL_Sach.hienThiSach();
            cbbTenSach.DisplayMember = "TenSach"; // MaSach
            cbbTenSach.ValueMember = "MaSach"; // TenSach

        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            txtmaMuonSach.Text = "";
            txtMaThe.Text = "";
            txtTenDocGia.Text = "";
            cbbTenSach.SelectedIndex = 0;
            dtpNgayMuon.ResetText();
            cbbNhanVien.SelectedIndex = 0;
            dtpNgayTra.ResetText();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable data = bLL_MuonSach.layTenDocGia(txtMaThe.Text);
            DTO_MuonSach muonSach = new DTO_MuonSach(txtmaMuonSach.Text, txtMaThe.Text, txtTenDocGia.Text, cbbTenSach.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString(), dtpNgayMuon.Value, dtpNgayTra.Value, "Đang mượn");

            if (bLL_MuonSach.checkTonTaiMaThe(txtMaThe.Text))
            {
                txtTenDocGia.Text = data.Rows[0]["HoTenDocGia"].ToString();
                dtaMuonSach.DataSource = bLL_MuonSach.hienThiMuonSach();
            }
            else
            {
                MessageBox.Show("Mã thẻ thư viện chưa đúng");
                Reset();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMuonSach_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dtaMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtaMuonSach.CurrentCell.RowIndex;
            txtmaMuonSach.Text = dtaMuonSach.Rows[index].Cells[0].Value.ToString();
            txtMaThe.Text = dtaMuonSach.Rows[index].Cells[1].Value.ToString();
            txtTenDocGia.Text = dtaMuonSach.Rows[index].Cells[2].Value.ToString();
            cbbTenSach.SelectedValue = dtaMuonSach.Rows[index].Cells[3].Value.ToString();
            cbbNhanVien.SelectedValue = dtaMuonSach.Rows[index].Cells[4].Value.ToString();
            dtpNgayMuon.Text = dtaMuonSach.Rows[index].Cells[5].Value.ToString();
            dtpNgayTra.Text = dtaMuonSach.Rows[index].Cells[6].Value.ToString();
        }
    }
}
