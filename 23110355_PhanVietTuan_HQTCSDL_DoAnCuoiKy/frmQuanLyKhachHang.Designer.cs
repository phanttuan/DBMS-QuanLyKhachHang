namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    partial class frmQuanLyKhachHang
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
            this.qlkhXoaBtn = new System.Windows.Forms.Button();
            this.qlkhThemBtn = new System.Windows.Forms.Button();
            this.qlkhTimKiemBtn = new System.Windows.Forms.Button();
            this.qlkhMaKHTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.qlkhDgv = new System.Windows.Forms.DataGridView();
            this.qlkhExitBtn = new System.Windows.Forms.Button();
            this.qlkhLamMoiBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qlkhDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // qlkhXoaBtn
            // 
            this.qlkhXoaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.qlkhXoaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qlkhXoaBtn.ForeColor = System.Drawing.Color.White;
            this.qlkhXoaBtn.Location = new System.Drawing.Point(701, 398);
            this.qlkhXoaBtn.Name = "qlkhXoaBtn";
            this.qlkhXoaBtn.Size = new System.Drawing.Size(87, 40);
            this.qlkhXoaBtn.TabIndex = 14;
            this.qlkhXoaBtn.Text = "Xóa";
            this.qlkhXoaBtn.UseVisualStyleBackColor = false;
            this.qlkhXoaBtn.Click += new System.EventHandler(this.qlkhXoaBtn_Click);
            // 
            // qlkhThemBtn
            // 
            this.qlkhThemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.qlkhThemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qlkhThemBtn.ForeColor = System.Drawing.Color.White;
            this.qlkhThemBtn.Location = new System.Drawing.Point(608, 398);
            this.qlkhThemBtn.Name = "qlkhThemBtn";
            this.qlkhThemBtn.Size = new System.Drawing.Size(87, 40);
            this.qlkhThemBtn.TabIndex = 13;
            this.qlkhThemBtn.Text = "Thêm";
            this.qlkhThemBtn.UseVisualStyleBackColor = false;
            this.qlkhThemBtn.Click += new System.EventHandler(this.qlkhThemBtn_Click);
            // 
            // qlkhTimKiemBtn
            // 
            this.qlkhTimKiemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.qlkhTimKiemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qlkhTimKiemBtn.ForeColor = System.Drawing.Color.White;
            this.qlkhTimKiemBtn.Location = new System.Drawing.Point(728, 23);
            this.qlkhTimKiemBtn.Name = "qlkhTimKiemBtn";
            this.qlkhTimKiemBtn.Size = new System.Drawing.Size(60, 23);
            this.qlkhTimKiemBtn.TabIndex = 12;
            this.qlkhTimKiemBtn.Text = "Tìm";
            this.qlkhTimKiemBtn.UseVisualStyleBackColor = false;
            this.qlkhTimKiemBtn.Click += new System.EventHandler(this.qlkhTimKiemBtn_Click);
            // 
            // qlkhMaKHTxt
            // 
            this.qlkhMaKHTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qlkhMaKHTxt.Location = new System.Drawing.Point(578, 24);
            this.qlkhMaKHTxt.Name = "qlkhMaKHTxt";
            this.qlkhMaKHTxt.Size = new System.Drawing.Size(144, 22);
            this.qlkhMaKHTxt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(502, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Danh Sách Khách Hàng";
            // 
            // qlkhDgv
            // 
            this.qlkhDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.qlkhDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qlkhDgv.Location = new System.Drawing.Point(12, 52);
            this.qlkhDgv.MultiSelect = false;
            this.qlkhDgv.Name = "qlkhDgv";
            this.qlkhDgv.RowHeadersWidth = 51;
            this.qlkhDgv.RowTemplate.Height = 24;
            this.qlkhDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qlkhDgv.Size = new System.Drawing.Size(776, 340);
            this.qlkhDgv.TabIndex = 8;
            this.qlkhDgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.qlkhDgv_CellContentDoubleClick);
            this.qlkhDgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.qlkhDgv_CellDoubleClick);
            // 
            // qlkhExitBtn
            // 
            this.qlkhExitBtn.BackColor = System.Drawing.Color.Brown;
            this.qlkhExitBtn.ForeColor = System.Drawing.Color.White;
            this.qlkhExitBtn.Location = new System.Drawing.Point(12, 407);
            this.qlkhExitBtn.Name = "qlkhExitBtn";
            this.qlkhExitBtn.Size = new System.Drawing.Size(81, 31);
            this.qlkhExitBtn.TabIndex = 16;
            this.qlkhExitBtn.Text = "Quay lại";
            this.qlkhExitBtn.UseVisualStyleBackColor = false;
            this.qlkhExitBtn.Click += new System.EventHandler(this.qlkhExitBtn_Click);
            // 
            // qlkhLamMoiBtn
            // 
            this.qlkhLamMoiBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.qlkhLamMoiBtn.ForeColor = System.Drawing.Color.White;
            this.qlkhLamMoiBtn.Location = new System.Drawing.Point(110, 407);
            this.qlkhLamMoiBtn.Name = "qlkhLamMoiBtn";
            this.qlkhLamMoiBtn.Size = new System.Drawing.Size(81, 31);
            this.qlkhLamMoiBtn.TabIndex = 17;
            this.qlkhLamMoiBtn.Text = "Làm mới";
            this.qlkhLamMoiBtn.UseVisualStyleBackColor = false;
            this.qlkhLamMoiBtn.Click += new System.EventHandler(this.qlkhLamMoiBtn_Click);
            // 
            // frmQuanLyKhachHang
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.qlkhLamMoiBtn);
            this.Controls.Add(this.qlkhExitBtn);
            this.Controls.Add(this.qlkhXoaBtn);
            this.Controls.Add(this.qlkhThemBtn);
            this.Controls.Add(this.qlkhTimKiemBtn);
            this.Controls.Add(this.qlkhMaKHTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qlkhDgv);
            this.Name = "frmQuanLyKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách hàng";
            this.Load += new System.EventHandler(this.frmQuanLyKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qlkhDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button qlkhXoaBtn;
        private System.Windows.Forms.Button qlkhThemBtn;
        private System.Windows.Forms.Button qlkhTimKiemBtn;
        private System.Windows.Forms.TextBox qlkhMaKHTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView qlkhDgv;
        private System.Windows.Forms.Button qlkhExitBtn;
        private System.Windows.Forms.Button qlkhLamMoiBtn;
    }
}