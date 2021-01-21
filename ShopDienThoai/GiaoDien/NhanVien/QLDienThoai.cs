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
        }

        private void GetSanPham()
        {
            dataGridView1.DataSource = conn.getDataTable("SELECT s.id as 'Mã',s.ten as 'Tên',s.soluong,s.gianhap,s.giaban,s.giaKM,k.ten,ncc.ten,l.ten,s.active FROM SanPham s" +
                " left join Kho k on s.khoId = k.id left join NhaCungCap ncc on s.nccId = ncc.id left join LoaiSanPham l on s.loaispId = l.id");
        }
    }
}
