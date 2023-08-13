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
    public partial class frmNhaXuatBan : Form
    {
        public frmNhaXuatBan()
        {
            InitializeComponent();
        }
        BLL_NhaXuatBan bll_nxb = new BLL_NhaXuatBan();


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text == "" || txtTen.Text == "" || txtSdt.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    DTO_NXB nxb = new DTO_NXB(txtMa.Text, txtTen.Text, txtSdt.Text);
                    if (bll_nxb.CheckTonTai(nxb))
                    {
                        MessageBox.Show("Đã tồn tại nhà xuất bản này");
                    }
                    else
                    {
                        if (bll_nxb.ThemNXB(nxb) > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                            dtgNXB.DataSource = bll_nxb.getData();
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

        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            dtgNXB.DataSource = bll_nxb.getData();
            dtgNXB.Columns["MaNXB"].HeaderText = "Mã nhà xuất bản";
            dtgNXB.Columns["TenNXB"].HeaderText = "Tên nhà xuất bản";
            dtgNXB.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
        }


        private void dtgNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgNXB.CurrentCell.RowIndex;
            txtMa.Text = dtgNXB.Rows[index].Cells[0].Value.ToString();
            txtTen.Text = dtgNXB.Rows[index].Cells[1].Value.ToString();
            txtSdt.Text = dtgNXB.Rows[index].Cells[2].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_NXB nxb = new DTO_NXB(txtMa.Text, txtTen.Text, txtSdt.Text);
            if (bll_nxb.CheckTonTai(nxb))
            {
                if (bll_nxb.SuaNXB(nxb) > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    dtgNXB.DataSource = bll_nxb.getData();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            else
            {
                MessageBox.Show("Nhà xuất bản không tồn tại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            try
            {
                if (!string.IsNullOrEmpty(txtMa.Text) || !string.IsNullOrEmpty(txtTen.Text) || !string.IsNullOrEmpty(txtSdt.Text))
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        if (bll_nxb.XoaNXB(ma) == true)
                        {
                            MessageBox.Show("Xoá Thành Công");
                            dtgNXB.DataSource = bll_nxb.getData();
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
                    MessageBox.Show("Vui lòng chọn nhà xuất bản để xoá");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Reset()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtSdt.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmNhaXuatBan_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
