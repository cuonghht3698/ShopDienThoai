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
    public partial class TonKho : Form
    {
        private readonly getData cn;
        private string search;
        private int PageIndex = 1;
        private int PageSize = 20;

        public TonKho()
        {
            InitializeComponent();
            cn = new getData();
        }

        private void TonKho_Load(object sender, EventArgs e)
        {
            getTonKho();
            comboBox1.SelectedIndex = 0;
            lbKho.Text = PageIndex.ToString();
        }

        private void getTonKho()
        {
           var data = cn.getDataTable("select ROW_NUMBER() OVER(order by s.ten) as 'STT',s.id as 'Mã', " +
                "s.ten,s.soluong as 'Số lượng tồn',s.gianhap as 'Giá nhập',s.giaban as 'Giá bán',k.ten as 'Kho' from sanpham s" +
                " join kho k on s.khoId = k.id where ('" + search + "' = '' or s.ten like N'%" + search + "%') " +
                "ORDER BY s.soluong OFFSET " + (PageIndex - 1) * PageSize + " ROWS FETCH NEXT " + PageSize + " ROWS ONLY");
                dataGridView1.DataSource = data;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search = textBox1.Text;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            getTonKho();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (PageIndex > 1)
            {

                PageIndex -= 1;
                lbKho.Text = PageIndex.ToString();
                getTonKho();
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {


            PageIndex += 1;
            lbKho.Text = PageIndex.ToString();
            getTonKho();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Int32.Parse(comboBox1.SelectedItem.ToString());
        }
    }
}
