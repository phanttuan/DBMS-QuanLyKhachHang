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
    public partial class frmQuanLyKhachHang : Form
    {
        public string conn;
        public frmQuanLyKhachHang(string conn)
        {
            InitializeComponent();
            this.conn = conn;
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
                            qlkhThemBtn.Enabled = false;
                            qlkhThemBtn.BackColor = Color.Red;
                            qlkhThemBtn.Text = "Cấm";
                            qlkhXoaBtn.Enabled = false;
                            qlkhXoaBtn.BackColor = Color.Red;
                            qlkhXoaBtn.Text = "Cấm";
                        }
                    }
                }
            };
        }

        private void qlkhExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadKhachHang ()
        {
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiThongTinKhachHang", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", 0);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                qlkhDgv.DataSource = dt;
            }
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void qlkhDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maKH = Convert.ToInt32(qlkhDgv.Rows[e.RowIndex].Cells["Mã KH"].Value);
                frmKhachHangDetail frm = new frmKhachHangDetail(conn, maKH);
                frm.ShowDialog();
            }
        }

        private void qlkhThemBtn_Click(object sender, EventArgs e)
        {
            frmKhachHangDetail frm = new frmKhachHangDetail(conn, 0);
            frm.ShowDialog();
        }


        private void qlkhXoaBtn_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(qlkhDgv.SelectedRows[0].Cells["Mã KH"].Value);
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand("sp_XoaKhachHang", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadKhachHang();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void qlkhLamMoiBtn_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void qlkhTimKiemBtn_Click(object sender, EventArgs e)
        {
            int maKH;
            if (string.IsNullOrEmpty(qlkhMaKHTxt.Text))
                maKH = 0;
            else
                maKH = Convert.ToInt32(qlkhMaKHTxt.Text);
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_HienThiThongTinKhachHang", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                qlkhDgv.DataSource = dt;
            }

        }

        private void qlkhDgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
