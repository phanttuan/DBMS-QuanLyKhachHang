namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    partial class frmDangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dnTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.dnMatKhau = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dnDangNhapBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // dnTenTaiKhoan
            // 
            this.dnTenTaiKhoan.Location = new System.Drawing.Point(169, 136);
            this.dnTenTaiKhoan.Name = "dnTenTaiKhoan";
            this.dnTenTaiKhoan.Size = new System.Drawing.Size(122, 22);
            this.dnTenTaiKhoan.TabIndex = 2;
            // 
            // dnMatKhau
            // 
            this.dnMatKhau.Location = new System.Drawing.Point(169, 179);
            this.dnMatKhau.Name = "dnMatKhau";
            this.dnMatKhau.PasswordChar = '*';
            this.dnMatKhau.Size = new System.Drawing.Size(122, 22);
            this.dnMatKhau.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy.Properties.Resources.latte_art;
            this.pictureBox1.Location = new System.Drawing.Point(167, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // dnDangNhapBtn
            // 
            this.dnDangNhapBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.dnDangNhapBtn.ForeColor = System.Drawing.Color.White;
            this.dnDangNhapBtn.Location = new System.Drawing.Point(169, 220);
            this.dnDangNhapBtn.Name = "dnDangNhapBtn";
            this.dnDangNhapBtn.Size = new System.Drawing.Size(122, 36);
            this.dnDangNhapBtn.TabIndex = 6;
            this.dnDangNhapBtn.Text = "Đăng nhập";
            this.dnDangNhapBtn.UseVisualStyleBackColor = false;
            this.dnDangNhapBtn.Click += new System.EventHandler(this.dnDangNhapBtn_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(433, 414);
            this.Controls.Add(this.dnDangNhapBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dnMatKhau);
            this.Controls.Add(this.dnTenTaiKhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDangNhap_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dnTenTaiKhoan;
        private System.Windows.Forms.TextBox dnMatKhau;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dnDangNhapBtn;
    }
}