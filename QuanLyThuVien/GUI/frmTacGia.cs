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
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
            InitializeComponent();
        }
        BLL_TacGia bll_tacgia = new BLL_TacGia();

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTacGia.Text == "" || txtTenTacGia.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    DTO_TacGia tacGia = new DTO_TacGia(txtMaTacGia.Text, txtTenTacGia.Text);
                    if (bll_tacgia.CheckTonTai(tacGia))
                    {
                        MessageBox.Show("Đã tồn tại tác giả này");
                    }
                    else
                    {
                        if (bll_tacgia.ThemTacGia(tacGia) > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                            dtaTacGia.DataSource = bll_tacgia.hienThiTacGia();
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

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            dtaTacGia.DataSource = bll_tacgia.hienThiTacGia();
            txtMaTacGia.Focus();
            dtaTacGia.Columns["MaTacGia"].HeaderText = "Mã tác giả";
            dtaTacGia.Columns["HoTenTG"].HeaderText = "Họ tên tác giả";

        }

        private void dtaTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtaTacGia.CurrentCell.RowIndex;
            txtMaTacGia.Text = dtaTacGia.Rows[index].Cells[0].Value.ToString();
            txtTenTacGia.Text = dtaTacGia.Rows[index].Cells[1].Value.ToString();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_TacGia nxb = new DTO_TacGia(txtMaTacGia.Text, txtTenTacGia.Text);
            if (bll_tacgia.SuaTacGia(nxb) > 0)
            {
                MessageBox.Show("Sửa thành công");
                dtaTacGia.DataSource = bll_tacgia.hienThiTacGia();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaTacGia.Text;
            try
            {
                if (!string.IsNullOrEmpty(txtMaTacGia.Text) || !string.IsNullOrEmpty(txtTenTacGia.Text))
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        if (bll_tacgia.XoaTacGia(ma) == true)
                        {
                            MessageBox.Show("Xoá Thành Công");
                            dtaTacGia.DataSource = bll_tacgia.hienThiTacGia();
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
                    MessageBox.Show("Vui lòng chọn tác giả để xoá");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Reset()
        {
            txtMaTacGia.Text = "";
            txtTenTacGia.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTacGia_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
