﻿using ShopQuanAo.Public;
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
    public partial class QLKho : Form
    {
        private getData con;
        public QLKho()
        {
            InitializeComponent();
            con = new getData();
        }

        private void QLKho_Load(object sender, EventArgs e)
        {
            GetAll();
            addButtonDataGripview();
        }
        private void GetAll()
        {

            dataGridView1.DataSource = con.getDataTable("SELECT ROW_NUMBER() OVER(ORDER BY ID) as 'STT' ,id as 'Mã', ten as 'Tên',diachi as 'Địa chỉ' FROM Kho");
            dataGridView1.Columns[0].Width = 44;
            dataGridView1.Columns[1].Width = 44;



        }
        private void Delete(int id)
        {
            var confirmResult = MessageBox.Show("Bạn có muốn xóa ??",
                                    "Cảnh báo!!",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                con.ExecuteNonQuery("delete Kho where id = " + id);
                GetAll();
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                Delete(id);
            }
            else if (e.RowIndex != -1)
            {
                txtMa.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }



        private void addButtonDataGripview()
        {

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.HeaderText = "Xóa";
            delete.Name = "btnDelete";
            delete.Text = "Xóa";
            delete.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(delete);
            dataGridView1.Columns[4].Width = 44;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                con.ExecuteNonQuery("insert into Kho (ten,diachi) values (N'" + txtTen.Text + "',N'" + txtDiaChi.Text + "')");
                GetAll();
                lbThongBao.Text = "Thêm Kho thành công!";
                lbThongBao.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                lbThongBao.Text = "Thêm Kho không thành công!";
                lbThongBao.ForeColor = Color.Red;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtMa.Text);
                con.ExecuteNonQuery("update Kho set ten=N'" + txtTen.Text + "', diachi= N'" + txtDiaChi.Text + "' where id =" + id);
                GetAll();
                lbThongBao.Text = "Cập nhật thành công!";
                lbThongBao.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                lbThongBao.Text = "Cập nhật không thành công!";
                lbThongBao.ForeColor = Color.Red;

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtDiaChi.Text = "";
            txtTen.Text = "";

        }
    }
}
