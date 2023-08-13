using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using DataAccessLayer;
using System.Globalization;

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        BLL_NhanVien bLL_NhanVien = new BLL_NhanVien();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = bLL_NhanVien.hienThiNhanVien();
            radNam.Checked = true;

            dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns["HoTenNV"].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvNhanVien.Columns["DienThoai"].HeaderText = "Số điện thoại";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Close();
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
                DateTime ns = dtpNgaySinhNV.Value;
                //DateTime thisday = DateTime.Today;

                if (ns >= DateTime.Today)
                {
                    MessageBox.Show("Ngày sinh phải bé ngày hơn hiện tại");
                }
                else
                {
                    if (txtDienThoaiNV.Text == "" || txtHoTenNV.Text == "" || txtMaNV.Text == "" || txtDienThoaiNV.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                    }
                    else
                    {
                        DTO_NhanVien dto_NhanVien = new DTO_NhanVien(txtMaNV.Text, txtHoTenNV.Text, dtpNgaySinhNV.Value, gt, txtDienThoaiNV.Text);
                        if (bLL_NhanVien.CheckTonTai(dto_NhanVien))
                        {
                            MessageBox.Show("Đã tồn tại nhân viên này");
                        }
                        else
                        {
                            if (bLL_NhanVien.ThemNhanVien(dto_NhanVien) > 0)
                            {
                                MessageBox.Show("Thêm thành công");
                                dgvNhanVien.DataSource = bLL_NhanVien.hienThiNhanVien();
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
            DateTime ns = dtpNgaySinhNV.Value;

            if (ns >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh phải bé ngày hơn hiện tại");
            }
            else
            {
                DTO_NhanVien dto_NhanVien = new DTO_NhanVien(txtMaNV.Text, txtHoTenNV.Text, dtpNgaySinhNV.Value, gt, txtDienThoaiNV.Text);
                if (bLL_NhanVien.CheckTonTai(dto_NhanVien))
                {

                    if (bLL_NhanVien.SuaNhanVien(dto_NhanVien) > 0)
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvNhanVien.DataSource = bLL_NhanVien.hienThiNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên không tồn tại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaNV.Text;
            try
            {
                if (!string.IsNullOrEmpty(txtMaNV.Text) || !string.IsNullOrEmpty(txtHoTenNV.Text) || !string.IsNullOrEmpty(txtDienThoaiNV.Text))
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        if (bLL_NhanVien.XoaNhanVien(ma) == true)
                        {
                            MessageBox.Show("Xoá Thành Công");
                            dgvNhanVien.DataSource = bLL_NhanVien.hienThiNhanVien();
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
                    MessageBox.Show("Vui lòng chọn nhân viên để xoá");
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
        public void Reset()
        {
            txtDienThoaiNV.Text = "";
            txtHoTenNV.Text = "";
            txtMaNV.Text = "";
            dtpNgaySinhNV.ResetText();
            radNam.Checked = true;
        }

        private void txtDienThoaiNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            txtMaNV.Focus();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[index].Cells[0].Value.ToString();
            txtHoTenNV.Text = dgvNhanVien.Rows[index].Cells[1].Value.ToString();
            dtpNgaySinhNV.Text = dgvNhanVien.Rows[index].Cells[2].Value.ToString();
            if (dgvNhanVien.Rows[index].Cells[3].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            txtDienThoaiNV.Text = dgvNhanVien.Rows[index].Cells[4].Value.ToString();
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
