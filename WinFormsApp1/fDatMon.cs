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
    }
}
