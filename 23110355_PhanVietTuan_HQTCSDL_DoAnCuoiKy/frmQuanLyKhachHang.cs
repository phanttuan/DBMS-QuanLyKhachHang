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
                int maKH = Convert.ToInt32(qlkhDgv.Rows[e.RowIndex].Cells["CustomerID"].Value);
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
            int maKH = Convert.ToInt32(qlkhDgv.SelectedRows[0].Cells["CustomerID"].Value);
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_XoaKhachHang", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadKhachHang();
            }
        }

        private void qlkhLamMoiBtn_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void qlkhTimKiemBtn_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(qlkhMaKHTxt.Text);
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
