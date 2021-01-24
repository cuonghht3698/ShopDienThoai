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
        private int SloaiId, SnccId, SkhoId;
        private int StrangThai = -1;
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
            btnXoaAnh1.Visible = false;
            btnXoaAnh2.Visible = false;
            cbKho.SelectedIndex = 1;
            cbSKho.SelectedIndex = 0;
            cbSLoai.SelectedIndex = 0;
            cbSNcc.SelectedIndex = 0;
            cbSTrangThai.SelectedIndex = 0;

        }

        private void GetSanPham()
        {
            dataGridView1.DataSource = conn.getDataTable("SELECT s.id as 'Mã',s.ten as 'Tên',s.soluong as 'Số lượng',s.gianhap as 'Giá nhập',s.giaban as 'Giá bán',s.giaKM as 'Giá KM',(convert(varchar,k.id )+ ' -' + k.ten) as 'Kho',(convert(varchar,ncc.id) + ' -' + ncc.ten) as 'NCC'" +
                ",(convert(varchar,l.id) + ' -' + l.ten) as 'Loại',s.active as 'Hoạt động' FROM SanPham s left join Kho k on s.khoId = k.id left join NhaCungCap ncc on s.nccId = ncc.id left join LoaiSanPham l on s.loaispId = l.id " +
                "where ('"
                + txtSten.Text + "' = '' or s.ten like N'%" + txtSten.Text + "%') and (" + SkhoId + " = 0 or k.id = " + SkhoId + ") and ("
                + SloaiId + " = 0 or l.id = " + SloaiId + ") and (" + SnccId + " = 0 or ncc.id = " + SnccId + ") and (" + StrangThai + " = -1 or s.active = " + StrangThai + ")");

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
            txtMoTa.Text = data.Rows[0][15].ToString();
            ckHoatDong.Checked = data.Rows[0][19].ToString() == "True" ? true : false;
        }
        private void GetAnh(int id)
        {
            var dataAnh = conn.getDataTable("SELECT id,sanphamId,title,anh FROM AnhSanPham where sanphamId = " + id);
            btnXoaAnh1.Visible = false;
            btnXoaAnh2.Visible = false;
            if (dataAnh.Rows.Count > 0)
            {
                if (dataAnh.Rows.Count == 1)
                {
                    picAnh1.Image = Ham.GetImageFromString(dataAnh.Rows[0][3].ToString());
                    btnXoaAnh1.Tag = dataAnh.Rows[0][0].ToString();
                    btnXoaAnh1.Visible = true;
                }
                else
                {
                    picAnh1.Image = Ham.GetImageFromString(dataAnh.Rows[0][3].ToString());
                    picAnh2.Image = Ham.GetImageFromString(dataAnh.Rows[1][3].ToString());
                    btnXoaAnh1.Tag = dataAnh.Rows[0][0].ToString();
                    btnXoaAnh2.Tag = dataAnh.Rows[1][0].ToString();
                    btnXoaAnh2.Visible = true;
                    btnXoaAnh1.Visible = true;


                }
            }
            else
            {
                picAnh1.Image = null;
                picAnh2.Image = null;

            }

        }

        private void Update()
        {
            int id, soluong, gianhap, giaban, giaKM, khoId, nccId, loaispId;
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
            khoId = Ham.GetIdFromCombobox(cbKho.SelectedItem.ToString());
            nccId = Ham.GetIdFromCombobox(cbNCC.SelectedItem.ToString());
            loaispId = Ham.GetIdFromCombobox(cbLoai.SelectedItem.ToString());
            ngaynhap = DateTime.Now;
            string sql = "UPDATE [dbo].[SanPham] SET [ten] = N'" + ten + "',[soluong] = " + soluong + ",[gianhap] = " + gianhap + ",[giaban] = " +
                giaban + ",[giaKM] = " + giaKM + ",[mausac] = N'" + mausac + "',[manhinh] = N'" + manhinh + "',[camera] = N'" + camera +
                "',[cpu] = N'" + cpu + "',[ram] = N'" + ram + "',[rom] = N'" + rom + "',[baohanh] = N'" + baohanh + "',[phukiendikem] = N'" + phukiendikem +
                "',[ngaynhap] = N'" + ngaynhap + "',[mota] = N'" + mota + "',[khoId] = " + khoId + ",[nccId] = " + nccId + ",[loaispId] = " + loaispId + ",[active] = '" + active + "'WHERE id = " + id + "";
            conn.ExecuteNonQuery(sql);
            GetSanPham();
            MessageBox.Show("Sửa thành công", "Thông báo");
        }
        private void Insert()
        {
            int id, soluong, gianhap, giaban, giaKM, khoId, nccId, loaispId, luotxem, danhgia;
            DateTime ngaynhap;
            string ten, mausac, manhinh, camera, cpu, ram, rom, baohanh, phukiendikem, mota;
            bool active;
            id = Int32.Parse(txtMa.Text);
            ten = txtTen.Text;
            soluong = 0;
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
            khoId = Ham.GetIdFromCombobox(cbKho.SelectedItem.ToString());
            nccId = Ham.GetIdFromCombobox(cbNCC.SelectedItem.ToString());
            loaispId = Ham.GetIdFromCombobox(cbLoai.SelectedItem.ToString());
            ngaynhap = DateTime.Now;
            luotxem = 0;
            danhgia = 0;
            string sql = @"INSERT INTO [dbo].[SanPham]([ten],[soluong],[gianhap],[giaban],[giaKM],[mausac],[manhinh],[camera],[cpu],[ram]  ,[rom]  ,[baohanh] ,[phukiendikem]  ,[ngaynhap]  ,[mota] ,[khoId] ,[nccId],[loaispId],[active],[luotxem],[danhgia]) VALUES
           (N'" + ten + "'," + soluong + "," + gianhap + " ," + giaban + "," + giaKM + ",N'" + mausac + "',N'" + manhinh + "',N'" + camera + "', N'" + cpu + "' , N'" + ram + "', N'" + rom + "', N'" + baohanh + "', N'" + phukiendikem + "', '" + ngaynhap + "',N'" + mota + "' ," + khoId + " ," + nccId + "," + loaispId + ",1," + luotxem + "," + danhgia + ")";
            conn.ExecuteNonQuery(sql);
            GetSanPham();
           
        }
        private void UploadAnh()
        {
            if (!String.IsNullOrEmpty(txtMa.Text))
            {
                conn.ExecuteNonQuery("DELETE AnhSanPham where sanphamId = " + Int32.Parse(txtMa.Text));
                if (picAnh1.Image != null)
                {
                    conn.ExecuteNonQuery("insert into AnhSanPham (sanphamId,anh) values (" + Int32.Parse(txtMa.Text) + ",'" + Ham.GetStringFromImage(picAnh1.Image) + "')");
                }
                if (picAnh2.Image != null)
                {
                    conn.ExecuteNonQuery("insert into AnhSanPham (sanphamId,anh) values (" + Int32.Parse(txtMa.Text) + ",'" + Ham.GetStringFromImage(picAnh2.Image) + "')");
                }

            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm", "Thông báo");
            }
        }
        private void XoaAnh(int id)
        {
            conn.ExecuteNonQuery("delete AnhSanPham where id = " + id);
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



        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMa.Text))
            {
                Update();
                UploadAnh();
                GetAnh(Int32.Parse(txtMa.Text));
            }

        }

        private void btnXoaAnh1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(btnXoaAnh1.Tag.ToString());
            XoaAnh(id);
            picAnh1.Image = null;
            btnXoaAnh1.Visible = false;
        }

        private void btnXoaAnh2_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(btnXoaAnh2.Tag.ToString());
            XoaAnh(id);
            picAnh2.Image = null;
            btnXoaAnh2.Visible = false;

        }

        private void picAnh1_Click(object sender, EventArgs e)
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

                    picAnh1.Image = new Bitmap(dlg.FileName);

                }
            }
        }

        private void picChonAnh_Click(object sender, EventArgs e)
        {

        }

        private void cbSNcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SnccId = cbSNcc.SelectedIndex != 0 ? Ham.GetIdFromCombobox(cbSNcc.SelectedItem.ToString()) : 0;
            GetSanPham();
        }

        private void cbSKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkhoId = cbSKho.SelectedIndex != 0 ? Ham.GetIdFromCombobox(cbSKho.SelectedItem.ToString()) : 0;
            GetSanPham();
        }

        private void cbSLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            SloaiId = cbSLoai.SelectedIndex != 0 ? Ham.GetIdFromCombobox(cbSLoai.SelectedItem.ToString()) : 0;
            GetSanPham();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSTrangThai.SelectedIndex == 0)
            {
                StrangThai = -1;
            }
            else
            {
                StrangThai = cbSTrangThai.SelectedIndex == 1 ? 1 : 0;
            }
            GetSanPham();
        }

        private void txtSten_TextChanged(object sender, EventArgs e)
        {
            GetSanPham();
        }

        private void picAnh2_Click(object sender, EventArgs e)
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
                    picAnh2.Image = new Bitmap(dlg.FileName);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Insert();
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
