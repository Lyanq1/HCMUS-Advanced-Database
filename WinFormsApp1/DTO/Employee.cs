using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DTO
{
    public class Employee
    {
        public Employee(string maNhanVien, string hoTen, string ngaySinh, string gioiTinh, decimal? luong, string ngayVaoLam, string ngayNghiViec, string boPhanPhuTrach, string chiNhanhLamViec)
        {
            this.MaNhanVien = maNhanVien;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.Luong = luong;
            this.NgayVaoLam = ngayVaoLam;
            this.NgayNghiViec = ngayNghiViec;
            this.BoPhanPhuTrach = boPhanPhuTrach;
            this.ChiNhanhLamViec = chiNhanhLamViec;
        }

        public Employee(DataRow row)
        {
            this.MaNhanVien = row["MaNhanVien"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.NgaySinh = row["NgaySinh"] == DBNull.Value ? null : Convert.ToDateTime(row["NgaySinh"]).ToString("yyyy-MM-dd");
            this.GioiTinh = row["GioiTinh"].ToString();
            this.Luong = row["Luong"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["Luong"]);
            this.NgayVaoLam = row["NgayVaoLam"] == DBNull.Value ? null : Convert.ToDateTime(row["NgayVaoLam"]).ToString("yyyy-MM-dd");
            this.NgayNghiViec = row["NgayNghiViec"] == DBNull.Value ? null : Convert.ToDateTime(row["NgayNghiViec"]).ToString("yyyy-MM-dd");
            this.BoPhanPhuTrach = row["BoPhanPhuTrach"].ToString();
            this.ChiNhanhLamViec = row["ChiNhanhLamViec"].ToString();
        }

        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public decimal? Luong { get; set; }
        public string NgayVaoLam { get; set; }
        public string NgayNghiViec { get; set; }
        public string BoPhanPhuTrach { get; set; }
        public string ChiNhanhLamViec { get; set; }
    }
}
