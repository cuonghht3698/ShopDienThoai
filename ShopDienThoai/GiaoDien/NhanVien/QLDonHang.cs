using ShopDienThoai.GiaoDien.KhachHang;
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
    public partial class QLDonHang : Form
    {
        private getData cn;
        private DateTime ngayTu;
        private DateTime ngayDen;
        private int SIdNV = 0;
        private string StrangThai = "";

        public QLDonHang()
        {
            InitializeComponent();
            cn = new getData();
        }

        private void QLDonHang_Load(object sender, EventArgs e)
        {
            ngayTu = DateTime.Now;
            ngayDen = DateTime.Now;
            cbSTrangThai.Items.Add("Trạng thái");
            cbSTrangThai.Items.Add(TrangThai.ChoDuyet);
            cbSTrangThai.Items.Add(TrangThai.GiaoHang);
            cbSTrangThai.Items.Add(TrangThai.HoanThanh);
            cbSTrangThai.Items.Add(TrangThai.DaHuy);
            cbSTrangThai.SelectedIndex = 0;
            cbSNhanVien.Items.Add("Người xử lý");
            getNhanVien();
            cbSNhanVien.SelectedIndex = 0;
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

            datePickTu.CustomFormat = "dd/MM/yyyy";
            datePickDen.CustomFormat = "dd/MM/yyyy";

        }


        private void getNhanVien()
        {
            var nv = cn.getDataTable("select id,ten from htuser where roleId != 3");
            if (nv.Rows.Count > 0)
            {
                foreach (DataRow item in nv.Rows)
                {
                    cbSNhanVien.Items.Add(item[0].ToString() + " - " + item[1].ToString());
                }

            }
        }
        private void getAll()
        {
            dataGridView1.DataSource = cn.getDataTable("select distinct h.id, h.noigiaohang, h.ngaydat,h.trangthai from hoadon h join chitiethoadon ct on h.id = ct.hoadonId " +
                "join sanpham s on ct.sanphamid = s.id where h.ngaydat >='" + Ham.GetDate(ngayTu) + "' and h.ngaydat <='" + Ham.GetDate(ngayDen) + "' and ('" + StrangThai + "' = '' or h.trangthai = N'" + StrangThai + "') " +
                "and ( " + SIdNV + " = 0 or h.nhanvienId = " + SIdNV + ") group by h.id, s.ten, h.noigiaohang, h.ngaydat, h.trangthai  order by h.trangthai asc");


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                // xem don
                id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                GioHang f = new GioHang(id);
                f.ShowDialog();


            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                // huy don
                id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
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
        private void HuyDon(int id)
        {
            cn.ExecuteNonQuery("update hoadon set trangthai =N'" + TrangThai.DaHuy + "' where id = " + id);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbSNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSNhanVien.SelectedIndex != 0)
            {
                SIdNV = Ham.GetIdFromCombobox(cbSNhanVien.SelectedItem.ToString());
                
            }
            else
            {
                SIdNV = 0;
            }
            getAll();
        }

        private void cbSTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSTrangThai.SelectedIndex != 0)
            {
                StrangThai = cbSTrangThai.SelectedItem.ToString();
               

            }
            else
            {
                StrangThai = "";
            }
            getAll();
        }

        private void datePickTu_ValueChanged(object sender, EventArgs e)
        {
            ngayTu = datePickTu.Value;

            getAll();

        }

        private void datePickDen_ValueChanged(object sender, EventArgs e)
        {
            ngayDen = datePickDen.Value;

            getAll();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            getAll();

        }
    }
}
