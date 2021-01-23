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

namespace ShopDienThoai.GiaoDien.NhanVien
{
    public partial class QLNhanVien : Form
    {
        private getData cn;
        private string sSearch;
        private string sRole;
        private bool sTrangThai;
        public QLNhanVien()
        {
            InitializeComponent();
            cn = new getData();
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {

            cbQuyen.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;
            getQuyen();
            cbSearchChucVu.Items.Add("-- Lọc theo quyền");
            cbSearchChucVu.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 1;
            getDataNhanVien();
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
        private void getDataNhanVien()
        {
            sSearch = txtSearch.Text;
            sRole = cbSearchChucVu.SelectedItem.ToString();

            string where = "";
            if (!String.IsNullOrEmpty(sSearch))
            {
                where = " and ( ten like '%" + sSearch + "%')";
            }
            if (cbSearchChucVu.SelectedIndex != 0)
            {
                where += " and quyen like '%" + sRole + "%'";
            }
            if (cbTrangThai.SelectedIndex != 0)
            {
                where += " and active = '" + sTrangThai + "'";
            }
            DataTable tb = cn.getDataTable("select u.id,u.ten,u.ngaysinh,u.sdt,u.gioitinh,u.diachi,u.taikhoan,u.active,(convert(varchar,u.roleId) + ' -' + r.ten) as 'Quyền' from HTUser u " +
                "join HTRole r on u.roleId = r.id");
            dataGridView1.DataSource = tb;
        }

        private void getQuyen()
        {
            var data = cn.getDataTable("select (convert(varchar,id) + ' -' + ten) as 'quyen' from HTRole");
            if (data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    cbQuyen.Items.Add(item[0].ToString());
                    cbSearchChucVu.Items.Add(item[0].ToString());
                }
            }
        }
        private void updateNhanVien()
        {
            string ten, sdt, quequan, username;
            int id, active, quyen;
            bool gioitinh;
            DateTime ngaysinh;
            id = int.Parse(txtMa.Text);
            ten = txtTen.Text;
            sdt = txtSdt.Text;
            quequan = txtQueQuan.Text;
            username = txtUsername.Text;
            quyen = Ham.GetIdFromCombobox(cbQuyen.SelectedItem.ToString());
            gioitinh = Ham.NamNuToTrueFalse(cbGioiTinh.SelectedItem.ToString());
            active = checkActive.Checked ? 1 : 0;
            ngaysinh = dateTimePicker1.Value;
            string sql = "update HTUser set ten = N'" + ten + "',ngaysinh = '" + ngaysinh + "',sdt = '" + sdt + "',gioitinh = '" + gioitinh + "'" +
                ",diachi = N'" + quequan + "',taikhoan = '" + username + "',active = " + active + ",roleId =" + quyen + " where id = " + id;
            try
            {
                cn.ExecuteNonQuery(sql);
                getDataNhanVien();
            }
            catch (Exception)
            {

                MessageBox.Show("Kiểm tra lại thông tin", "Thông báo!");
            }
        }

        private void getUserById(int id)
        {
            var data = cn.getDataTable("u.id,u.ten,u.ngaysinh,u.sdt,u.gioitinh,u.diachi,u.taikhoan,u.active,(convert(varchar,u.roleId) + ' -' + r.ten) from HTUser u" +
                "join HTRole r on u.roleId = r.id where id = " + id);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                     "Cảnh báo!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                }

            }
            else if (e.RowIndex != -1)
            {
                txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (!String.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()))
                {
                    dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
                txtSdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbGioiTinh.SelectedItem = Ham.TrueFalseToNamNu(Boolean.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));
                txtQueQuan.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                //txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

                checkActive.Checked = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() == "True" ? true : false;
                Console.WriteLine(checkActive.Checked);
                cbQuyen.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void cbSearchChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDataNhanVien();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            updateNhanVien();
            getDataNhanVien();
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            sTrangThai = cbTrangThai.SelectedIndex == 1 ? true : false;
            getDataNhanVien();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy(true);
            dk.ShowDialog();
        }
    }
}
