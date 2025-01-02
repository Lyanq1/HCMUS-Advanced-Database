using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.SqlClient;

using WinFormsApp1.DAO;


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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(pass.Text) || string.IsNullOrEmpty(confirm.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu nhập lại
            if (pass.Text != confirm.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkNhanVien.Checked)
            {
                DangKyNhanVien();
            }
            else
            {
                DangKyKhachHang();
            }
        }

        private void DangKyNhanVien()
        {
            try
            {
                string maNV = (string)DataProvider.Instance.ExecuteScalar("SELECT 'NV_' + CAST(ISNULL(MAX(CAST(SUBSTRING(MaNhanVien, 4, LEN(MaNhanVien) - 3) AS INT)), 1000) + 1 AS VARCHAR) FROM NhanVien");

                string query = "INSERT INTO NhanVien (MaNhanVien, HoTen, NgaySinh, GioiTinh, Luong, NgayVaoLam) " +
                               "VALUES (@MaNV, @HoTen, @NgaySinh, @GioiTinh, @Luong, @NgayVaoLam)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@HoTen", username.Text),
                    new SqlParameter("@NgaySinh", DateTime.Now), // Đặt tạm
                    new SqlParameter("@GioiTinh", "Nam"),        // Đặt tạm
                    new SqlParameter("@Luong", 10000000),        // Đặt tạm
                    new SqlParameter("@NgayVaoLam", DateTime.Now)
                };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                TaoTaiKhoan(maNV, true); // Tạo tài khoản cho nhân viên
                MessageBox.Show("Đăng ký nhân viên thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DangKyKhachHang()
        {
            try
            {
                string maKH = (string)DataProvider.Instance.ExecuteScalar("SELECT 'KH_' + CAST(ISNULL(MAX(CAST(SUBSTRING(MaKhachHang, 4, LEN(MaKhachHang) - 3) AS INT)), 1000) + 1 AS VARCHAR) FROM KhachHang");

                string query = "INSERT INTO KhachHang (MaKhachHang, HoTen, SoDienThoai, Email, GioiTinh) " +
                               "VALUES (@MaKH, @HoTen, @SoDienThoai, @Email, @GioiTinh)";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaKH", maKH),
                    new SqlParameter("@HoTen", username.Text),
                    new SqlParameter("@SoDienThoai", "0123456789"), // Đặt tạm
                    new SqlParameter("@Email", "test@gmail.com"),   // Đặt tạm
                    new SqlParameter("@GioiTinh", "Nữ")             // Đặt tạm
                };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                TaoTaiKhoan(maKH, false); // Tạo tài khoản cho khách hàng
                MessageBox.Show("Đăng ký khách hàng thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaoTaiKhoan(string ma, bool isNV)
        {
            try
            {
                string query = "INSERT INTO TaiKhoan (MaTaiKhoan, TenDangNhap, MatKhau, IsNV, IsQuanTri, IsUser) " +
                               "VALUES (@Ma, @TenDangNhap, @MatKhau, @IsNV, 0, @IsUser)";

                SqlParameter[] parameters =
                {
    new SqlParameter("@Ma", ma),
    new SqlParameter("@TenDangNhap", username.Text),
    new SqlParameter("@MatKhau", pass.Text),
    new SqlParameter("@IsNV", chkNhanVien.Checked ? 1 : 0),
    new SqlParameter("@IsQuanTri", false),  // Truyền giá trị bool
    new SqlParameter("@IsUser", chkNhanVien.Checked ? 0 : 1)
};


                DataProvider.Instance.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fSignup_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tendangnhap = username.Text.Trim().ToString();
            matkhau = pass.Text.Trim().ToString();
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
