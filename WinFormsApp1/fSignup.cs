using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using WinFormsApp1.DAO;

namespace WinFormsApp1
{
    public partial class fSignup : Form
    {
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
    }
}
