using ShopDienThoai.GiaoDien.NhanVien;
using ShopQuanAo.GiaoDien.User;
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

namespace ShopQuanAo.GiaoDien.NhanVien
{
    public partial class TrangChuNhanVien : Form
    {
        public TrangChuNhanVien()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void TrangChuNhanVien_Load(object sender, EventArgs e)
        {
            lbTen.Text = LuuThongTin.ten;
            ClosePanel();
        }

        // HÀM XỬ LÝ
        private void ClosePanel()
        {
            panelDropDown1.Visible = false;
            panelDropDown2.Visible = false;
            panelDropDown3.Visible = false;
        }


        private Form activeForm = null;
        public void OpenForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        // END HÀM XỬ LÝ
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            
            ClosePanel();
            panelDropDown1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimeNow.Text = DateTime.Now.ToString();

        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            ClosePanel();
            panelDropDown2.Visible = true;
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            ClosePanel();
            panelDropDown3.Visible = true;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            OpenForm(new QLDienThoai());
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            OpenForm(new QLKho());
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            OpenForm(new QLNhaCungCap());
        }

        private void iconButton17_Click(object sender, EventArgs e)
        {
            OpenForm(new QLLoaiSanPham());

        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            OpenForm(new QLNhanVien());
        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            OpenForm(new QLKhachHang());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        { 
            this.Visible = false;
            DangNhap dk = new DangNhap();
            dk.ShowDialog();
        }
    }
}
