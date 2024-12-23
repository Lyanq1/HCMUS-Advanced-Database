using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinFormsApp1.DAO.DTO
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal SoTienDuocGiam { get; set; }
        public decimal TongTien { get; set; }
        public string MaPhieu { get; set; }

        public HoaDon(string maHoaDon, decimal thanhTien, decimal soTienDuocGiam, decimal tongTien, string maPhieu)
        {
            MaHoaDon = maHoaDon;
            ThanhTien = thanhTien;
            SoTienDuocGiam = soTienDuocGiam;
            TongTien = tongTien;
            MaPhieu = maPhieu;
        }

        public HoaDon(DataRow row)
        {
            MaHoaDon = row["MaHoaDon"].ToString();

            // Kiểm tra và xử lý DBNull với giá trị mặc định
            ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : 0;
            SoTienDuocGiam = row["SoTienDuocGiam"] != DBNull.Value ? Convert.ToDecimal(row["SoTienDuocGiam"]) : 0;
            TongTien = row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : 0;

            MaPhieu = row["MaPhieu"].ToString();
        }
    }
}
