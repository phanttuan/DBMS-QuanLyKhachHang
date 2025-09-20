using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23110355_PhanVietTuan_HQTCSDL_DoAnCuoiKy
{
    public partial class frmKhachHangDetail : Form
    {
        public string conn;
        public int maKH;
        public frmKhachHangDetail(string conn, int maKH)
        {
            InitializeComponent();
            this.conn = conn;
            this.maKH = maKH;
        }

        private void frmKhachHangDetail_Load(object sender, EventArgs e)
        {
            if (maKH > 0)
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
                        khdHoTenTxt.Text = row["FullName"].ToString();
                        string gioiTinh = row["Gender"].ToString();
                        if (gioiTinh == "M") {
                            khdGioiTinhCmb.SelectedItem = khdGioiTinhCmb.Items[0];
                        }
                        else
                        {
                             khdGioiTinhCmb.SelectedItem = khdGioiTinhCmb.Items[1];
                        }
                            khdSDTTxt.Text = row["PhoneNumber"].ToString();
                        khdNgaySinhDtp.Value = Convert.ToDateTime(row["DateOfBirth"]);
                        khdEmailTxt.Text = row["Email"].ToString();
                        khdHangTxt.Text = row["MembershipTier"].ToString();

                    }

                }
            }
            
        }

        private void khdDongBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void khdLuuBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void qlkhThemBtn_Click(object sender, EventArgs e)
        {
            string hoTen = khdHoTenTxt.Text;
            string gioiTinh;
            if (khdGioiTinhCmb.SelectedItem == khdGioiTinhCmb.Items[0])
            {
                gioiTinh = "M";
            }
            else
            {
                gioiTinh = "F";
            }
            string sdt = khdSDTTxt.Text;
            DateTime ngaySinh = khdNgaySinhDtp.Value;
            string email = khdEmailTxt.Text;

            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemKhachHang", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", hoTen);
                cmd.Parameters.AddWithValue("@Gender", gioiTinh);
                cmd.Parameters.AddWithValue("@PhoneNumber", sdt);
                cmd.Parameters.AddWithValue("@DateOfBirth", ngaySinh);
                cmd.Parameters.AddWithValue("@Email", email);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void khdSuaBtn_Click(object sender, EventArgs e)
        {
            string hoTen = khdHoTenTxt.Text;
            string gioiTinh;
            if (khdGioiTinhCmb.SelectedItem == khdGioiTinhCmb.Items[0])
            {
                gioiTinh = "M";
            }
            else
            {
                gioiTinh = "F";
            }
            string sdt = khdSDTTxt.Text;
            DateTime ngaySinh = khdNgaySinhDtp.Value;
            string email = khdEmailTxt.Text;

            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_SuaKhachHang", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@FullName", hoTen);
                cmd.Parameters.AddWithValue("@Gender", gioiTinh);
                cmd.Parameters.AddWithValue("@PhoneNumber", sdt);
                cmd.Parameters.AddWithValue("@DateOfBirth", ngaySinh);
                cmd.Parameters.AddWithValue("@Email", email);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
