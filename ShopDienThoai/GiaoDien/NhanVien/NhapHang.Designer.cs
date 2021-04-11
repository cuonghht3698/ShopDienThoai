
namespace ShopDienThoai.GiaoDien.NhanVien
{
    partial class NhapHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapHang));
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lbten = new System.Windows.Forms.Label();
            this.lbloai = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelPickSP = new System.Windows.Forms.Panel();
            this.panelCon = new System.Windows.Forms.Panel();
            this.panelFooterMau = new System.Windows.Forms.Panel();
            this.lbSsl = new System.Windows.Forms.Label();
            this.lbSgia = new System.Windows.Forms.Label();
            this.lbSten = new System.Windows.Forms.Label();
            this.lbSMa = new System.Windows.Forms.Label();
            this.picSanh1 = new System.Windows.Forms.PictureBox();
            this.lbAnh = new System.Windows.Forms.Label();
            this.lbSLTren = new System.Windows.Forms.Label();
            this.lbGiaNhapTren = new System.Windows.Forms.Label();
            this.lbTenTren = new System.Windows.Forms.Label();
            this.lbMaTren = new System.Windows.Forms.Label();
            this.lbtongchu = new System.Windows.Forms.Label();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.lbtongtien = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbtong = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelPickSP.SuspendLayout();
            this.panelCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanh1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(810, 314);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(191, 83);
            this.txtGhiChu.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(756, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Ghi chú";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(66, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(935, 32);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 426);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(674, 225);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThem.IconColor = System.Drawing.Color.Black;
            this.btnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem.Location = new System.Drawing.Point(282, 76);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(86, 33);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(87, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nhấn \" ENTER \" để thêm.";
            // 
            // lbten
            // 
            this.lbten.AutoSize = true;
            this.lbten.Location = new System.Drawing.Point(50, 57);
            this.lbten.Name = "lbten";
            this.lbten.Size = new System.Drawing.Size(0, 13);
            this.lbten.TabIndex = 8;
            // 
            // lbloai
            // 
            this.lbloai.AutoSize = true;
            this.lbloai.Location = new System.Drawing.Point(279, 57);
            this.lbloai.Name = "lbloai";
            this.lbloai.Size = new System.Drawing.Size(0, 13);
            this.lbloai.TabIndex = 7;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(6, 56);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(13, 13);
            this.lbId.TabIndex = 6;
            this.lbId.Text = "0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelPickSP);
            this.panel2.Controls.Add(this.lbtongchu);
            this.panel2.Controls.Add(this.iconButton3);
            this.panel2.Controls.Add(this.iconButton2);
            this.panel2.Controls.Add(this.lbtongtien);
            this.panel2.Controls.Add(this.lbSoLuong);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txtGhiChu);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1060, 673);
            this.panel2.TabIndex = 3;
            // 
            // panelPickSP
            // 
            this.panelPickSP.AutoScroll = true;
            this.panelPickSP.Controls.Add(this.panelCon);
            this.panelPickSP.Location = new System.Drawing.Point(66, 54);
            this.panelPickSP.Name = "panelPickSP";
            this.panelPickSP.Size = new System.Drawing.Size(935, 247);
            this.panelPickSP.TabIndex = 38;
            // 
            // panelCon
            // 
            this.panelCon.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelCon.Controls.Add(this.panelFooterMau);
            this.panelCon.Controls.Add(this.lbSsl);
            this.panelCon.Controls.Add(this.lbSgia);
            this.panelCon.Controls.Add(this.lbSten);
            this.panelCon.Controls.Add(this.lbSMa);
            this.panelCon.Controls.Add(this.picSanh1);
            this.panelCon.Controls.Add(this.lbAnh);
            this.panelCon.Controls.Add(this.lbSLTren);
            this.panelCon.Controls.Add(this.lbGiaNhapTren);
            this.panelCon.Controls.Add(this.lbTenTren);
            this.panelCon.Controls.Add(this.lbMaTren);
            this.panelCon.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCon.Location = new System.Drawing.Point(0, 0);
            this.panelCon.Name = "panelCon";
            this.panelCon.Size = new System.Drawing.Size(935, 71);
            this.panelCon.TabIndex = 0;
            this.panelCon.Visible = false;
            // 
            // panelFooterMau
            // 
            this.panelFooterMau.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelFooterMau.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooterMau.Location = new System.Drawing.Point(0, 61);
            this.panelFooterMau.Name = "panelFooterMau";
            this.panelFooterMau.Size = new System.Drawing.Size(935, 10);
            this.panelFooterMau.TabIndex = 7;
            // 
            // lbSsl
            // 
            this.lbSsl.AutoSize = true;
            this.lbSsl.Location = new System.Drawing.Point(579, 27);
            this.lbSsl.Name = "lbSsl";
            this.lbSsl.Size = new System.Drawing.Size(43, 13);
            this.lbSsl.TabIndex = 6;
            this.lbSsl.Text = "200000";
            // 
            // lbSgia
            // 
            this.lbSgia.AutoSize = true;
            this.lbSgia.Location = new System.Drawing.Point(464, 27);
            this.lbSgia.Name = "lbSgia";
            this.lbSgia.Size = new System.Drawing.Size(43, 13);
            this.lbSgia.TabIndex = 5;
            this.lbSgia.Text = "200000";
            // 
            // lbSten
            // 
            this.lbSten.Location = new System.Drawing.Point(82, 20);
            this.lbSten.Name = "lbSten";
            this.lbSten.Size = new System.Drawing.Size(341, 38);
            this.lbSten.TabIndex = 4;
            this.lbSten.Text = "IPHONE 12  PRO MAX ASDASD\r\n";
            // 
            // lbSMa
            // 
            this.lbSMa.AutoSize = true;
            this.lbSMa.Location = new System.Drawing.Point(21, 28);
            this.lbSMa.Name = "lbSMa";
            this.lbSMa.Size = new System.Drawing.Size(13, 13);
            this.lbSMa.TabIndex = 3;
            this.lbSMa.Text = "0";
            // 
            // picSanh1
            // 
            this.picSanh1.Image = ((System.Drawing.Image)(resources.GetObject("picSanh1.Image")));
            this.picSanh1.Location = new System.Drawing.Point(804, 0);
            this.picSanh1.Name = "picSanh1";
            this.picSanh1.Size = new System.Drawing.Size(62, 52);
            this.picSanh1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSanh1.TabIndex = 2;
            this.picSanh1.TabStop = false;
            // 
            // lbAnh
            // 
            this.lbAnh.AutoSize = true;
            this.lbAnh.Location = new System.Drawing.Point(772, 4);
            this.lbAnh.Name = "lbAnh";
            this.lbAnh.Size = new System.Drawing.Size(26, 13);
            this.lbAnh.TabIndex = 1;
            this.lbAnh.Text = "Ảnh";
            // 
            // lbSLTren
            // 
            this.lbSLTren.AutoSize = true;
            this.lbSLTren.Location = new System.Drawing.Point(579, 4);
            this.lbSLTren.Name = "lbSLTren";
            this.lbSLTren.Size = new System.Drawing.Size(67, 13);
            this.lbSLTren.TabIndex = 0;
            this.lbSLTren.Text = "Số lượng tồn";
            // 
            // lbGiaNhapTren
            // 
            this.lbGiaNhapTren.AutoSize = true;
            this.lbGiaNhapTren.Location = new System.Drawing.Point(464, 4);
            this.lbGiaNhapTren.Name = "lbGiaNhapTren";
            this.lbGiaNhapTren.Size = new System.Drawing.Size(50, 13);
            this.lbGiaNhapTren.TabIndex = 0;
            this.lbGiaNhapTren.Text = "Giá nhập";
            // 
            // lbTenTren
            // 
            this.lbTenTren.AutoSize = true;
            this.lbTenTren.Location = new System.Drawing.Point(82, 4);
            this.lbTenTren.Name = "lbTenTren";
            this.lbTenTren.Size = new System.Drawing.Size(75, 13);
            this.lbTenTren.TabIndex = 0;
            this.lbTenTren.Text = "Tên sản phẩm";
            // 
            // lbMaTren
            // 
            this.lbMaTren.AutoSize = true;
            this.lbMaTren.Location = new System.Drawing.Point(18, 4);
            this.lbMaTren.Name = "lbMaTren";
            this.lbMaTren.Size = new System.Drawing.Size(22, 13);
            this.lbMaTren.TabIndex = 0;
            this.lbMaTren.Text = "Mã";
            // 
            // lbtongchu
            // 
            this.lbtongchu.Location = new System.Drawing.Point(756, 526);
            this.lbtongchu.Name = "lbtongchu";
            this.lbtongchu.Size = new System.Drawing.Size(292, 83);
            this.lbtongchu.TabIndex = 37;
            this.lbtongchu.Text = "label8";
            // 
            // iconButton3
            // 
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton3.IconColor = System.Drawing.Color.Black;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.Location = new System.Drawing.Point(869, 612);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(137, 39);
            this.iconButton3.TabIndex = 36;
            this.iconButton3.Text = "Đặt hàng và Duyệt";
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Visible = false;
            // 
            // iconButton2
            // 
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(769, 612);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(91, 39);
            this.iconButton2.TabIndex = 36;
            this.iconButton2.Text = "Thêm vào kho";
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // lbtongtien
            // 
            this.lbtongtien.AutoSize = true;
            this.lbtongtien.Location = new System.Drawing.Point(821, 505);
            this.lbtongtien.Name = "lbtongtien";
            this.lbtongtien.Size = new System.Drawing.Size(13, 13);
            this.lbtongtien.TabIndex = 35;
            this.lbtongtien.Text = "0";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Location = new System.Drawing.Point(821, 463);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(13, 13);
            this.lbSoLuong.TabIndex = 35;
            this.lbSoLuong.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(756, 505);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Tổng tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(756, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Số lượng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbten);
            this.groupBox1.Controls.Add(this.lbloai);
            this.groupBox1.Controls.Add(this.lbId);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbtong);
            this.groupBox1.Controls.Add(this.txtGiaNhap);
            this.groupBox1.Controls.Add(this.txtSL);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(66, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 115);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập liệu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "ID";
            // 
            // lbtong
            // 
            this.lbtong.AutoSize = true;
            this.lbtong.Location = new System.Drawing.Point(578, 52);
            this.lbtong.Name = "lbtong";
            this.lbtong.Size = new System.Drawing.Size(13, 13);
            this.lbtong.TabIndex = 4;
            this.lbtong.Text = "0";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(489, 49);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(69, 20);
            this.txtGiaNhap.TabIndex = 3;
            this.txtGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(405, 50);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(40, 20);
            this.txtSL.TabIndex = 3;
            this.txtSL.Text = "1";
            this.txtSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(578, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Tổng tiền";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(492, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Gía nhập";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(402, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Số lượng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(279, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Loại hàng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tên sách";
            // 
            // NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 673);
            this.Controls.Add(this.panel2);
            this.Name = "NhapHang";
            this.Text = "NhapSach";
            this.Load += new System.EventHandler(this.NhapSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelPickSP.ResumeLayout(false);
            this.panelCon.ResumeLayout(false);
            this.panelCon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanh1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbten;
        private System.Windows.Forms.Label lbloai;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelPickSP;
        private System.Windows.Forms.Panel panelCon;
        private System.Windows.Forms.Label lbSsl;
        private System.Windows.Forms.Label lbSgia;
        private System.Windows.Forms.Label lbSten;
        private System.Windows.Forms.Label lbSMa;
        private System.Windows.Forms.PictureBox picSanh1;
        private System.Windows.Forms.Label lbAnh;
        private System.Windows.Forms.Label lbSLTren;
        private System.Windows.Forms.Label lbGiaNhapTren;
        private System.Windows.Forms.Label lbTenTren;
        private System.Windows.Forms.Label lbMaTren;
        private System.Windows.Forms.Label lbtongchu;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label lbtongtien;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbtong;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelFooterMau;
    }
}