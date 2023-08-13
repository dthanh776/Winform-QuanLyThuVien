using BLL;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace GUI
{
    public partial class frmCapNhapSach : Form
    {
        public frmCapNhapSach()
        {
            InitializeComponent();
        }
        BLL_NhaXuatBan bll_nxb = new BLL_NhaXuatBan();
        BLL_TacGia bll_tacGia = new BLL_TacGia();
        BLL_TheLoai bll_theLoai = new BLL_TheLoai();
        BLL_Sach bLL_Sach = new BLL_Sach();


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCapNhapSach_FormClosing(object sender, FormClosingEventArgs e)
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

        public void hienThiCbb()
        {
            // Nha xuat ban
            cbbNhaXuatBan.DataSource = bll_nxb.getData();
            cbbNhaXuatBan.DisplayMember = "TenNXB"; // MaNXB
            cbbNhaXuatBan.ValueMember = "MaNXB"; // TenNXB

            // Tac gia
            cbbTacGia.DataSource = bll_tacGia.hienThiTacGia();
            cbbTacGia.DisplayMember = "HoTenTG"; // MaTacGia
            cbbTacGia.ValueMember = "MaTacGia"; // HoTenTG

            // The Loai
            cbbTheLoai.DataSource = bll_theLoai.hienThiTheLoai();
            cbbTheLoai.DisplayMember = "TenTheThoai"; // MaTheLoai
            cbbTheLoai.ValueMember = "MaTheLoai"; // TenTheThoai
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSach.Text == "" || txtNamXuatBan.Text == "" || txtTenSach.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    DTO_Sach sach = new DTO_Sach(txtMaSach.Text, txtTenSach.Text, int.Parse(txtNamXuatBan.Text),
                        cbbNhaXuatBan.SelectedValue.ToString(), cbbTheLoai.SelectedValue.ToString(), cbbTacGia.SelectedValue.ToString());
                    if (bLL_Sach.CheckTonTai(sach))
                    {
                        MessageBox.Show("Đã tồn tại sách này");
                    }
                    else
                    {
                        if (bLL_Sach.ThemSach(sach))
                        {
                            MessageBox.Show("Thêm thành công");
                            dtgSach.DataSource = bLL_Sach.hienThiSach();
                            Reset();
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

        private void frmCapNhapSach_Load(object sender, EventArgs e)
        {
            Size = new Size(930, 652);
            //fillData();
            hienThiCbb();
            dtgSach.DataSource = bLL_Sach.hienThiSach();
            dtgSach.Columns["MaSach"].HeaderText = "Mã sách";
            dtgSach.Columns["TenSach"].HeaderText = "Tên sách";
            dtgSach.Columns["NamXuatBan"].HeaderText = "Năm xuất bản";
            dtgSach.Columns["MaNXB"].HeaderText = "Mã nhà xuất bản";
            dtgSach.Columns["MaTheLoai"].HeaderText = "Mã thể loại";
            dtgSach.Columns["MaTacGia"].HeaderText = "Mã tác giả";
        }
        public void Reset()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtNamXuatBan.Text = "";
            cbbNhaXuatBan.SelectedIndex = 0;
            cbbTacGia.SelectedIndex = 0;
            cbbTheLoai.SelectedIndex = 0;
            txtTim.Text = "";
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgSach.CurrentCell.RowIndex;
            txtMaSach.Text = dtgSach.Rows[index].Cells[0].Value.ToString();
            txtTenSach.Text = dtgSach.Rows[index].Cells[1].Value.ToString();
            txtNamXuatBan.Text = dtgSach.Rows[index].Cells[2].Value.ToString();
            cbbNhaXuatBan.SelectedValue = dtgSach.Rows[index].Cells[3].Value.ToString();
            cbbTheLoai.SelectedValue = dtgSach.Rows[index].Cells[4].Value.ToString();
            cbbTacGia.SelectedValue = dtgSach.Rows[index].Cells[5].Value.ToString();
        }
        public void fillData()
        {
            dtgSach.ColumnCount = 6;
            dtgSach.Columns[0].HeaderText = "Mã sách";
            dtgSach.Columns[1].HeaderText = "Tên sách";
            dtgSach.Columns[2].HeaderText = "Năm xuất bản";
            dtgSach.Columns[3].HeaderText = "Nhà xuất bản";
            dtgSach.Columns[4].HeaderText = "Thể loại";
            dtgSach.Columns[5].HeaderText = "Tác giả";
        }

        private void txtNamXuatBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_Sach sach = new DTO_Sach(txtMaSach.Text, txtTenSach.Text, int.Parse(txtNamXuatBan.Text),
    cbbNhaXuatBan.SelectedValue.ToString(), cbbTheLoai.SelectedValue.ToString(), cbbTacGia.SelectedValue.ToString());
            if (bLL_Sach.CheckTonTai(sach))
            {
                if (bLL_Sach.SuaSach(sach))
                {
                    MessageBox.Show("Sửa thành công");
                    dtgSach.DataSource = bLL_Sach.hienThiSach();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại sách này");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text;
            try
            {
                if (!string.IsNullOrEmpty(txtMaSach.Text))
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        if (bLL_Sach.XoaSach(ma) == true)
                        {
                            MessageBox.Show("Xoá Thành Công");
                            dtgSach.DataSource = bLL_Sach.hienThiSach();
                            Reset();
                        }
                        else
                        {
                            MessageBox.Show("Xoá Không Thành Công");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sách để xoá");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            txtMaSach.Focus();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            dtgSach.DataSource = bLL_Sach.TimSach(txtTim.Text);
        }

        private void txtNamXuatBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbNhaXuatBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
