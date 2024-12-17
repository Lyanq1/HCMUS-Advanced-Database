using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DTO;

namespace WinFormsApp1.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return EmployeeDAO.instance; }
            private set { EmployeeDAO.instance = value; }
        }

        private EmployeeDAO() { }

        public List<Employee> GetListEmployee()
        {
            List<Employee> list = new List<Employee>();

            string query = "select * from NhanVien";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item); 
                list.Add(employee);
            }

            return list;    
        }

        public List<Employee> SearchEmployeeByName(string HoTen)
        {
            List<Employee> list = new List<Employee>();

            string query = string.Format("select * from NhanVien where HoTen like N'%{0}%'", HoTen);

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }

            return list;
        }
        public bool InsertEmployee(string maNhanVien, string hoTen, string ngaySinh, string gioiTinh, string ngayVaoLam, string ngayNghiViec, string boPhanPhuTrach, string chiNhanhLamViec)
        {
            string query = string.Format(
            "INSERT INTO dbo.NhanVien (MaNhanVien, HoTen, NgaySinh, GioiTinh, NgayVaoLam, NgayNghiViec, BoPhanPhuTrach, ChiNhanhLamViec) " +
            "VALUES (N'{0}', N'{1}', {2}, N'{3}', {4}, {5}, N'{6}', N'{7}')",
            maNhanVien, hoTen,
            string.IsNullOrEmpty(ngaySinh) ? "NULL" : $"'{ngaySinh}'",
            gioiTinh,
            string.IsNullOrEmpty(ngayVaoLam) ? "NULL" : $"'{ngayVaoLam}'",
            string.IsNullOrEmpty(ngayNghiViec) ? "NULL" : $"'{ngayNghiViec}'",
            boPhanPhuTrach, chiNhanhLamViec
            );

            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateEmployee(string maNhanVien, string hoTen, string ngaySinh, string gioiTinh, string ngayVaoLam, string ngayNghiViec, string boPhanPhuTrach, string chiNhanhLamViec)
        {
            string query = string.Format(
            "UPDATE dbo.NhanVien " +
            "SET HoTen = N'{1}', " +
            "NgaySinh = {2}, " +
            "GioiTinh = N'{3}', " +
            "NgayVaoLam = {4}, " +
            "NgayNghiViec = {5}, " +
            "BoPhanPhuTrach = N'{6}', " +
            "ChiNhanhLamViec = N'{7}' " +
            "WHERE MaNhanVien = N'{0}'",
            maNhanVien, hoTen,
            string.IsNullOrEmpty(ngaySinh) ? "NULL" : $"'{ngaySinh}'",
            gioiTinh,
            string.IsNullOrEmpty(ngayVaoLam) ? "NULL" : $"'{ngayVaoLam}'",
            string.IsNullOrEmpty(ngayNghiViec) ? "NULL" : $"'{ngayNghiViec}'",
            boPhanPhuTrach, chiNhanhLamViec
            );

            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
