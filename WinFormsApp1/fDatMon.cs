using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.SqlClient;
using WinFormsApp1.DAO.DTO;
using WinFormsApp1.DAO;

namespace WinFormsApp1
{
    public partial class fDatMon : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = LYAN\SQLEXPRESS01;Initial Catalog = SuShiX;Integrated Security = True; Trust Server Certificate=True");
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        string latestMaPhieuDat = "";
        string MaMon = "";
        public fDatMon()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["TenMon"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["GiaHienTai"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["MaMon"].Value.ToString();
        }


        private void LoadData()
        {
            Connection.Connect();

            string sql = "select m.MaMon, m.TenMon, mu.TenMuc, m.GiaHienTai, " +
                "cn.Ten from mon m join muc mu on mu.MaMuc = m.MaMuc join THUCDON td on td.MaThucDon = mu.MaThucDon " +
                "join CHINHANH cn on cn.MaChiNhanh = td.MaChiNhanh where cn.Ten = N'" + khachhang.Ten + "'";
            dataGridView1.DataSource = Connection.GetDataToTable(sql);

            dataGridView1.Font = new Font("Time New Roman", 13);
            dataGridView1.Columns[0].HeaderText = "Mã món";
            dataGridView1.Columns[1].HeaderText = "Tên món";
            dataGridView1.Columns[2].HeaderText = "Tên mục";
            dataGridView1.Columns[3].HeaderText = "Giá";
            dataGridView1.Columns[4].HeaderText = "Tên chi nhánh";

            dataGridView1.DefaultCellStyle.Font = new Font("Time New Roman", 13);
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 300;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            Connection.Disconnect();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Connection.Connect();
            //con.Open();
            //SqlCommand cmd = new SqlCommand("sp_GetLatestMaPhieuDat", con);
            //cmd.ExecuteNonQuery();
            //object result = cmd.ExecuteScalar();
            //latestMaPhieuDat = result.ToString();
            //MaMon = textBox1.Text.Trim().ToString();
            //// Lệnh SQL để chèn dữ liệu

            //string sql = "INSERT INTO ChiTietPhieuDat " +
            //             "VALUES'" + latestMaPhieuDat + "','" + MaMon + "','" + 1 +"'";
            //Connection.RunSQL(sql);
            //    Connection.Disconnect();
            Connection.Connect();
            con.Open();

            // Gọi stored procedure để lấy mã phiếu đặt mới nhất
            SqlCommand cmd = new SqlCommand("SELECT dbo.fn_GetNextMaPhieuDat()", con);
            object result = cmd.ExecuteScalar();
            string latestMaPhieuDat = result.ToString();

            // Lấy mã món từ textbox
            string MaMon = textBox4.Text.Trim();

            // Lệnh SQL để chèn dữ liệu vào bảng ChiTietPhieuDat
            string sql = "INSERT INTO ChiTietPhieuDat (MaPhieuDat, MaMon, SoLuongMon) " +
                         "VALUES (@MaPhieuDat, @MaMon, @SoLuongMon)";

            // Chuẩn bị câu lệnh SQL với tham số để tránh lỗi SQL Injection
            SqlCommand insertCmd = new SqlCommand(sql, con);
            insertCmd.Parameters.AddWithValue("@MaPhieuDat", latestMaPhieuDat);
            insertCmd.Parameters.AddWithValue("@MaMon", MaMon);
            insertCmd.Parameters.AddWithValue("@SoLuongMon", 1);

            // Thực thi lệnh SQL
            insertCmd.ExecuteNonQuery();
            MessageBox.Show($"Món đã được thêm vào ChiTietPhieuDat với mã phiếu đặt: {latestMaPhieuDat}",
                      "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Đóng kết nối
            con.Close();
            Connection.Disconnect();

        }

        private void fDatMon_Load(object sender, EventArgs e)
        {

        }

        private void fDatMon_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                try
                {
                    // Lấy mã phiếu đặt mới nhất
                    string query = "SELECT dbo.fn_GetNextMaPhieuDat()";
                    object result = DataProvider.Instance.ExecuteScalar(query);

                    if (result == null)
                    {
                        MessageBox.Show("Không thể lấy mã phiếu đặt mới nhất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string maPhieuDat = result.ToString();

                    // Kiểm tra nếu đã tồn tại hóa đơn cho mã phiếu đặt
                    List<HoaDon> existingHoaDon = HoaDonDAO.Instance.GetHoaDonByMaPhieu(maPhieuDat);
                    if (existingHoaDon.Any())
                    {
                        MessageBox.Show("Phiếu Đặt này đã được tạo Hóa Đơn trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy tổng tiền và giảm giá
                    decimal thanhTien = HoaDonDAO.Instance.GetTongTienByMaPhieu(maPhieuDat);
                    decimal giamGia = HoaDonDAO.Instance.GetGiamGiaByMaPhieu(maPhieuDat);

                    // Tính toán tiền
                    decimal soTienGiam = thanhTien * giamGia / 100;
                    decimal tongTien = thanhTien - soTienGiam;

                    // Tạo mã hóa đơn mới
                    string maxMaHoaDon = HoaDonDAO.Instance.GetMaxMaHoaDon();
                    int nextNumber = int.Parse(maxMaHoaDon.Substring(3)) + 1;
                    string maHoaDon = "HD_" + nextNumber;

                    // Lưu hóa đơn vào database
                    HoaDonDAO.Instance.InsertHoaDon(maHoaDon, thanhTien, soTienGiam, tongTien, maPhieuDat);

                    // Thông báo thành công
                    MessageBox.Show($"Thanh toán thành công!\nMã Hóa Đơn: {maHoaDon}\nTổng tiền: {tongTien:N2} VNĐ",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }
}
