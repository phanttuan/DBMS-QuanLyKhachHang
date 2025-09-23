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
            khdHangTxt.Enabled = false;
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
                        if (isThongKe == 1)
                        {
                            khdSuaBtn.Enabled = false;
                            khdSuaBtn.BackColor = Color.Red;
                            khdSuaBtn.Text = "Cấm";
                            khdThemBtn.Enabled = false;
                            khdThemBtn.BackColor = Color.Red;
                            khdThemBtn.Text = "Cấm";
                            khdHoTenTxt.Enabled = false;
                            khdGioiTinhCmb.Enabled = false;
                            khdSDTTxt.Enabled = false;
                            khdNgaySinhDtp.Enabled = false;
                            khdEmailTxt.Enabled = false;
                        }
                    }
                }
            };
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
                        khdHoTenTxt.Text = row["Họ tên"].ToString();
                        string gioiTinh = row["Giới tính"].ToString();
                        if (gioiTinh == "Nam") {
                            khdGioiTinhCmb.SelectedItem = khdGioiTinhCmb.Items[0];
                        }
                        else
                        {
                             khdGioiTinhCmb.SelectedItem = khdGioiTinhCmb.Items[1];
                        }
                            khdSDTTxt.Text = row["SĐT"].ToString();
                        khdNgaySinhDtp.Value = Convert.ToDateTime(row["Ngày sinh"]);
                        khdEmailTxt.Text = row["Email"].ToString();
                        khdHangTxt.Text = row["Hạng thành viên"].ToString();

                    }

                }
            }
            if (string.IsNullOrWhiteSpace(khdHoTenTxt.Text)) {
                khdSuaBtn.Visible = false;
            }
            else 
                 khdThemBtn.Visible = false;

        }

        private void khdDongBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void khdLuuBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void khdThemBtn_Click(object sender, EventArgs e)
        {
            string hoTen = khdHoTenTxt.Text;
            if(string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string gioiTinh;
            if (khdGioiTinhCmb.SelectedItem == khdGioiTinhCmb.Items[0])
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }
            string sdt = khdSDTTxt.Text;
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime ngaySinh = khdNgaySinhDtp.Value;
            string email = khdEmailTxt.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void khdSuaBtn_Click(object sender, EventArgs e)
        {
            string hoTen = khdHoTenTxt.Text;
            string gioiTinh;
            gioiTinh = khdGioiTinhCmb.SelectedItem.ToString().Trim();
            string sdt = khdSDTTxt.Text;
            DateTime ngaySinh = khdNgaySinhDtp.Value;
            string email = khdEmailTxt.Text;

            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                try
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
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
