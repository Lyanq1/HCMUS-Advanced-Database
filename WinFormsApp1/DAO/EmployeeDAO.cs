using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { return instance ??= new EmployeeDAO(); }
            private set { instance = value; }
        }

        private EmployeeDAO() { }

        public List<Employee> GetListEmployee()
        {
            List<Employee> list = new List<Employee>();
            string query = "SELECT * FROM NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }

            return list;
        }

        public List<Employee> SearchEmployeeByName(string hoTen)
        {
            List<Employee> list = new List<Employee>();
            string query = "SELECT * FROM NhanVien WHERE HoTen LIKE @HoTen";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HoTen", $"%{hoTen}%")
            };

            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }

            return list;
        }

        public bool InsertEmployee(string maNhanVien, string hoTen, string ngaySinh, string gioiTinh, decimal? luong, string ngayVaoLam, string ngayNghiViec, string boPhanPhuTrach, string chiNhanhLamViec)
        {
            string query = @"
                INSERT INTO dbo.NhanVien (MaNhanVien, HoTen, NgaySinh, GioiTinh, Luong, NgayVaoLam, NgayNghiViec, BoPhanPhuTrach, ChiNhanhLamViec)
                VALUES (@MaNhanVien, @HoTen, @NgaySinh, @GioiTinh, @Luong, @NgayVaoLam, @NgayNghiViec, @BoPhanPhuTrach, @ChiNhanhLamViec)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", string.IsNullOrEmpty(ngaySinh) ? DBNull.Value : (object)DateTime.Parse(ngaySinh)),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@Luong", luong.HasValue ? (object)luong.Value : DBNull.Value),
                new SqlParameter("@NgayVaoLam", string.IsNullOrEmpty(ngayVaoLam) ? DBNull.Value : (object)DateTime.Parse(ngayVaoLam)),
                new SqlParameter("@NgayNghiViec", string.IsNullOrEmpty(ngayNghiViec) ? DBNull.Value : (object)DateTime.Parse(ngayNghiViec)),
                new SqlParameter("@BoPhanPhuTrach", boPhanPhuTrach),
                new SqlParameter("@ChiNhanhLamViec", chiNhanhLamViec)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        public bool UpdateEmployee(string maNhanVien, string hoTen, string ngaySinh, string gioiTinh, decimal? luong, string ngayVaoLam, string ngayNghiViec, string boPhanPhuTrach, string chiNhanhLamViec)
        {
            string query = @"
                UPDATE dbo.NhanVien
                SET HoTen = @HoTen, 
                    NgaySinh = @NgaySinh, 
                    GioiTinh = @GioiTinh, 
                    Luong = @Luong, 
                    NgayVaoLam = @NgayVaoLam, 
                    NgayNghiViec = @NgayNghiViec, 
                    BoPhanPhuTrach = @BoPhanPhuTrach, 
                    ChiNhanhLamViec = @ChiNhanhLamViec
                WHERE MaNhanVien = @MaNhanVien";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", string.IsNullOrEmpty(ngaySinh) ? DBNull.Value : (object)DateTime.Parse(ngaySinh)),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@Luong", luong.HasValue ? (object)luong.Value : DBNull.Value),
                new SqlParameter("@NgayVaoLam", string.IsNullOrEmpty(ngayVaoLam) ? DBNull.Value : (object)DateTime.Parse(ngayVaoLam)),
                new SqlParameter("@NgayNghiViec", string.IsNullOrEmpty(ngayNghiViec) ? DBNull.Value : (object)DateTime.Parse(ngayNghiViec)),
                new SqlParameter("@BoPhanPhuTrach", boPhanPhuTrach),
                new SqlParameter("@ChiNhanhLamViec", chiNhanhLamViec)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }

        public bool DeleteEmployee(string maNhanVien)
        {
            string query = "DELETE FROM dbo.NhanVien WHERE MaNhanVien = @MaNhanVien";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNhanVien", maNhanVien)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return result > 0;
        }
    }
}


