﻿
namespace ShopQuanAo.GiaoDien.User
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.LinkLabel();
            this.btnQuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLoginFailed = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(197, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Fuchsia;
            this.label3.Location = new System.Drawing.Point(315, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 82);
            this.label3.TabIndex = 39;
            this.label3.Text = "Đăng nhập";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDangKy
            // 
            this.btnDangKy.AutoSize = true;
            this.btnDangKy.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Location = new System.Drawing.Point(459, 363);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(90, 25);
            this.btnDangKy.TabIndex = 40;
            this.btnDangKy.TabStop = true;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDangKy_LinkClicked);
            // 
            // btnQuenMatKhau
            // 
            this.btnQuenMatKhau.AutoSize = true;
            this.btnQuenMatKhau.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuenMatKhau.Location = new System.Drawing.Point(225, 363);
            this.btnQuenMatKhau.Name = "btnQuenMatKhau";
            this.btnQuenMatKhau.Size = new System.Drawing.Size(174, 25);
            this.btnQuenMatKhau.TabIndex = 41;
            this.btnQuenMatKhau.TabStop = true;
            this.btnQuenMatKhau.Text = "Quên mật khẩu?";
            this.btnQuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnQuenMatKhau_LinkClicked);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangNhap.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(202, 438);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(362, 56);
            this.btnDangNhap.TabIndex = 42;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(222, 290);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(323, 48);
            this.txtMatKhau.TabIndex = 38;
            this.txtMatKhau.Text = "admin";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(222, 196);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(323, 48);
            this.txtTaiKhoan.TabIndex = 37;
            this.txtTaiKhoan.Text = "admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tài khoản";
            // 
            // lbLoginFailed
            // 
            this.lbLoginFailed.AutoSize = true;
            this.lbLoginFailed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginFailed.ForeColor = System.Drawing.Color.Red;
            this.lbLoginFailed.Location = new System.Drawing.Point(235, 399);
            this.lbLoginFailed.Name = "lbLoginFailed";
            this.lbLoginFailed.Size = new System.Drawing.Size(0, 19);
            this.lbLoginFailed.TabIndex = 44;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 38);
            this.button1.TabIndex = 45;
            this.button1.Text = "ADMIN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 35);
            this.button2.TabIndex = 46;
            this.button2.Text = "KH";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.iconButton2.IconColor = System.Drawing.Color.DarkRed;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(723, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(46, 47);
            this.iconButton2.TabIndex = 47;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iconButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 47);
            this.panel1.TabIndex = 48;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // DangNhap
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(769, 553);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbLoginFailed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.btnQuenMatKhau);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel btnDangKy;
        private System.Windows.Forms.LinkLabel btnQuenMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLoginFailed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Panel panel1;
    }
}