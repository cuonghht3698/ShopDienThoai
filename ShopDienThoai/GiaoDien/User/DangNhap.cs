using ShopDienThoai.GiaoDien.User;
using ShopQuanAo.GiaoDien.KhachHang;
using ShopQuanAo.GiaoDien.NhanVien;
using ShopQuanAo.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopQuanAo.GiaoDien.User
{
    public partial class DangNhap : Form
    {
        private getData conn;
        public DangNhap()
        {
            InitializeComponent();
            conn = new getData();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            dk.ShowDialog();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            LoginAdmin();
        }

        private void LoginAdmin()
        {

            var read = conn.getDataTable("SELECT * FROM HTUser WHERE taikhoan = N'" + txtTaiKhoan.Text +
                "' and matkhau = '" + Ham.EncodePassword(txtMatKhau.Text) + "' and active = 'true'");
            if (read.Rows.Count > 0)
            {
                LuuThongTin.id = int.Parse(read.Rows[0][0].ToString());
                LuuThongTin.ten = read.Rows[0][1].ToString();
                LuuThongTin.ngaysinh = read.Rows[0][2].ToString();
                LuuThongTin.sdt = read.Rows[0][3].ToString();
                LuuThongTin.gioitinh = read.Rows[0][4].ToString() == "True" ? true : false;
                LuuThongTin.diachi = read.Rows[0][5].ToString();
                LuuThongTin.taikhoan = read.Rows[0][6].ToString();
                LuuThongTin.roleId = Int32.Parse(read.Rows[0][9].ToString());
                LuuThongTin.email = read.Rows[0][10].ToString();

                var role = conn.getDataTable("SELECT * FROM HTRole WHERE id = " + LuuThongTin.roleId);
                LuuThongTin.role = role.Rows[0][1].ToString();
                Console.WriteLine(LuuThongTin.role);
                this.Hide();
                if (LuuThongTin.role == "Khachhang")
                {
                    // KHACH HANG
                    TrangChuKhachHang trangChu = new TrangChuKhachHang();
                    trangChu.ShowDialog();
                }
                else
                {
                    // NHAN VIEN
                    TrangChuNhanVien trangChu = new TrangChuNhanVien();
                    trangChu.ShowDialog();
                }
               

            }
            else
            {
                lbLoginFailed.Text = "Tài khoản hoặc mật khẩu không đúng !";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "admin";
            txtMatKhau.Text = "admin";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "cuong";
            txtMatKhau.Text = "cuong";
        }

        private void btnQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau q = new QuenMatKhau();
            q.ShowDialog();
            this.Hide();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
