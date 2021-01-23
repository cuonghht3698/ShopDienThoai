using FontAwesome.Sharp;
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
        public SanPham()
        {
            InitializeComponent();
            conn = new getData();
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            GetSanPham();
            GetLoaiDienThoai();
        }


        private void GetSanPham()
        {
            var data = conn.getDataTable("SELECT top 20 s.id,s.ten,s.giaKM,s.giaBan,s.luotxem,a.anh  from SanPham s left join AnhSanPham a on s.id = a.sanphamId");
            foreach (DataRow item in data.Rows)
            {
                int id = Int32.Parse(item[0].ToString());
                string ten = item[1].ToString();

                int giaKM = Int32.Parse(item[2].ToString());
                int giaBan = Int32.Parse(item[3].ToString());
                int luotxem = Int32.Parse(item[4].ToString());
                string anh = item[5].ToString();
                createDienThoai(id, ten, giaKM, giaBan, luotxem ,anh);


            }
            Console.WriteLine(data.Rows.Count);

        }

        private void GetLoaiDienThoai()
        {
            var data = conn.getDataTable("SELECT top 10 * from LoaiSanPham");
            foreach (DataRow item in data.Rows)
            {
                int id = Int32.Parse(item[0].ToString());
                string ten = item[1].ToString();

                createSearchHeader(id, ten);


            }
            Console.WriteLine(data.Rows.Count);

        }

        private void SearchHeader(int id)
        {
            MessageBox.Show(id.ToString());
        }
        private void DatHang(int id)
        {
            MessageBox.Show(id.ToString());
        }
        private int wButtonSearch = 0;
        private int wButtonSearchCount = 0;
        private void createSearchHeader(int id ,string ten)
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
        private void createDienThoai(int id, string tenSp, int giaKm, int giaBan, int luotxem, string anh)
        {
            Panel panel = new Panel();
            PictureBox pic = new PictureBox();
            Label ten = new Label();
            Label gia = new Label();
            Label giaGach = new Label();
            Label view = new Label();
            Label viewCount = new Label();
            IconButton button = new IconButton();

            // location
            w = (panelMau.Width + 10) * count;

            if (this.Width < w + 90)
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
            panel.Location = new Point(20 + w, h);
            // anh sp
            pic.Location = pictureMau.Location;
            pic.Size = pictureMau.Size;
            pic.Image = String.IsNullOrEmpty(anh) ? null : Ham.GetImageFromString(anh);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            panel.Controls.Add(pic);
            // ten sp
            ten.Location = lbTenMau.Location;
            ten.Text = tenSp;
            ten.ForeColor = lbTenMau.ForeColor;
            ten.Font = lbTenMau.Font;
            ten.AutoSize = lbTenMau.AutoSize;
            ten.Size = lbTenMau.Size;
            panel.Controls.Add(ten);
            // gia
            gia.Location = lbGiaMau.Location;
            gia.Font = lbGiaMau.Font;
            gia.ForeColor = lbGiaMau.ForeColor;
            gia.Text = giaKm + " đ";
            panel.Controls.Add(gia);
            // gia gach giữa
            giaGach.Location = lbGiaGachMau.Location;
            giaGach.Font = lbGiaGachMau.Font;
            giaGach.ForeColor = lbGiaGachMau.ForeColor;
            giaGach.Text = giaBan + " đ";
            panel.Controls.Add(giaGach);


            // VIEW COUNT
            viewCount.Location = lbViewCountMau.Location;
            viewCount.Font = lbViewCountMau.Font;
            viewCount.ForeColor = lbViewCountMau.ForeColor;
            viewCount.Text = luotxem.ToString();
            panel.Controls.Add(viewCount);
            // VIEW
            view.Location = lbViewMau.Location;
            view.Font = lbViewMau.Font;
            view.ForeColor = lbViewMau.ForeColor;
            view.Text = lbViewMau.Text;
            panel.Controls.Add(view);

            // button dat hang
            button.Location = btnDatMau.Location;
            button.IconChar = btnDatMau.IconChar;
            button.BackColor = btnDatMau.BackColor;
            button.ForeColor = btnDatMau.ForeColor;
            button.Click += (object sender, EventArgs e) =>
            {
                DatHang(id);
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


    }
}
