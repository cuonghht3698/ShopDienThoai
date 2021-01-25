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
    public partial class DanhSachDonDatHang : Form
    {
        private getData cn;
        public DanhSachDonDatHang()
        {
            InitializeComponent();
            cn = new getData();
        }

        private void DanhSachDonDatHang_Load(object sender, EventArgs e)
        {
            getAll();
            DataGridViewButtonColumn xem = new DataGridViewButtonColumn();
            xem.HeaderText = "Xem";
            xem.Text = "Xem";
            xem.Width = 40;
            xem.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(xem);

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Hủy đơn";
            delete.Text = "Hủy đơn";
            delete.Width = 40;
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
        }
        private void getAll()
        {
            if (activeForm != null)
            {
                activeForm.Visible = false;
            }
            panel1.Visible = false;
            panelCha.Controls.Add(dataGridView1);
            dataGridView1.DataSource = cn.getDataTable("select distinct h.id, h.noigiaohang, h.ngaydat,h.trangthai from hoadon h join chitiethoadon ct on h.id = ct.hoadonId join sanpham s on ct.sanphamId = s.id" +
                  " where h.khachhangId = " + LuuThongTin.id + " group by h.id, s.ten, h.noigiaohang, h.ngaydat, h.trangthai order by h.id desc");


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                // xem don
                panelCha.Controls.Clear();
                panelCha.Controls.Add(panel1);
                panel1.Visible = true;
                openChildForm(new GioHang(id));
             


            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                // huy don
                var confirmResult = MessageBox.Show("Bạn có muốn hủy đơn này ??",
                                     "Cảnh báo!!",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    HuyDon(id);
                    MessageBox.Show("Hủy đơn thành công !");

                    getAll();

                }

            }
        }
        private Form activeForm = null;

        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelCha.Controls.Add(childForm);
            panelCha.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void HuyDon(int id)
        {
            cn.ExecuteNonQuery("update hoadon set trangthai =N'" + TrangThai.DaHuy + "' where id = " + id);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            getAll();
        }
    }
}
