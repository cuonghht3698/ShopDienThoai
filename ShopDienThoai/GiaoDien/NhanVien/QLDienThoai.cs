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
    public partial class QLDienThoai : Form
    {
        private getData conn;
        public QLDienThoai()
        {
            InitializeComponent();
            conn = new getData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QLDienThoai_Load(object sender, EventArgs e)
        {
            GetSanPham();
            GetDataCB();
            
        }

        private void GetSanPham()
        {
            dataGridView1.DataSource = conn.getDataTable("SELECT s.id as 'Mã',s.ten as 'Tên',s.soluong as 'Số lượng',s.gianhap as 'Giá nhập',s.giaban as 'Giá bán',s.giaKM as 'Giá KM',(convert(varchar,k.id )+ ' -' + k.ten) as 'Kho',(convert(varchar,ncc.id) + ' -' + ncc.ten) as 'NCC',(convert(varchar,l.id) + ' -' + l.ten) as 'Loại',s.active as 'Hoạt động' FROM SanPham s left join Kho k on s.khoId = k.id left join NhaCungCap ncc on s.nccId = ncc.id left join LoaiSanPham l on s.loaispId = l.id");

        }
        private void UpdateSanPham()
        {

        }
        private void getAllSanPham(int id)
        {
            var data = conn.getDataTable("SELECT top 1 * FROM [SHOPDIENTHOAI].[dbo].[SanPham] where id = " + id);
            txtMa.Text = data.Rows[0][0].ToString();
            txtTen.Text = data.Rows[0][1].ToString();
            txtSoLuong.Text = data.Rows[0][2].ToString();
            txtGiaNhap.Text = data.Rows[0][3].ToString();
            txtGiaBan.Text = data.Rows[0][4].ToString();
            txtGiaKM.Text = data.Rows[0][5].ToString();
            txtMauSac.Text = data.Rows[0][6].ToString();
            txtManHinh.Text = data.Rows[0][7].ToString();
            txtCamera.Text = data.Rows[0][8].ToString();
            txtCPU.Text = data.Rows[0][9].ToString();
            txtRam.Text = data.Rows[0][10].ToString();
            txtRom.Text = data.Rows[0][11].ToString();
            txtBaoHanh.Text = data.Rows[0][12].ToString();
            txtPhuKien.Text = data.Rows[0][13].ToString();
            txtMoTa.Text = data.Rows[0][16].ToString();
            ckHoatDong.Checked = data.Rows[0][19].ToString() == "True" ? true : false;
        }
        private void GetAnh(int id)
        {
            var dataAnh = conn.getDataTable("SELECT id,sanphamId,title,anh FROM AnhSanPham where sanphamId = " + id);
            if (dataAnh.Rows.Count > 0)
            {
                if (dataAnh.Rows.Count == 1)
                {
                    picAnh1.Image = Ham.GetImageFromString(dataAnh.Rows[0][3].ToString());
                }
                else
                {
                    picAnh1.Image = Ham.GetImageFromString(dataAnh.Rows[0][3].ToString());
                    picAnh2.Image = Ham.GetImageFromString(dataAnh.Rows[1][3].ToString());
                }
            }
        }

        private void Update()
        {
            int id, soluong, gianhap, giaban, giaKM,khoId,nccId,loaispId;
            DateTime ngaynhap;
            string ten, mausac, manhinh, camera, cpu, ram, rom, baohanh, phukiendikem, mota;
            bool active;
            id = Int32.Parse(txtMa.Text);
            ten = txtTen.Text;
            soluong = Int32.Parse(txtSoLuong.Text);
            gianhap = Int32.Parse(txtGiaNhap.Text);
            giaban = Int32.Parse(txtGiaBan.Text);
            giaKM = Int32.Parse(txtGiaKM.Text);
            mausac = txtMauSac.Text;
            manhinh = txtManHinh.Text;
            camera = txtCamera.Text;
            cpu = txtCPU.Text;
            ram = txtRam.Text;
            rom = txtRom.Text;
            baohanh = txtBaoHanh.Text;
            phukiendikem = txtPhuKien.Text;
            mota = txtMoTa.Text;
            active = ckHoatDong.Checked;

            string sql = "UPDATE SanPham SET ten = N'" + ten ;
        }
        private void UploadAnh()
        {

        }
        private void GetDataCB()
        {
            var dataKho = conn.getDataTable("SELECT TOP (1000) [id],[ten],[diachi]FROM [SHOPDIENTHOAI].[dbo].[Kho]");
            if (dataKho.Rows.Count > 0)
            {
                cbSKho.Items.Add("Chọn kho");
                foreach (DataRow item in dataKho.Rows)
                {
                    cbSKho.Items.Add(item[0].ToString() + " -" + item[1].ToString());
                    cbKho.Items.Add(item[0].ToString() + " -" + item[1].ToString());
                }
            }
            var dataLoai = conn.getDataTable("SELECT TOP (1000) [id],[ten],[mota]FROM [SHOPDIENTHOAI].[dbo].[LoaiSanPham]");
            if (dataLoai.Rows.Count > 0)
            {
                cbSLoai.Items.Add("Chọn loại");
                foreach (DataRow item in dataLoai.Rows)
                {

                    cbSLoai.Items.Add(item[0].ToString() + " -" + item[1].ToString());
                    cbLoai.Items.Add(item[0].ToString() + " -" + item[1].ToString());
                }
            }
            var dataNCC = conn.getDataTable("SELECT TOP (1000) [id],[ten],[diachi],[sdt],[email]FROM [SHOPDIENTHOAI].[dbo].[NhaCungCap]");
            if (dataNCC.Rows.Count > 0)
            {
                cbSNcc.Items.Add("Chọn NCC");
                foreach (DataRow item in dataNCC.Rows)
                {

                    cbSNcc.Items.Add(item[0].ToString() + " -" + item[1].ToString());
                    cbNCC.Items.Add(item[0].ToString() + " -" + item[1].ToString());
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                cbKho.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                cbNCC.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                cbLoai.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                getAllSanPham(id);
                GetAnh(id);

            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PictureBox PictureBox1 = new PictureBox();

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    picChonAnh.Image = new Bitmap(dlg.FileName);
                    if (picAnh1.Image == null)
                    {
                        picAnh1.Image = new Bitmap(dlg.FileName);
                    }
                    else
                    {
                        picAnh2.Image = new Bitmap(dlg.FileName);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
