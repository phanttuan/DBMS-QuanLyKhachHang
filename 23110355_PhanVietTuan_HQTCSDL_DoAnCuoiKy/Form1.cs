using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    public partial class Form1 : Form
    {
        public string conn = "";
        public Form1()
        {
            InitializeComponent();
            conn = "Data Source=PHANTUAN;Initial Catalog=QuanLyKhachHangDb;User ID=sa;Password=1234;TrustServerCertificate=True";
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
