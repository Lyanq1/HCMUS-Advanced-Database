using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using WinFormsApp1.DAO.DTO;

namespace WinFormsApp1.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        private static readonly object lockObj = new object();

        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                            instance = new HoaDonDAO();
                    }
                }
                return instance;
            }
        }

        private HoaDonDAO() { }

        public void UpdateHoaDon()
        {
            string query = "sp_UpdateHoaDon";

            // Gọi procedure từ C#
            DataProvider.Instance.ExecuteNonQuery(query, commandType: CommandType.StoredProcedure);
        }


        public string GetMaxMaHoaDon()
        {
            string query = "SELECT TOP 1 MaHoaDon FROM HoaDon ORDER BY CAST(SUBSTRING(MaHoaDon, 4, LEN(MaHoaDon) - 3) AS INT) DESC";

            object result = DataProvider.Instance.ExecuteScalar(query);
            return result?.ToString() ?? "HD_0";
        }


        // Tạo hóa đơn mới
        public void InsertHoaDon(string maHoaDon, decimal thanhTien, decimal soTienDuocGiam, decimal tongTien, string maPhieu)
        {
            string query = @"
        INSERT INTO HoaDon (MaHoaDon, ThanhTien, SoTienDuocGiam, TongTien, MaPhieu)
        VALUES (@maHoaDon, @thanhTien, @soTienDuocGiam, @tongTien, @maPhieu)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@maHoaDon", maHoaDon),
        new SqlParameter("@thanhTien", thanhTien), // Trước giảm giá
        new SqlParameter("@soTienDuocGiam", soTienDuocGiam), // Số tiền được giảm
        new SqlParameter("@tongTien", tongTien), // Sau giảm giá
        new SqlParameter("@maPhieu", maPhieu)
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }


        public decimal GetGiamGiaByMaPhieu(string maPhieuDat)
        {
            string query = @"
        SELECT t.GiamGia
        FROM PhieuDatMon p
        JOIN THE t ON p.MaKhachHang = t.MaKhachHang
        WHERE p.MaPhieuDat = @MaPhieuDat";

            SqlParameter param = new SqlParameter("@MaPhieuDat", maPhieuDat);

            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { param });

            // Kiểm tra nếu giá trị NULL
            if (result == DBNull.Value || result == null)
            {
                return 0; // Mặc định nếu không có giảm giá
            }

            return Convert.ToDecimal(result);
        }



        // Lấy tổng tiền dựa trên MaPhieuDat
        public decimal GetTongTienByMaPhieu(string maPhieuDat)
        {
            string query = @"
        SELECT SUM(ChiTietPhieuDat.SoLuongMon * MON.GiaHienTai) AS TongTien
        FROM ChiTietPhieuDat
        INNER JOIN MON ON ChiTietPhieuDat.MaMon = MON.MaMon
        WHERE ChiTietPhieuDat.MaPhieuDat = @maPhieuDat";

            SqlParameter param = new SqlParameter("@maPhieuDat", maPhieuDat);
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { param });

            // Kiểm tra nếu kết quả là DBNull
            if (result == DBNull.Value || result == null)
            {
                return 0; // Hoặc giá trị mặc định khác
            }

            return Convert.ToDecimal(result);
        }


        // Lấy danh sách hóa đơn theo MaPhieu
        public List<HoaDon> GetHoaDonByMaPhieu(string maPhieu)
        {
            List<HoaDon> hoaDonList = new List<HoaDon>();

            string query = "SELECT * FROM HoaDon WHERE MaPhieu = @maPhieu";

            SqlParameter param = new SqlParameter("@maPhieu", maPhieu);
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { param });

            foreach (DataRow row in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(row);
                hoaDonList.Add(hoaDon);
            }

            return hoaDonList;
        }

    }
}
