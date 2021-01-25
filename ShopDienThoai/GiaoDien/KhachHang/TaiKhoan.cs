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

namespace ShopDienThoai.GiaoDien.KhachHang
{
    public partial class TaiKhoan : Form
    {
        private int id = LuuThongTin.id;
        private DataTable tb;
        private getData cn;
        private string passwordCu;
        public TaiKhoan()
        {
            InitializeComponent();
            cn = new getData();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            cbGioiTinh.SelectedIndex = 0;
            datePickNgaySinh.CustomFormat = "dd/MM/yyyy";
            getUser();
        }
        private void getUser()
        {
            tb = cn.getDataTable("select * from HTUser where id = " + id);
            txtTen.Text = tb.Rows[0][1].ToString();
            datePickNgaySinh.Value = DateTime.Parse(tb.Rows[0][2].ToString());
            txtSdt.Text = tb.Rows[0][3].ToString();
            cbGioiTinh.SelectedIndex = tb.Rows[0][4].ToString() == "True" ? 0 : 1;
            txtQueQuan.Text = tb.Rows[0][5].ToString();
            txtUsername.Text = tb.Rows[0][6].ToString();
            passwordCu = tb.Rows[0][7].ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                bool gt = cbGioiTinh.SelectedIndex == 0 ? true : false;
                cn.ExecuteNonQuery("UPDATE HTUSER  set ten = N'" + txtTen.Text + "',ngaysinh= '" + datePickNgaySinh.Value.ToString() + "',sdt= '" + txtSdt.Text +
                    "',gioitinh = '" + gt + "',diachi = N'" + txtQueQuan.Text + "' where id = " + id);
                MessageBox.Show("Thay đổi thông tin thành công", "Thông báo");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword2.Text == txtPassword3.Text)
                {
                    if (Ham.EncodePassword(txtPassword1.Text) == passwordCu)
                    {
                        cn.ExecuteNonQuery("UPDATE HTUSER set matkhau = N'" + Ham.EncodePassword(txtPassword2.Text) + "' where id = " + id);
                        MessageBox.Show("Thay đổi thông tin thành công", "Thông báo");
                        passwordCu = Ham.EncodePassword(txtPassword2.Text);
                        txtPassword2.Text = "";
                        txtPassword1.Text = "";
                        txtPassword3.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không trùng nhau", "Thông báo");

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
