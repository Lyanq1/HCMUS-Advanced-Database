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
    public partial class fSignup : Form
    {
        string tendangnhap;
        string matkhau;
        string connectString = @"Data Source = LYAN\SQLEXPRESS01;Initial Catalog = SuShiX;Integrated Security = True; Trust Server Certificate=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        public fSignup()
        {
            InitializeComponent();
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fSignup_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tendangnhap = textBox1.Text.Trim().ToString();
            matkhau = txbUserName.Text.Trim().ToString();
            string sql = "select tk.Password from TaiKhoan tk where tk.Password= '" + matkhau + "' ";
            Connection.Connect();
            //if (tendangnhap == "")
            //{
            //    MessageBox.Show("Vui lòng nhập tên đăng nhập");
            //}
            //else if (matkhau == "")
            //{
            //    MessageBox.Show("Vui lòng nhập tên mật khẩu");
            //}
            //else if (matkhau != txbPassword.Text.Trim().ToString())
            //{
            //    MessageBox.Show("Xác nhận mật khẩu không khớp với mật khẩu");
            //}
            //else if (Connection.GetFieldValues(sql).Count() != 0)
            //{
            //    MessageBox.Show("Mật khẩu đã trùng");
            //}
            //else
            //{
            //string sql1 = "insert into TaiKhoan values ('" + tendangnhap + "','" + matkhau + "')";
            //Connection.RunSQL(sql1);
            //MessageBox.Show("Đăng ký thành công");

            // Connect to database
            //    Connection.Connect();
            //    con.Open();

            //    // Check if username already exists
            //    string checkUserSql = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            //    SqlCommand checkUserCmd = new SqlCommand(checkUserSql, con);
            //    checkUserCmd.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
            //    int userExists = (int)checkUserCmd.ExecuteScalar();

            //    if (userExists > 0)
            //    {
            //        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    // Generate the next TaiKhoan ID (KH_*)
            //    string getNextIdSql = @"
            //SELECT 'KH_' + CAST(MAX(CAST(SUBSTRING(TaiKhoan, 4, LEN(TaiKhoan) - 3) AS INT)) + 1 AS NVARCHAR(20))
            //FROM TaiKhoan
            //WHERE TaiKhoan LIKE 'KH_%'";
            //    SqlCommand getNextIdCmd = new SqlCommand(getNextIdSql, con);
            //    string newTaiKhoanId = (string)getNextIdCmd.ExecuteScalar() ?? "KH_10501"; // Default to KH_10501 if no records exist.

            //    // Insert new user into TaiKhoan
            //    string insertTaiKhoanSql = "INSERT INTO TaiKhoan (MATAIKHOAN, TenDangNhap, MatKhau, ISNV, ISQUANTRI, ISUSER) " +
            //                               "VALUES (@MaTaiKhoan, @TenDangNhap, @MatKhau, False, False, True)";
            //    SqlCommand insertTaiKhoanCmd = new SqlCommand(insertTaiKhoanSql, con);
            //    insertTaiKhoanCmd.Parameters.AddWithValue("@MaTaiKhoan", newTaiKhoanId.Replace("KH_", ""));
            //    insertTaiKhoanCmd.Parameters.AddWithValue("@TenDangNhap", tendangnhap);
            //    insertTaiKhoanCmd.Parameters.AddWithValue("@MatKhau", matkhau);
            //    insertTaiKhoanCmd.ExecuteNonQuery();

            //    // Insert into KhachHang
            //    string insertKhachHangSql = "INSERT INTO KhachHang (MaKhachHang, HoTen, SoDienThoai, Email, SoCCCD, GioiTinh) " +
            //                                "VALUES (@MaKH, @HoTen, @SoDienThoai, @Email, @SoCCCD, @ioiTinh)";
            //    SqlCommand insertKhachHangCmd = new SqlCommand(insertKhachHangSql, con);
            //    insertKhachHangCmd.Parameters.AddWithValue("@MaKH", newTaiKhoanId.Replace("KH_", "")); // Use numeric part of TaiKhoan ID.
            //    insertKhachHangCmd.Parameters.AddWithValue("@HoTen", newTaiKhoanId);
            //    insertKhachHangCmd.Parameters.AddWithValue("@SoDienThoai", null);
            //    insertKhachHangCmd.Parameters.AddWithValue("@Email", null);
            //    insertKhachHangCmd.Parameters.AddWithValue("@SoCCCD", null);
            //    insertKhachHangCmd.Parameters.AddWithValue("@GioiTinh", null);
            //    insertKhachHangCmd.ExecuteNonQuery();

            //    // Show success message
            //    MessageBox.Show($"Tài khoản đã được đăng ký thành công!\nMã tài khoản: {newTaiKhoanId}",
            //                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }
    }
}
