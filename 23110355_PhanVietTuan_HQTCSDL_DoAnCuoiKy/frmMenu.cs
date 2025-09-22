using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    public partial class frmMenu : Form
    {
        public string conn = "";

        public string username;
        public string password;
        public frmMenu(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            conn = $"Data Source=PHANTUAN;Initial Catalog=QuanLyKhachHangDb;User ID={username};Password={password};TrustServerCertificate=True";
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_PhanQuyenTaiKhoan", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int isThongKe = reader.GetInt32(reader.GetOrdinal("IsThongKe"));
                        int isQuanLyKH = reader.GetInt32(reader.GetOrdinal("IsQuanLyKhachHang"));
                        if (isQuanLyKH == 1)
                        {
                            openTKBtn.Enabled = false;
                            openTKBtn.BackColor = Color.Red;
                            openTKBtn.Text = "Cấm";
                        }
                    }
                }
            };

        }

        private void openQLKHBtn_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang(conn);
            frm.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void openTKBtn_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe(conn);
            frm.ShowDialog();
        }
    }
}
