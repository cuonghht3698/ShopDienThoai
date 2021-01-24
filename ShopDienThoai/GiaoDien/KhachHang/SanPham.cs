using FontAwesome.Sharp;
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
    public partial class SanPham : Form
    {
        private getData conn;
        private int SNhaCungCap = 0;
        private int SGiaTu = 0;
        private int SGiaDen = 0;
        private string Ssearch = "";
        private int SloaiDienThoai = 0;
        private int SRamTu = 0;
        private int SRamDen = 0;
        private int SRomTu = 0;
        private int SRomDen = 0;
        private int SManHinhTu = 0;
        private int SManHinhDen = 0;
        private string orderBy = " order by s.soluong";
        private string orderByType = " desc";
        private int IdHoaDon = 0;
        public SanPham()
        {
            InitializeComponent();
            conn = new getData();
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            GetSanPham();
            GetLoaiDienThoai();
            CheckHoaDon();
        }


        private void GetSanPham()
        {
            panelSearchLoai.Visible = true;
            panelThu2.Visible = true;
            var data = conn.getDataTable("select top 30 s.id,s.ten,s.giaKM,s.giaBan,s.luotxem,a.anh,s.soluong from SanPham s " +
                "join (select * from AnhSanPham where id in (select max(id) from AnhSanPham group by sanphamId)) as a on s.id = a.sanphamId " +
                "where ('" + Ssearch + "' = '' or s.ten like '%" + Ssearch + "%') and ( " + SloaiDienThoai + " = 0 or s.loaispId = " + SloaiDienThoai + ") " +
                "and ( " + SNhaCungCap + " = 0 or s.nccId = " + SNhaCungCap + ") and (" + SGiaTu + " = 0 or s.giaban >= " + SGiaTu + ") and (" + SGiaDen + " = 0 or s.giaban <= " + SGiaDen + ")" +
                " and (" + SRamTu + " = 0 or s.ram >= " + SRamTu + ") " +
                "and (" + SRamDen + " = 0 or s.ram <= " + SRamDen + ") and (" + SRomTu + " = 0 or s.rom >= " + SRomTu + ")  and (" + SRomDen + " = 0 or s.rom <= " + SRomDen + ") " +
                "and (" + SManHinhTu + " = 0 or s.manhinh >= " + SManHinhTu + ")  and (" + SManHinhDen + " = 0 or s.manhinh <= " + SManHinhDen + ") " + orderBy + orderByType);
            if (data.Rows.Count > 0)
            {
                panelShowSP.Controls.Clear();
                w = 0;
                h = 20;
                count = 0;

                foreach (DataRow item in data.Rows)
                {

                    int id = Int32.Parse(item[0].ToString());
                    string ten = item[1].ToString();

                    int giaKM = Int32.Parse(item[2].ToString());
                    int giaBan = Int32.Parse(item[3].ToString());
                    int luotxem = Int32.Parse(item[4].ToString());
                    int sl = Int32.Parse(item[6].ToString());
                    string anh = item[5].ToString();
                    createDienThoai(id, ten, giaKM, giaBan, luotxem, anh, sl);


                }

                panelShowSP.Controls.Add(panelButtom);
            }
            else
            {
                panelShowSP.Controls.Clear();
                panelShowSP.Controls.Add(panelEmptySP);
                panelEmptySP.Visible = true;
            }



        }
        private void SearchGia(int tu, int den)
        {
            SGiaTu = tu;
            SGiaDen = den;
            GetSanPham();
        }
        private void GetLoaiDienThoai()
        {
            var data = conn.getDataTable("SELECT top 10 * from NhaCungCap");
            var loai = conn.getDataTable("SELECT top 3 * from LoaiSanPham");
            if (data.Rows.Count > 0)
            {

                foreach (DataRow item in data.Rows)
                {
                    int id = Int32.Parse(item[0].ToString());
                    string ten = item[1].ToString();

                    createSearchHeader(id, ten);


                }
            }
            if (loai.Rows.Count > 0)
            {
                CreateSearchLoai(0, "Tất cả");
                foreach (DataRow item in loai.Rows)
                {
                    int id = Int32.Parse(item[0].ToString());
                    string ten = item[1].ToString();

                    CreateSearchLoai(id, ten);


                }
            }
            createSearchHeader(0, "Tất cả");

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

        private void DatHang(int Id, int giaBan, int soLuong)
        {
            conn.ExecuteNonQuery("insert into chitiethoadon (hoadonId,sanphamId,dongia,soluong) values(" + IdHoaDon + "," + Id + "," + giaBan + "," + soLuong + ")");
            MessageBox.Show("Thêm vào giỏ hàng thành công!", "Thông báo!");
        }
        private void SearchHeader(int id)
        {
            SNhaCungCap = id;
            GetSanPham();
        }

        private int XLoai = 0;
        private void CreateSearchLoai(int id, string ten)
        {

            LinkLabel link = new LinkLabel();
            link.Location = new Point(linkLoaiAll.Location.X, linkLoaiAll.Location.Y + XLoai);
            link.LinkBehavior = linkLoaiAll.LinkBehavior;
            link.Text = ten;
            link.Tag = id;
            link.Click += (object sender, EventArgs e) =>
             {
                 SearchLoai(id);

             };
            groupBox1.Controls.Add(link);
            XLoai += 25;
        }
        private void SearchLoai(int id)
        {
            SloaiDienThoai = id;
            GetSanPham();
        }


        //BỎ BỘ LỌC

        private void BoBoLoc()
        {
            SNhaCungCap = 0;
            SGiaTu = 0;
            SGiaDen = 0;
            Ssearch = "";
            SloaiDienThoai = 0;
            SRamTu = 0;
            SRamDen = 0;
            SRomTu = 0;
            SRomDen = 0;
            SManHinhTu = 0;
            SManHinhDen = 0;
            orderBy = " order by s.soluong";
            orderByType = " desc";
            GetSanPham();

        }

        private int wButtonSearch = 0;
        private int wButtonSearchCount = 0;
        private void createSearchHeader(int id, string ten)
        {
            wButtonSearchCount++;
            IconButton iconButton = new IconButton();
            iconButton.BackColor = btnSLoaiSanPham.BackColor;
            iconButton.Text = ten;
            iconButton.Tag = id;
            iconButton.FlatStyle = btnSLoaiSanPham.FlatStyle;
            iconButton.FlatAppearance.BorderSize = btnSLoaiSanPham.FlatAppearance.BorderSize;
            iconButton.Font = btnSLoaiSanPham.Font;
            iconButton.AutoSize = true;
            iconButton.Cursor = Cursors.Hand;
            iconButton.ForeColor = btnSLoaiSanPham.ForeColor;
            iconButton.Location = new Point(wButtonSearch + 20);
            iconButton.Click += (object sender, EventArgs e) =>
            {
                SearchHeader(id);
            };
            panelSearchLoai.Controls.Add(iconButton);
            wButtonSearch += iconButton.Width + 10;
        }

        private int w = 0;
        private int h = 20;
        private int count = 0;
        private void createDienThoai(int id, string tenSp, int giaKm, int giaBan, int luotxem, string anh, int sl)
        {

            Panel panel = new Panel();

            PictureBox pic = new PictureBox();
            Label hethang = new Label();
            Label ten = new Label();
            Label gia = new Label();
            Label giaGach = new Label();
            Label view = new Label();
            Label viewCount = new Label();
            IconButton button = new IconButton();

            // location
            w = (panelMau.Width + 10) * count;

            if (panelShowSP.Width < w + 70)
            {
                w = 0;
                count = 0;
                h += panelMau.Height + 20;
            }
            count++;


            // panel
            panel.Dock = panelMau.Dock;
            panel.Size = panelMau.Size;
            panel.BorderStyle = panelMau.BorderStyle;
            panel.Cursor = panelMau.Cursor;
            panel.BackColor = panelMau.BackColor;
            panel.Click += (object s, EventArgs e) =>
              {
                  OpenChiTietSanPham(id);
              };
            panel.Location = new Point(20 + w, h);
            //het hang 
            if (sl == 0)
            {
                hethang.Text = lbHetHang.Text;
                hethang.ForeColor = lbHetHang.ForeColor;
                hethang.Location = lbHetHang.Location;
                hethang.Font = lbHetHang.Font;
                hethang.AutoSize = true;
                panel.Controls.Add(hethang);
            }

            // anh sp
            pic.Location = pictureMau.Location;
            pic.Size = pictureMau.Size;
            pic.Image = String.IsNullOrEmpty(anh) ? null : Ham.GetImageFromString(anh);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Click += (object s, EventArgs e) =>
            {
                OpenChiTietSanPham(id);
            };
            panel.Controls.Add(pic);
            // ten sp
            ten.Location = lbTenMau.Location;
            ten.Text = tenSp;
            ten.ForeColor = lbTenMau.ForeColor;
            ten.Font = lbTenMau.Font;
            ten.AutoSize = lbTenMau.AutoSize;
            ten.Size = lbTenMau.Size;
            ten.Click += (object s, EventArgs e) =>
            {
                OpenChiTietSanPham(id);
            };
            panel.Controls.Add(ten);
            // gia
            if (giaKm == 0)
            {
                giaKm = giaBan;
            }
            else
            {
                giaGach.Location = lbGiaGachMau.Location;
                giaGach.Font = lbGiaGachMau.Font;
                giaGach.ForeColor = lbGiaGachMau.ForeColor;
                giaGach.Text = giaBan + " đ";
                giaGach.Click += (object s, EventArgs e) =>
                {
                    OpenChiTietSanPham(id);
                };
                panel.Controls.Add(giaGach);
            }
            gia.Location = lbGiaMau.Location;
            gia.Font = lbGiaMau.Font;
            gia.ForeColor = lbGiaMau.ForeColor;
            gia.Text = giaKm + " đ";
            gia.Click += (object s, EventArgs e) =>
            {
                OpenChiTietSanPham(id);
            };
            panel.Controls.Add(gia);
            // gia gach giữa



            // VIEW COUNT
            viewCount.Location = lbViewCountMau.Location;
            viewCount.Font = lbViewCountMau.Font;
            viewCount.ForeColor = lbViewCountMau.ForeColor;
            viewCount.Text = luotxem.ToString();
            viewCount.Click += (object s, EventArgs e) =>
            {
                OpenChiTietSanPham(id);
            };
            panel.Controls.Add(viewCount);
            // VIEW
            view.Location = lbViewMau.Location;
            view.Font = lbViewMau.Font;
            view.ForeColor = lbViewMau.ForeColor;
            view.Text = lbViewMau.Text;
            view.Click += (object s, EventArgs e) =>
            {
                OpenChiTietSanPham(id);
            };
            panel.Controls.Add(view);

            // button dat hang
            button.Location = btnDatMau.Location;
            button.IconChar = btnDatMau.IconChar;
            button.BackColor = btnDatMau.BackColor;
            button.ForeColor = btnDatMau.ForeColor;
            if (sl == 0)
            {
                button.Enabled = false;
            }
            button.Click += (object sender, EventArgs e) =>
            {
                DatHang(id, giaKm, 1);
            };
            button.Size = btnDatMau.Size;
            button.Font = btnDatMau.Font;
            button.IconColor = btnDatMau.IconColor;
            button.IconSize = btnDatMau.IconSize;
            button.TextAlign = btnDatMau.TextAlign;
            button.Text = btnDatMau.Text;
            button.FlatStyle = btnDatMau.FlatStyle;
            button.TextImageRelation = btnDatMau.TextImageRelation;

            panel.Controls.Add(button);

            panelShowSP.Controls.Add(panel);



        }

        private void OpenChiTietSanPham(int id)
        {
            conn.ExecuteNonQuery("update sanpham set luotxem = luotxem +1 where id = " + id);
            panelSearchLoai.Visible = false;
            panelThu2.Visible = false;
            panelShowSP.Controls.Clear();
            panelShowSP.AutoScroll = true;
            // add panel
            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.Size = new Size(0, 40);
            panelShowSP.Controls.Add(panel);

            IconButton btn = new IconButton();
            btn.IconChar = IconChar.Backspace;
            btn.Location = new Point(0, 0);
            btn.IconSize = 25;
            btn.Dock = DockStyle.Left;
            btn.BackColor = Color.Green;
            btn.ForeColor = Color.White;
            btn.Text = "Trở lại";
            btn.AutoSize = true;
            btn.Click += (object s, EventArgs e) =>
             {
                 BackSanPham();
             };
            btn.Cursor = Cursors.Hand;
            btn.FlatStyle = FlatStyle.Flat;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            panel.Controls.Add(btn);



            // 
            ChiTietSanPham childForm = new ChiTietSanPham(id);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelShowSP.Controls.Add(childForm);
            panelShowSP.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BackSanPham()
        {
            GetSanPham();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Ssearch = txtSearch.Text;
            GetSanPham();
        }


        private void ResetLinkGia()
        {
            linkGia1.BackColor = Color.Empty;
            linkGia2.BackColor = Color.Empty;
            linkGia3.BackColor = Color.Empty;
            linkGia4.BackColor = Color.Empty;
            linkGia5.BackColor = Color.Empty;
            linkGia6.BackColor = Color.Empty;
        }
        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchGia(0, 5000000);
            ResetLinkGia();
            linkGia1.BackColor = Color.Red;


        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchGia(0, 0);
            ResetLinkGia();
            linkGia6.BackColor = Color.Red;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchGia(5000000, 10000000);
            ResetLinkGia();
            linkGia2.BackColor = Color.Red;


        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchGia(10000000, 15000000);
            ResetLinkGia();
            linkGia3.BackColor = Color.Red;


        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchGia(15000000, 20000000);
            ResetLinkGia();
            linkGia4.BackColor = Color.Red;


        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SearchGia(20000000, 0);
            ResetLinkGia();
            linkGia5.BackColor = Color.Red;


        }
        private void linkRamAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRamTu = 0;
            SRamDen = 0;
            GetSanPham();

        }
        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRamTu = 0;
            SRamDen = 4;
            GetSanPham();
        }

        private void linkRam46_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRamTu = 4;
            SRamDen = 6;
            GetSanPham();
        }

        private void linkRam8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRamTu = 8;
            SRamDen = 0;
            GetSanPham();
        }

        private void linkRomAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRomTu = 0;
            SRomDen = 0;
            GetSanPham();
        }

        private void linkRom32_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRomTu = 0;
            SRomDen = 32;
            GetSanPham();
        }

        private void linkRom128256_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRomTu = 128;
            SRomDen = 256;
            GetSanPham();
        }

        private void linkRom3264_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRomTu = 32;
            SRomDen = 64;
            GetSanPham();
        }

        private void linkRom512_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SRomTu = 512;
            SRomDen = 0;
            GetSanPham();
        }

        private void linkMHAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SManHinhTu = 0;
            SManHinhDen = 0;
            GetSanPham();
        }

        private void linkMHD6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SManHinhTu = 0;
            SManHinhDen = 6;
            GetSanPham();
        }

        private void linkMHT6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SManHinhTu = 6;
            SManHinhDen = 0;
            GetSanPham();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            orderBy = "order by s.giaban";
            orderByType = " asc";
            GetSanPham();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            orderBy = "order by s.giaban";
            orderByType = " desc";
            GetSanPham();
        }
        private bool checkLuotXem = true;
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            orderBy = "order by s.luotxem ";
            orderByType = checkLuotXem ? " asc" : " desc";
            GetSanPham();
            checkLuotXem = !checkLuotXem;
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            BoBoLoc();
        }
    }
}
