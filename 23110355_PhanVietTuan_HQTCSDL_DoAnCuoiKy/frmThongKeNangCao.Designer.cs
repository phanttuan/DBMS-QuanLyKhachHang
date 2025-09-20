namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    partial class frmThongKeNangCao
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
            this.tkncLoaiCmb = new System.Windows.Forms.ComboBox();
            this.tkncQuyCmb = new System.Windows.Forms.ComboBox();
            this.tkncNamCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tkncDgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tkncThongKeBtn = new System.Windows.Forms.Button();
            this.soLuongNm = new System.Windows.Forms.NumericUpDown();
            this.soLuongLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tkncDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soLuongNm)).BeginInit();
            this.SuspendLayout();
            // 
            // tkncLoaiCmb
            // 
            this.tkncLoaiCmb.FormattingEnabled = true;
            this.tkncLoaiCmb.Items.AddRange(new object[] {
            "Khách mới",
            "Khách chi tiêu nhiều nhất",
            "Tần suất mua hàng",
            "Khách ngưng mua"});
            this.tkncLoaiCmb.Location = new System.Drawing.Point(15, 34);
            this.tkncLoaiCmb.Name = "tkncLoaiCmb";
            this.tkncLoaiCmb.Size = new System.Drawing.Size(150, 24);
            this.tkncLoaiCmb.TabIndex = 0;
            this.tkncLoaiCmb.SelectedIndexChanged += new System.EventHandler(this.tkncLoaiCmb_SelectedIndexChanged);
            // 
            // tkncQuyCmb
            // 
            this.tkncQuyCmb.FormattingEnabled = true;
            this.tkncQuyCmb.Items.AddRange(new object[] {
            "Q1",
            "Q2",
            "Q3",
            "Q4"});
            this.tkncQuyCmb.Location = new System.Drawing.Point(15, 91);
            this.tkncQuyCmb.Name = "tkncQuyCmb";
            this.tkncQuyCmb.Size = new System.Drawing.Size(150, 24);
            this.tkncQuyCmb.TabIndex = 1;
            // 
            // tkncNamCmb
            // 
            this.tkncNamCmb.FormattingEnabled = true;
            this.tkncNamCmb.Location = new System.Drawing.Point(15, 149);
            this.tkncNamCmb.Name = "tkncNamCmb";
            this.tkncNamCmb.Size = new System.Drawing.Size(150, 24);
            this.tkncNamCmb.TabIndex = 2;
            this.tkncNamCmb.SelectedIndexChanged += new System.EventHandler(this.tkncNamCmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kết quả";
            // 
            // tkncDgv
            // 
            this.tkncDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tkncDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tkncDgv.Location = new System.Drawing.Point(186, 31);
            this.tkncDgv.Name = "tkncDgv";
            this.tkncDgv.RowHeadersWidth = 51;
            this.tkncDgv.RowTemplate.Height = 24;
            this.tkncDgv.Size = new System.Drawing.Size(631, 404);
            this.tkncDgv.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Loại thống kê";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quý";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Năm";
            // 
            // tkncThongKeBtn
            // 
            this.tkncThongKeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(78)))), ((int)(((byte)(55)))));
            this.tkncThongKeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tkncThongKeBtn.ForeColor = System.Drawing.Color.White;
            this.tkncThongKeBtn.Location = new System.Drawing.Point(15, 397);
            this.tkncThongKeBtn.Name = "tkncThongKeBtn";
            this.tkncThongKeBtn.Size = new System.Drawing.Size(153, 38);
            this.tkncThongKeBtn.TabIndex = 8;
            this.tkncThongKeBtn.Text = "Thống kê";
            this.tkncThongKeBtn.UseVisualStyleBackColor = false;
            this.tkncThongKeBtn.Click += new System.EventHandler(this.tkncThongKeBtn_Click);
            // 
            // soLuongNm
            // 
            this.soLuongNm.Location = new System.Drawing.Point(15, 205);
            this.soLuongNm.Name = "soLuongNm";
            this.soLuongNm.Size = new System.Drawing.Size(150, 22);
            this.soLuongNm.TabIndex = 9;
            // 
            // soLuongLbl
            // 
            this.soLuongLbl.AutoSize = true;
            this.soLuongLbl.Location = new System.Drawing.Point(12, 186);
            this.soLuongLbl.Name = "soLuongLbl";
            this.soLuongLbl.Size = new System.Drawing.Size(121, 16);
            this.soLuongLbl.TabIndex = 10;
            this.soLuongLbl.Text = "Số lượng hiển thị";
            // 
            // frmThongKeNangCao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(829, 450);
            this.Controls.Add(this.soLuongLbl);
            this.Controls.Add(this.soLuongNm);
            this.Controls.Add(this.tkncThongKeBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tkncDgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tkncNamCmb);
            this.Controls.Add(this.tkncQuyCmb);
            this.Controls.Add(this.tkncLoaiCmb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmThongKeNangCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê nâng cao";
            this.Load += new System.EventHandler(this.frmThongKeNangCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tkncDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soLuongNm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tkncLoaiCmb;
        private System.Windows.Forms.ComboBox tkncQuyCmb;
        private System.Windows.Forms.ComboBox tkncNamCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tkncDgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button tkncThongKeBtn;
        private System.Windows.Forms.NumericUpDown soLuongNm;
        private System.Windows.Forms.Label soLuongLbl;
    }
}