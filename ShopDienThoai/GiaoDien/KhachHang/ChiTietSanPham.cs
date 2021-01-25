using ShopQuanAo.GiaoDien.KhachHang;
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
    public partial class ChiTietSanPham : Form
    {
        private int Id;
        private getData conn;
        private int soluong = 1;
        private int giaban = 0;
        private int IdHoaDon;
        public ChiTietSanPham(int id)
        {
            InitializeComponent();
            Id = id;
            conn = new getData();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            TrangChuKhachHang tc = new TrangChuKhachHang();
            tc.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ChiTietSanPham_Load(object sender, EventArgs e)
        {
            getSP();
            getAnh();
            CheckHoaDon();
        }

        private void getSP()
        {
            var data = conn.getDataTable("select s.id,s.ten,s.soluong,s.giaban,s.giaKM,s.mausac, s.manhinh,s.camera,s.cpu,s.ram,s.rom,s.baohanh,s.phukiendikem,s.ngaynhap,s.mota,s.luotxem,s.danhgia,l.ten from SanPham s join loaisanpham l on s.loaispId = l.id where s.id = " + Id);
            if (data.Rows.Count > 0)
            {
                lbTen.Text = data.Rows[0][1].ToString() + " - " + data.Rows[0][10].ToString() + " GB";
                if (data.Rows[0][4].ToString() == "0")
                {
                    lbGiaKM.Text = String.Format("{0:#,##0.##}", Int32.Parse(data.Rows[0][3].ToString())) + " đồng";
                    giaban = Int32.Parse(data.Rows[0][3].ToString());
                }
                else
                {
                    lbGiaKM.Text = String.Format("{0:#,##0.##}", Int32.Parse(data.Rows[0][4].ToString()))  + " đồng";
                    lbgiaBan.Text = String.Format("{0:#,##0.##}", Int32.Parse(data.Rows[0][3].ToString())) + " đồng";
                    giaban = Int32.Parse(data.Rows[0][4].ToString());

                }
                lbTienChu.Text = Ham.ChuyenSo((giaban * Int32.Parse(txtSL.Text)).ToString()) + " đồng";
                lbMauSac.Text = data.Rows[0][5].ToString();
                if (data.Rows[0][2].ToString() == "0")
                {
                    lbKho.Text = "Hết hàng";
                    btnDatHang.Enabled = false;
                    btnGiam.Enabled = false;
                    btnTang.Enabled = false;
                    txtSL.Enabled = false;
                }
                else
                {
                    lbKho.Text = data.Rows[0][2].ToString();
                }

                lbMota.Text = data.Rows[0][14].ToString();
                lbManHinh.Text = data.Rows[0][6].ToString() + " INCH FULLHD";
                lbCamera.Text = data.Rows[0][7].ToString();
                lbCPU.Text = data.Rows[0][8].ToString();
                lbRam.Text = data.Rows[0][9].ToString() + "GB";
                lbRom.Text = data.Rows[0][10].ToString() + "GB";
                lbLoaiSanPham.Text = data.Rows[0][17].ToString();

            }
        }
        private void getAnh()
        {
            var data = conn.getDataTable("select top 2 anh from ANhSanPham where sanphamId = " + Id);
            if (data.Rows.Count >0)
            {
                if (data.Rows.Count == 1)
                {
                    picAnhBig.Image = Ham.GetImageFromString(data.Rows[0][0].ToString());
                    picAnh1.Image = Ham.GetImageFromString(data.Rows[0][0].ToString());
                }
                else
                {
                    picAnhBig.Image = Ham.GetImageFromString(data.Rows[0][0].ToString());
                    picAnh1.Image = Ham.GetImageFromString(data.Rows[0][0].ToString());
                    picAnh2.Image = Ham.GetImageFromString(data.Rows[1][0].ToString());
                }
            }
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txtSL.Text) > 1)
            {
                txtSL.Text = (Int32.Parse(txtSL.Text) - 1).ToString();
                soluong = Int32.Parse(txtSL.Text);
                lbTienChu.Text =  Ham.ChuyenSo((giaban * soluong).ToString()) + " đồng";
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(lbKho.Text) > Int32.Parse(txtSL.Text))
            {
                txtSL.Text = (Int32.Parse(txtSL.Text) + 1).ToString();
                soluong = Int32.Parse(txtSL.Text);
                lbTienChu.Text = Ham.ChuyenSo((giaban * soluong).ToString()) + " đồng";

            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(lbKho.Text) < Int32.Parse(txtSL.Text))
                {
                    txtSL.Text = lbKho.Text;
                    soluong = Int32.Parse(txtSL.Text);
                    lbTienChu.Text = Ham.ChuyenSo((giaban * soluong).ToString()) + " đồng";
                }


            }
            catch (Exception)
            {
                txtSL.Text = "1";
                MessageBox.Show("Nhập số?", "Thông báo!");
            }
        }
        private int pickAnh = 1;
        private void picAnh1_Click(object sender, EventArgs e)
        {
            NextAnh();
            picAnhBig.Image = picAnh1.Image;
            picAnh1.BorderStyle = BorderStyle.FixedSingle;
            pickAnh = 1;
        }

        private void picAnh2_Click(object sender, EventArgs e)
        {
            NextAnh();
            picAnhBig.Image = picAnh2.Image;
            picAnh2.BorderStyle = BorderStyle.FixedSingle;
            
            pickAnh = 2;
        }
        private void NextAnh()
        {
            picAnh1.BorderStyle = BorderStyle.None;
            picAnh2.BorderStyle = BorderStyle.None;
        }
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            NextAnh();
            if (pickAnh == 1)
            {
                picAnhBig.Image = picAnh2.Image;
                picAnh2.BorderStyle = BorderStyle.FixedSingle;
             
                pickAnh = 2;
            }
            else
            {
                picAnhBig.Image = picAnh1.Image;
                
                picAnh1.BorderStyle = BorderStyle.FixedSingle;
                pickAnh = 1;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            NextAnh();
            if (pickAnh == 1)
            {
                picAnhBig.Image = picAnh2.Image;
                
                picAnh2.BorderStyle = BorderStyle.FixedSingle;
                pickAnh = 2;
            }
            else
            {
                picAnhBig.Image = picAnh1.Image;
                
                picAnh1.BorderStyle = BorderStyle.FixedSingle;
                pickAnh = 1;
            }
        }

        //check hoa don 
        private void CheckHoaDon()
        {
            var data = conn.getDataTable("select top 1 * from hoadon where khachhangId =" + LuuThongTin.id + " and trangthai =N'" + TrangThai.TaoPhieu + "'");
            if (data.Rows.Count > 0)
            {
                IdHoaDon = Int32.Parse(data.Rows[0][0].ToString());
            }
            else
            {
                // khong co hoa dong nao
                conn.ExecuteNonQuery("insert into hoadon (khachhangId, nhanvienId,ngaydat,noigiaohang,sdt,trangthai) values("
                    + LuuThongTin.id + ",NULL,NULL,NULL,NULL,N'" + TrangThai.TaoPhieu + "')");
                CheckHoaDon();
            }
        }

        private void ThemGioHang()
        {
            conn.ExecuteNonQuery("insert into chitiethoadon (hoadonId,sanphamId,dongia,soluong) values(" + IdHoaDon + "," + Id + "," + giaban + "," + soluong + ")");
            MessageBox.Show("Thêm vào giỏ hàng thành công!", "Thông báo!");
        }
        private void DatHang()
        {

        }
        private void btnDatHang_Click(object sender, EventArgs e)
        {
            ThemGioHang();
        }
    }
}
