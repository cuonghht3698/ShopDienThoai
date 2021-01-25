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
    public partial class NhapHang : Form
    {
        private getData cn;
        private int phieuId;
        private string trangthai = TrangThai.TaoPhieu;
        public NhapHang()
        {
            InitializeComponent();
            cn = new getData();
        }

        private void NhapSach_Load(object sender, EventArgs e)
        {
            getDataChon();
            CheckPhieu();
            getChiTietPhieu();
            addBtnDelete();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getDataChon();
        }

        private void getDataChon()
        {
            var data = cn.getDataTable("select top 10 s.id,s.ten,s.gianhap,s.giaBan,s.luotxem,a.anh,s.soluong from SanPham s " +
                "join (select * from AnhSanPham where id in (select max(id) from AnhSanPham group by sanphamId)) as a on s.id = a.sanphamId " +
                "where ( '" + txtSearch.Text + "' = '' or s.ten like N'%" + txtSearch.Text + "%' ) order by ten");
            panelPickSP.Controls.Clear();
            if (data.Rows.Count > 0)
            {

                foreach (DataRow item in data.Rows)
                {
                    string ma, ten, gianhap, sl, anh;
                    ma = item[0].ToString();
                    ten = item[1].ToString();
                    gianhap = item[2].ToString();
                    sl = item[6].ToString();
                    anh = item[5].ToString();

                    AutoGenChon(ma, ten, gianhap, sl, anh);

                }
            }
        }
        private void addBtnDelete()
        {
            dataGridView1.Columns[0].Width = 44;
            dataGridView1.Columns[1].Width = 44;

            dataGridView1.Columns[2].Width = 224;
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Xóa";
            delete.Name = "btnDelete";
            delete.Text = "Xóa";
            delete.Width = 20;
            delete.DefaultCellStyle.BackColor = Color.Red;
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
            dataGridView1.Columns[6].Width = 44;
        }
        private void CheckPhieu()
        {
            var data = cn.getDataTable("SELECT top 1 id from phieu where nhanvienId ="
                    + LuuThongTin.id + " and trangthai =N'" + TrangThai.TaoPhieu + "' and loaiphieuId = 1");
            if (data.Rows.Count > 0)
            {
                phieuId = Int32.Parse(data.Rows[0][0].ToString());
            }
            else
            {
                cn.ExecuteNonQuery("insert into phieu (ngaytao,ngayketthuc,trangthai,nhanvienId,loaiphieuId)" +
               " values ('" + DateTime.Now + "',NULL,N'" + trangthai + "'," + LuuThongTin.id + ",1)");
                CheckPhieu();
            }
        }

        // TẠO CHI TIẾT PHIẾU THÊM SP
        private void TaoChiTietPhieu()
        {
            try
            {
                cn.ExecuteNonQuery("insert into chitietphieu (phieuId,spId,soluong,dongia)" +
               " values (" + phieuId + "," + Int32.Parse(lbId.Text) + "," + Int32.Parse(txtSL.Text) + "," + Int32.Parse(txtGiaNhap.Text) + ")");
            }
            catch (Exception)
            {

                MessageBox.Show("Nhập sai số lượng hoặc đơn giá","Thông báo");
            }
           

        }
        private void AutoGenChon(string ma, string ten, string gianhap, string sl, string anh)
        {
            Panel panel = new Panel();
            Panel panelFooter = new Panel();
            Label lbMa = new Label();
            Label lbTen = new Label();
            Label lbGia = new Label();
            Label lbSL = new Label();
            Label Anh = new Label();
            PictureBox picture1 = new PictureBox();
            Label lbMa1 = new Label();
            Label lbTen1 = new Label();
            Label lbGia1 = new Label();
            Label lbSL1 = new Label();

            panel.Dock = panelCon.Dock;
            panel.Size = panelCon.Size;

            panel.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            panel.Font = panelCon.Font;
            panel.BackColor = Color.White;
            panelPickSP.Controls.Add(panel);

            panelFooter.Dock = panelFooterMau.Dock;
            panelFooter.BackColor = panelFooterMau.BackColor;
            panelFooter.Size = panelFooterMau.Size;
            panel.Controls.Add(panelFooter);


            // label ma tre
            lbMa.Text = lbMaTren.Text;
            lbMa.Size = lbMaTren.Size;
            lbMa.Location = lbMaTren.Location;
            lbMa.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            panel.Controls.Add(lbMa);
            // label ma duoi
            lbMa1.Text = ma;
            lbMa1.Size = lbSMa.Size;
            lbMa1.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            lbMa1.Location = lbSMa.Location;
            panel.Controls.Add(lbMa1);

            // label ten tre
            lbTen.Text = lbTenTren.Text;
            lbTen.Size = lbTenTren.Size;
            lbTen.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            lbTen.Location = lbTenTren.Location;
            panel.Controls.Add(lbTen);
            // label ten duoi
            lbTen1.Text = ten;
            lbTen1.Location = lbSten.Location;
            lbTen1.Size = lbSten.Size;
            lbTen1.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            lbTen1.AutoSize = lbSten.AutoSize;
            panel.Controls.Add(lbTen1);

            // label gia tre
            lbGia.Text = lbGiaNhapTren.Text;
            lbGia.Size = lbGiaNhapTren.Size;
            lbGia.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            lbGia.Location = lbGiaNhapTren.Location;
            panel.Controls.Add(lbGia);
            // label gia duoi
            lbGia1.Text = gianhap;
            lbGia1.Size = lbSgia.Size;
            lbGia1.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            lbGia1.Location = lbSgia.Location;
            panel.Controls.Add(lbGia1);


            // label sl tre
            lbSL.Text = lbSLTren.Text;
            lbSL.Size = lbSLTren.Size;
            lbSL.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            lbSL.Location = lbSLTren.Location;
            panel.Controls.Add(lbSL);
            // label sl duoi
            lbSL1.Text = sl;
            lbSL1.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            lbSL1.Size = lbSsl.Size;
            lbSL1.Location = lbSsl.Location;
            panel.Controls.Add(lbSL1);

            // label anh duoi
            Anh.Text = lbAnh.Text;
            Anh.Size = lbAnh.Size;
            Anh.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };
            Anh.Location = lbAnh.Location;
            panel.Controls.Add(Anh);

            picture1.Size = picSanh1.Size;
            picture1.Image = Ham.GetImageFromString(anh);
            picture1.Location = picSanh1.Location;
            picture1.SizeMode = picSanh1.SizeMode;
            picture1.Click += (object s, EventArgs e) => { PickSanPham(Int32.Parse(ma), panel); };

            panel.Controls.Add(picture1);

        }

        private void PickSanPham(int ma, Panel p)
        {
            foreach (Panel item in panelPickSP.Controls)
            {
                item.BackColor = Color.White;

            }

            p.BackColor = Color.FromArgb(171, 217, 237);
            DataTable tb = cn.getDataTable("SELECT s.id,s.ten,s.gianhap,l.ten FROM sanpham s left join nhacungcap l on s.nccId = l.id Where s.id=" + ma);
            if (tb.Rows.Count > 0)
            {
                lbId.Text = tb.Rows[0][0].ToString();
                lbten.Text = tb.Rows[0][1].ToString();
                txtGiaNhap.Text = tb.Rows[0][2].ToString();
                lbloai.Text = tb.Rows[0][3].ToString();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TaoChiTietPhieu();
            getChiTietPhieu();
        }
        // XÓA CHI TIẾT PHIẾU
        private void XoaChiTietPhieu(int mact)
        {
            cn.ExecuteNonQuery("DELETE chitietphieu where id =" + mact);
        }
        // LAY THÔNG TIN CHI TIẾT PHIẾU ĐỔ VÀO DATATABLE
        private void getChiTietPhieu()
        {
            string sql = "SELECT ct.id as 'Mã',ct.spId as 'Mã SP',s.ten as 'Tên', ls.ten as 'Loại',ct.soluong as 'Số lượng',ct.dongia as 'Đơn giá'" +
                "from chitietphieu ct join sanpham s on ct.spId = s.id left join nhacungcap ls on s.nccId = ls.id where phieuId =" + phieuId;
            DataTable dt = cn.getDataTable(sql);
            dataGridView1.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                int sl = 0;
                int tongtien = 0;
                foreach (DataRow item in dt.Rows)
                {
                    sl += Int32.Parse(item[4].ToString());
                    tongtien += Int32.Parse((Int32.Parse(item[4].ToString()) * Int32.Parse(item[5].ToString())).ToString());
                }
                lbSoLuong.Text = sl.ToString();
                lbtongtien.Text = tongtien.ToString();
                lbtongchu.Text = Ham.ChuyenSo(tongtien.ToString()) + " đồng.";
            }

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
                    XoaChiTietPhieu(id);
                    getChiTietPhieu();
                }

            }
            else if (e.RowIndex != -1)
            {
                lbId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbten.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                lbloai.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSL.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtGiaNhap.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                lbtong.Text = (Int32.Parse(txtGiaNhap.Text) * Int32.Parse(txtSL.Text)).ToString();
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    DatHang(Int32.Parse(item.Cells[2].Value.ToString()), Int32.Parse(item.Cells[5].Value.ToString()));
                }
                MessageBox.Show("Thêm sách thành công");
                cn.ExecuteNonQuery("update phieu set trangthai = N'" + TrangThai.HoanThanh + "' where id =" + phieuId);
                CheckPhieu();
                getDataChon();
                getChiTietPhieu();


            }
        }
        private void DatHang(int id, int sl)
        {
            cn.ExecuteNonQuery("update sanpham set soluong = soluong + " + sl + " where id =" + id);
        }
    }

}
