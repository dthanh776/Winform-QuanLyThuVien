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
    public partial class frmTheThuVien : Form
    {

        public frmTheThuVien()
        {
            InitializeComponent();
        }

        BLL_Sach bLL_Sach = new BLL_Sach();
        BLL_NhanVien bLL_NhanVien = new BLL_NhanVien();
        BLL_TheThuVien bLL_TheThuVien = new BLL_TheThuVien();

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDocGia_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gt;
            if (radNam.Checked == true)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            try
            {
                DateTime ns = dtpNgaySinhDocGia.Value;
                //DateTime thisday = DateTime.Today;

                if (ns >= DateTime.Today)
                {
                    MessageBox.Show("Ngày sinh phải bé ngày hơn hiện tại");
                }
                else
                {
                    if (txtMaThe.Text == "" || txtTenDocGia.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                    }
                    else
                    {
                        DTO_TheThuVien dto_theThuVien = new DTO_TheThuVien(txtMaThe.Text, txtTenDocGia.Text, dtpNgaySinhDocGia.Value, gt, cbbSach.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString());
                        if (bLL_TheThuVien.CheckTonTai(dto_theThuVien))
                        {
                            MessageBox.Show("Đã tồn tại thẻ thư viện này");
                        }
                        else
                        {
                            if (bLL_TheThuVien.ThemTheThuVien(dto_theThuVien) > 0)
                            {
                                MessageBox.Show("Thêm thành công");
                                dgvTheThuVien.DataSource = bLL_TheThuVien.hienThiTheThuVien();
                                Reset();
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void hienThiCbb()
        {
            // Nhan Vien
            cbbNhanVien.DataSource = bLL_NhanVien.hienThiNhanVien();
            cbbNhanVien.DisplayMember = "HoTenNV"; // MaNhanVien
            cbbNhanVien.ValueMember = "MaNhanVien"; // HoTenNV

            // Sach
            cbbSach.DataSource = bLL_Sach.hienThiSach();
            cbbSach.DisplayMember = "TenSach"; // MaSach
            cbbSach.ValueMember = "MaSach"; // TenSach
        }

        private void frmTheThuVien_Load(object sender, EventArgs e)
        {
            dgvTheThuVien.DataSource = bLL_TheThuVien.hienThiTheThuVien();
            hienThiCbb();
            radNam.Checked = true;

            dgvTheThuVien.Columns["MaTheThuVien"].HeaderText = "Mã thẻ thư viện ";
            dgvTheThuVien.Columns["HoTenDocGia"].HeaderText = "Tên độc giả ";
            dgvTheThuVien.Columns["NgaySinh"].HeaderText = "Ngày sinh ";
            dgvTheThuVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvTheThuVien.Columns["MaSach"].HeaderText = "Sách yêu thích";
            dgvTheThuVien.Columns["MaNhanVien"].HeaderText = "Nhân viên tạo";
        }
        public void Reset()
        {
            txtMaThe.Text = "";
            txtTenDocGia.Text = "";
            cbbNhanVien.SelectedIndex = 0;
            cbbSach.SelectedIndex = 0;
            dtpNgaySinhDocGia.ResetText();
            radNam.Checked = true;
        }

        private void dgvTheThuVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvTheThuVien.CurrentCell.RowIndex;
            txtMaThe.Text = dgvTheThuVien.Rows[index].Cells[0].Value.ToString();
            txtTenDocGia.Text = dgvTheThuVien.Rows[index].Cells[1].Value.ToString();
            dtpNgaySinhDocGia.Text = dgvTheThuVien.Rows[index].Cells[2].Value.ToString();
            if (dgvTheThuVien.Rows[index].Cells[3].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            cbbSach.SelectedValue = dgvTheThuVien.Rows[index].Cells[4].Value.ToString();
            cbbNhanVien.SelectedValue = dgvTheThuVien.Rows[index].Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (radNam.Checked == true)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            DTO_TheThuVien dto_theThuVien = new DTO_TheThuVien(txtMaThe.Text, txtTenDocGia.Text, dtpNgaySinhDocGia.Value, gt, cbbSach.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString());
            try
            {
                DateTime ns = dtpNgaySinhDocGia.Value;
                if (ns >= DateTime.Today)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại");
                }
                else
                {
                    if (txtMaThe.Text == "" || txtTenDocGia.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                    }
                    else
                    {
                        if (bLL_TheThuVien.SuaTheThuVien(dto_theThuVien) > 0)
                        {
                            MessageBox.Show("Sửa thành công");
                            dgvTheThuVien.DataSource = bLL_TheThuVien.hienThiTheThuVien();
                            Reset();
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaThe.Text;
            string gt;
            if (radNam.Checked == true)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            DTO_TheThuVien dto_theThuVien = new DTO_TheThuVien(txtMaThe.Text, txtTenDocGia.Text, dtpNgaySinhDocGia.Value, gt, cbbSach.SelectedValue.ToString(), cbbNhanVien.SelectedValue.ToString());
            try
            {
                DateTime ns = dtpNgaySinhDocGia.Value;
                if (ns >= DateTime.Today)
                {
                    MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại");
                }
                else
                {
                    if (txtMaThe.Text == "" || txtTenDocGia.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                    }
                    else
                    {
                        DialogResult kq = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (bLL_TheThuVien.XoaTheThuVien(ma) == true)
                        {
                            MessageBox.Show("Xoá thành công");
                            dgvTheThuVien.DataSource = bLL_TheThuVien.hienThiTheThuVien();
                            Reset();
                        }
                        else
                        {
                            MessageBox.Show("Xoá thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
