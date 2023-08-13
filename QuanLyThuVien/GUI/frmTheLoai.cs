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
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        BLL_TheLoai bll_theLoai = new BLL_TheLoai();

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTheLoai.Text == "" || txtTenTheLoai.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                }
                else
                {
                    DTO_TheLoai theLoai = new DTO_TheLoai(txtMaTheLoai.Text, txtTenTheLoai.Text);
                    if (bll_theLoai.CheckTonTai(theLoai))
                    {
                        MessageBox.Show("Đã tồn tại thể loại này");
                    }
                    else
                    {
                        if (bll_theLoai.ThemTheLoai(theLoai) > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                            dtaTheLoai.DataSource = bll_theLoai.hienThiTheLoai();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_TheLoai nxb = new DTO_TheLoai(txtMaTheLoai.Text, txtTenTheLoai.Text);
            if (bll_theLoai.SuaTheLoai(nxb) > 0)
            {
                MessageBox.Show("Sửa thành công");
                dtaTheLoai.DataSource = bll_theLoai.hienThiTheLoai();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaTheLoai.Text;
            try
            {
                if (!string.IsNullOrEmpty(txtMaTheLoai.Text) || !string.IsNullOrEmpty(txtTenTheLoai.Text))
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        if (bll_theLoai.XoaTheLoai(ma) == true)
                        {
                            MessageBox.Show("Xoá Thành Công");
                            dtaTheLoai.DataSource = bll_theLoai.hienThiTheLoai();
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
                    MessageBox.Show("Vui lòng chọn thể loại để xoá");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            dtaTheLoai.DataSource = bll_theLoai.hienThiTheLoai();
            dtaTheLoai.Columns["MaTheLoai"].HeaderText = "Mã thể loại ";
            dtaTheLoai.Columns["TenTheThoai"].HeaderText = "Tên thể loại ";
        }


        private void frmTheLoai_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dtaTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtaTheLoai.CurrentCell.RowIndex;
            txtMaTheLoai.Text = dtaTheLoai.Rows[index].Cells[0].Value.ToString();
            txtTenTheLoai.Text = dtaTheLoai.Rows[index].Cells[1].Value.ToString();
        }

        public void Reset()
        {
            txtMaTheLoai.Text = "";
            txtTenTheLoai.Text = "";
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

    }
}
