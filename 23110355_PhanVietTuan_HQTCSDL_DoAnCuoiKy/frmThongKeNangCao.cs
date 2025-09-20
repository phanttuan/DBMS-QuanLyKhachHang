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
    public partial class frmThongKeNangCao : Form
    {
        public string conn;
        public frmThongKeNangCao(string conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        public void LoadCmbNam(string conn)
        {
            string query = "SELECT DISTINCT YEAR(OrderDate) AS Nam FROM [Order] ORDER BY Nam DESC";
            DataTable dt = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                sqlDa.Fill(dt);
            }
            tkncNamCmb.DataSource = dt;
            tkncNamCmb.DisplayMember = "Nam";
            tkncNamCmb.ValueMember = "Nam";
        }

        private void frmThongKeNangCao_Load(object sender, EventArgs e)
        {
            LoadCmbNam(conn);
            soLuongLbl.Visible = false;
            soLuongNm.Visible = false;
        }
        public void ThongKeKhachMoiTheoQuy(string quy, int nam)
        {
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_ThongKeKhachMoiTheoQuy(@Quy, @Nam)",sqlConn);
                cmd.Parameters.AddWithValue("@Quy", quy);
                cmd.Parameters.AddWithValue("Nam", nam);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                tkncDgv.DataSource = dt;
            }
        }

        public void ThongKeKhachChiTieuTheoQuy(int soLuong, int quy, int nam) {
            using (SqlConnection sqlConn = new SqlConnection(conn)) {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_ThongKeKhachChiTieuTheoQuy(@soLuong, @Quy, @Nam)", sqlConn);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@Quy", quy);
                cmd.Parameters.AddWithValue("@Nam", nam);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                tkncDgv.DataSource = dt;
            }
        }

        public void ThongKeTanSuatChiTieuTheoQuy(int soLuong, int quy, int nam) {
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_ThongKeTanSuatChiTieuTheoQuy(@soLuong, @Quy, @Nam)", sqlConn);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@Quy", quy);
                cmd.Parameters.AddWithValue("@Nam", nam);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                tkncDgv.DataSource = dt;
            }

        }

        public void ThongKeKhachHangNgungMua(int quy, int nam) {
            using (SqlConnection sqlConn = new SqlConnection(conn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_ThongKeKhachNgungMua(@Quy, @Nam)", sqlConn);
                cmd.Parameters.AddWithValue("@Quy", quy);
                cmd.Parameters.AddWithValue("Nam", nam);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                tkncDgv.DataSource = dt;
            }
        }

        private void tkncThongKeBtn_Click(object sender, EventArgs e)
        {
            int soLuong;
            string quyStr;
            int nam;
            int quyInt;
            if (tkncLoaiCmb.SelectedIndex == 0)
            {
                quyStr = tkncQuyCmb.SelectedItem.ToString();
                nam = Convert.ToInt32(tkncNamCmb.SelectedValue);
                ThongKeKhachMoiTheoQuy(quyStr, nam);
            }
            else if (tkncLoaiCmb.SelectedIndex == 1)
            {
                soLuongLbl.Visible = true;
                soLuongNm.Visible = true;
                soLuong = Convert.ToInt32(soLuongNm.Value);
                nam = Convert.ToInt32(tkncNamCmb.SelectedValue);
                switch (tkncQuyCmb.SelectedIndex)
                {
                    case 0: quyInt = 1; break;
                    case 1: quyInt = 2; break;
                    case 2: quyInt = 3; break;
                    case 3: quyInt = 4; break;
                    default: quyInt = 1; break;
                }
                ThongKeKhachChiTieuTheoQuy(soLuong, quyInt, nam);
            }
            else if (tkncLoaiCmb.SelectedIndex == 2)
            {
                soLuongLbl.Visible = true;
                soLuongNm.Visible = true;
                soLuong = Convert.ToInt32(soLuongNm.Value);
                nam = Convert.ToInt32(tkncNamCmb.SelectedValue);
                switch (tkncQuyCmb.SelectedIndex)
                {
                    case 0: quyInt = 1; break;
                    case 1: quyInt = 2; break;
                    case 2: quyInt = 3; break;
                    case 3: quyInt = 4; break;
                    default: quyInt = 1; break;
                }
                ThongKeTanSuatChiTieuTheoQuy(soLuong, quyInt, nam);
            }
            else if (tkncLoaiCmb.SelectedIndex == 3){
                nam = Convert.ToInt32(tkncNamCmb.SelectedValue);
                switch (tkncQuyCmb.SelectedIndex)
                {
                    case 0: quyInt = 1; break;
                    case 1: quyInt = 2; break;
                    case 2: quyInt = 3; break;
                    case 3: quyInt = 4; break;
                    default: quyInt = 1; break;
                }
                ThongKeKhachHangNgungMua(quyInt, nam);

            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại thống kê");
            }
        }

        private void tkncNamCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tkncLoaiCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tkncLoaiCmb.SelectedIndex == 1 || tkncLoaiCmb.SelectedIndex == 2)
            {
                soLuongLbl.Visible = true;
                soLuongNm.Visible = true;
                tkncQuyCmb.SelectedIndex = -1;
                tkncNamCmb.SelectedIndex = -1;
            }
            else
            {
                soLuongLbl.Visible = false;
                soLuongNm.Visible = false;
                tkncQuyCmb.SelectedIndex = -1;
                tkncNamCmb.SelectedIndex = -1;
            }
        }
    }
}
