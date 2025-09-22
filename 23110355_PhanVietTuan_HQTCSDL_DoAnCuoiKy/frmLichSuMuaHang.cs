using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    public partial class frmLichSuMuaHang : Form
    {
        public string conn;
        public int maKH;
        public frmLichSuMuaHang(string conn, int maKH, DateTime tuNgay, DateTime denNgay)
        {
            InitializeComponent();
            this.conn = conn;
            this.maKH = maKH;
            lsTuNgayDtp.Value = tuNgay;
            lsDenNgayDtp.Value =denNgay;
        }

        public void LoadLichSuMuaHang(int maKH, DateTime tuNgay, DateTime denNgay){
            using (SqlConnection sqlConn = new SqlConnection(conn)) {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_LichSuMuaHang", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                lsDgv.DataSource = dt;
            
            }
        
        }

        public float TinhTongTien(string conn, int maKH, DateTime tuNgay, DateTime denNgay) {
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.fn_TinhTongChiTieuMotKhach(@MaKH, @TuNgay, @DenNgay)", sqlConn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                object tongTien = cmd.ExecuteScalar();
                float result = Convert.ToInt64(tongTien);
                return result;
            }
        }

        private void frmLichSuMuaHang_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiThongTinKhachHang", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lsMaKHTxt.Text = row["Mã KH"].ToString();
                    lsHoTenTxt.Text = row["Họ tên"].ToString();
                    string gioiTinh = row["Giới tính"].ToString();
                    if (gioiTinh == "Nam")
                    {
                        lsGioiTinhCmb.SelectedItem = lsGioiTinhCmb.Items[0];
                    }
                    else
                    {
                        lsGioiTinhCmb.SelectedItem = lsGioiTinhCmb.Items[1];
                    }
                    lsSDTTxt.Text = row["SĐT"].ToString();
                    lsEmailTxt.Text = row["Email"].ToString();
                    lsHangTxt.Text = row["Hạng thành viên"].ToString();
                }

            }
            DateTime tuNgay =lsTuNgayDtp.Value.Date;
            DateTime denNgay = lsDenNgayDtp.Value.Date;
            LoadLichSuMuaHang(maKH, tuNgay, denNgay);
            lsTongTxt.Text = TinhTongTien(conn, maKH, tuNgay, denNgay).ToString();
        }

        private void lsLocBtn_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = lsTuNgayDtp.Value.Date;
            DateTime denNgay = lsDenNgayDtp.Value.Date;
            LoadLichSuMuaHang(maKH, tuNgay, denNgay);
            lsTongTxt.Text = TinhTongTien(conn, maKH, tuNgay, denNgay).ToString();
        }

        private void lsQuayLaiBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
