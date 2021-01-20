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

namespace ShopQuanAo.GiaoDien.User
{
    public partial class DangKy : Form
    {
        private getData conn;
        public DangKy()
        {
            InitializeComponent();
            conn = new getData();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            cbGioiTinh.SelectedIndex = 0;
            dateNgaySinh.CustomFormat = "dd/MM/yyyy";
        }


        private void TaiTaiKhoan()
        {
            try
            {
                string ten, ngaysinh, sdt, quequan, username, password;
                int quyen;
                bool active = true;
                bool gioitinh;
                ten = txtHoTen.Text;
                ngaysinh = dateNgaySinh.Value.ToString();
                gioitinh = cbGioiTinh.SelectedItem.ToString() == "Nam" ? true : false;
                sdt = txtSDT.Text;
                quequan = txtDiaChi.Text;
                username = txtTaiKhoan.Text;
                password = Ham.EncodePassword(txtMatKhau.Text);
                quyen = 3;
                if (!String.IsNullOrEmpty(txtHoTen.Text) && !String.IsNullOrEmpty(txtMatKhau.Text) && !String.IsNullOrEmpty(txtTaiKhoan.Text))
                {
                    if (txtMatKhau2.Text == txtMatKhau.Text)
                    {
                        if (!CheckUsername(username))
                        {
                            MessageBox.Show("Tài khoản đã tồn tại trong hệ thống!", "Thông báo!");
                        }
                        else
                        {
                            string sql = "Insert into HTUser (ten,ngaysinh,sdt,gioitinh,diachi,taikhoan,matkhau,active,roleId) values(N'" + ten +
                              "','" + ngaysinh + "','" + sdt + "','" + gioitinh + "',N'" + quequan + "','" + username + "','" + password + "','" + active + "'," + quyen + ")";
                            conn.ExecuteNonQuery(sql);
                            MessageBox.Show("Tạo tài khoản thành công!", "Thông báo");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không khớp!", "Thông báo!");
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại thông tin!", "Thông báo!");

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Kiểm tra lại thông tin!", "Thông báo!");
            }
        }
        private bool CheckUsername(string username)
        {
            string sql = "select * from HTUser where taikhoan = N'" + username + "'";
            var tb = conn.getDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            TaiTaiKhoan();
        }
    }
}
