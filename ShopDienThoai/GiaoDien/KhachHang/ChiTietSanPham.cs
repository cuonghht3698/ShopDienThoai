using ShopQuanAo.GiaoDien.KhachHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopDienThoai.GiaoDien.KhachHang
{
    public partial class ChiTietSanPham : Form
    {
        public ChiTietSanPham(int id)
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            TrangChuKhachHang tc = new TrangChuKhachHang();
            tc.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
