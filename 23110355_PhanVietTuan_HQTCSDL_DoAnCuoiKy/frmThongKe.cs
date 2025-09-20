using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    public partial class frmThongKe : Form
    {
        public string conn;
        public frmThongKe(string conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        public void LoadChiTieu(int maKH, DateTime tuNgay, DateTime denNgay){
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiTongChiTieu", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                tkDgv.DataSource = dt;
            }
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            tkLoaiTKCmb.SelectedIndex = 0;
            DateTime tuNgay = DateTime.Now;
            tuNgay = tuNgay.AddDays(-31);
            tkTuNgayDtp.Value = tuNgay;
            DateTime denNgay = DateTime.Now;
            tkDenNgayDtp.Value = denNgay;
            LoadChiTieu(0, tuNgay, denNgay);
        }

        private void tkLocBtn_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = tkTuNgayDtp.Value.Date;
            DateTime denNgay = tkDenNgayDtp.Value.Date;
            int maKH;
            if (string.IsNullOrWhiteSpace(tkMaKHTxt.Text))
            {
                maKH = 0;
            }
            else
            {
                maKH = Convert.ToInt32(tkMaKHTxt.Text);
            }
            if (tkLoaiTKCmb.SelectedIndex == 0)
                LoadChiTieu(maKH, tuNgay, denNgay);
            else
                LoadTanSuatChiTieu(maKH, tuNgay, denNgay);
        }

        public void LoadTanSuatChiTieu(int maKH, DateTime tuNgay, DateTime denNgay){
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiTanSuatChiTieu", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                tkDgv.DataSource = dt;
            }
        }

        private void tkLoaiTKCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tkLoaiTKCmb.SelectedIndex == 0)
            {
                DateTime tuNgay = DateTime.Now; //Xóa sau
                tuNgay = tuNgay.AddDays(-31); //Xóa sau
                tkTuNgayDtp.Value = tuNgay; //Xóa sau
                DateTime denNgay = DateTime.Now;
                tkDenNgayDtp.Value = denNgay;
                LoadChiTieu(0, tuNgay, denNgay);
            }
            else
            {
                DateTime tuNgay = DateTime.Now; //Xóa sau
                tuNgay = tuNgay.AddDays(-31); //Xóa sau
                tkTuNgayDtp.Value = tuNgay; //Xóa sau
                DateTime denNgay = DateTime.Now;
                tkDenNgayDtp.Value = denNgay;
                LoadTanSuatChiTieu(0, tuNgay, denNgay);
            }
        }

        private void tkXemBtn_Click(object sender, EventArgs e)
        {
            if (tkDgv.SelectedRows.Count > 0)
            {
                int maKH = Convert.ToInt32(tkDgv.SelectedRows[0].Cells["CustomerID"].Value);
                frmLichSuMuaHang lichSuForm = new frmLichSuMuaHang(conn, maKH);
                lichSuForm.ShowDialog();
            }
        }

        private void tkDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tkDgv.SelectedRows.Count > 0)
            {
                int maKH = Convert.ToInt32(tkDgv.SelectedRows[0].Cells["CustomerID"].Value);
                frmLichSuMuaHang lichSuForm = new frmLichSuMuaHang(conn, maKH);
                lichSuForm.ShowDialog();
            }
        }

        private void tkLocNangCaoBtn_Click(object sender, EventArgs e)
        {
            frmThongKeNangCao frm = new frmThongKeNangCao(conn);
            frm.ShowDialog();
        }
    }
}
