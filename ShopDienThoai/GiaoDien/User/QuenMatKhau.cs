using ShopDienThoai.Public;
using ShopQuanAo.GiaoDien.User;
using ShopQuanAo.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopDienThoai.GiaoDien.User
{
    public partial class QuenMatKhau : Form
    {
        private readonly getData cn;
        public QuenMatKhau()
        {
            InitializeComponent();
            cn = new getData();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            btnCheckCode.Enabled = false;
            btnXacNhan.Enabled = false;
        }
        private int IdUser = 0;
        private void CheckEmailUsername()
        {
            string email, username;
            email = txtEmail.Text;
            username = txtUsername.Text;
            var data = cn.getDataTable("select * from HTUser where active = 1 and email ='" + email + "' and taikhoan = '" + username + "'");
            if (data.Rows.Count > 0)
            {
                btnGuiMa.Enabled = true;
                btnCheckCode.Enabled = true;
                lbThongBao.Text = "";
                IdUser = Int32.Parse(data.Rows[0][0].ToString());
                TaoMaXacNhan();
                lbThongBao.Text = "";
            }
            else
            {
                btnGuiMa.Enabled = false;
                btnCheckCode.Enabled = false;
                lbThongBao.Text = "Email hoặc mật khẩu không đúng!";
                lbSuccess.Text = "";
            }
        }

        private void TaoMaXacNhan()
        {
            string code = "";
            string email, username;
            email = txtEmail.Text;
            username = txtUsername.Text;
            code = Ham.RamdomCode(6);
            cn.ExecuteNonQuery("UPDATE HTUser set Code = '" + code + "' where email = '" + email + "' and taikhoan = '" + username + "'");
            GuiMa(code);
        }
        private void CheckCode()
        {
            string code = txtCode.Text;
            string email, username;
            email = txtEmail.Text;
            username = txtUsername.Text;
            var data = cn.getDataTable("select * from HTUser where active = 1 and Code = '" + code + "' and email ='" + email + "' and taikhoan = '" + username + "'");
            if (data.Rows.Count > 0)
            {
                panel1.Visible = true;
                btnXacNhan.Enabled = true;
                lbSuccess.Text = "Mã xác nhận chính xác nhập mật khẩu mới!";
            }
            else
            {
                lbThongBao.Text = "Mã code không chính xác!";
                btnXacNhan.Enabled = false;
                panel1.Visible = false;
                lbSuccess.Text = "";

            }
        }
        private void GuiMa(string code)
        {
            string email = txtEmail.Text;
            string TieuDe = "Lấy lại mật khẩu Shop ....  ";
            string NoiDung = "Mã xác nhận của bạn là " + code;

            Email.Send(email, TieuDe, NoiDung);
            lbSuccess.Text = "Mã xác nhận đã được gửi vào email của bạn!";
        }

        private void DoiMatKhau()
        {
            string email, username, pass1, pass2;
            email = txtEmail.Text;
            username = txtUsername.Text;
            pass1 = txtPass1.Text;
            pass2 = txtPass2.Text;
            if (pass1.Length < 6 || pass2.Length < 6 || pass1 != pass2)
            {
                lbThongBao.Text = "Mật khẩu không hợp lệ!";
            }
            else
            {
                string password = Ham.EncodePassword(pass1);
                cn.ExecuteNonQuery("UPDATE HTUser set matkhau = '" + password + "' where email = '" + email + "' and taikhoan = '" + username + "'");
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                DangNhap d = new DangNhap();
                d.Show();
                this.Close();

            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            CheckCode();
        }

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            CheckEmailUsername();
        }



        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            DangNhap d = new DangNhap();
            d.Show();
            this.Close();
        }
    }
}
