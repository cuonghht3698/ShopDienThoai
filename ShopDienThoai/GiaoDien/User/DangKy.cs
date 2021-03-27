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
        private int quyen;
        public DangKy()
        {
            InitializeComponent();
            conn = new getData();
            quyen = 3;
            lbQuyen.Visible = false;
            cbQuyen.Visible = false;
        }
        public DangKy(bool checkAdmin)
        {
            InitializeComponent();
            conn = new getData();

        }
        private void DangKy_Load(object sender, EventArgs e)
        {
            cbGioiTinh.SelectedIndex = 0;
            cbQuyen.SelectedIndex = 0;
            dateNgaySinh.CustomFormat = "dd/MM/yyyy";
            getQuyen();
        }

        private void getQuyen()
        {
            var data = conn.getDataTable("select (convert(varchar,id) + ' -' + ten) as 'quyen' from HTRole");
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    cbQuyen.Items.Add(item[0].ToString());

                }
            }
        }
        private void TaiTaiKhoan()
        {
            try
            {
                string ten, ngaysinh, sdt, quequan, username, password,email;
               
                bool active = true;
                bool gioitinh;
                ten = txtHoTen.Text;
                ngaysinh = dateNgaySinh.Value.ToString();
                gioitinh = cbGioiTinh.SelectedItem.ToString() == "Nam" ? true : false;
                sdt = txtSDT.Text;
                quequan = txtDiaChi.Text;
                username = txtTaiKhoan.Text;
                password = Ham.EncodePassword(txtMatKhau.Text);
                email = txtEmail.Text;
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
                            string sql = "Insert into HTUser (ten,ngaysinh,sdt,gioitinh,diachi,taikhoan,matkhau,active,roleId,email) values(N'" + ten +
                              "','" + ngaysinh + "','" + sdt + "','" + gioitinh + "',N'" + quequan + "','" + username + "','" + password + "','" + active + "'," + quyen + ",'" +email+ "')";
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

        private void cbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (quyen != 3)
            {
                quyen = Ham.GetIdFromCombobox(cbQuyen.SelectedItem.ToString());
            }
        }
    }
}
