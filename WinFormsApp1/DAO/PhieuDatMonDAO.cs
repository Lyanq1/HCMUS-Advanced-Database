using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Thay thế System.Data.SqlClient
using WinFormsApp1.DAO.DTO;

namespace WinFormsApp1.DAO
{
    public class PhieuDatMonDAO
    {
        private static PhieuDatMonDAO instance;

        private static readonly object lockObj = new object();

        public static PhieuDatMonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new PhieuDatMonDAO();
                        }
                    }
                }
                return instance;
            }
        }

        private PhieuDatMonDAO() { }


        public List<PhieuDatMon> GetPhieuDatByMaBan(string maBan)
        {
            string query = @"
        SELECT * 
        FROM PhieuDatMon
        WHERE MaBan = @maBan
          AND CONVERT(date, NgayLap) = CONVERT(date, GETDATE());";

            SqlParameter param = new SqlParameter("@maBan", maBan);
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { param });

            List<PhieuDatMon> listPhieuDat = new List<PhieuDatMon>();

            foreach (DataRow row in data.Rows)
            {
                listPhieuDat.Add(new PhieuDatMon(row));
            }

            return listPhieuDat;
        }
        public List<ChiTietPhieuDat> GetChiTietPhieuDatByMaPhieu(string maPhieuDat)
        {
            string query = @"
    SELECT ChiTietPhieuDat.MaPhieuDat, ChiTietPhieuDat.MaMon, ChiTietPhieuDat.SoLuongMon, 
           MON.TenMon, MON.GiaHienTai
    FROM ChiTietPhieuDat
    INNER JOIN MON ON ChiTietPhieuDat.MaMon = MON.MaMon
    WHERE ChiTietPhieuDat.MaPhieuDat = @maPhieuDat";

            SqlParameter paramPhieu = new SqlParameter("@maPhieuDat", maPhieuDat);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { paramPhieu });

            List<ChiTietPhieuDat> listChiTiet = new List<ChiTietPhieuDat>();

            foreach (DataRow row in data.Rows)
            {
                listChiTiet.Add(new ChiTietPhieuDat(row));
            }

            return listChiTiet;
        }


        // Lấy mã phiếu lớn nhất
        public string GetMaxMaPhieuDat()
        {
            string query = "SELECT ISNULL(MAX(MaPhieuDat), 'PDM_0') FROM PhieuDatMon";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result?.ToString() ?? "PDM_0";
        }

        public string GetNextMaPhieuDatFromDB()
        {
            DataTable data = DataProvider.Instance.ExecuteStoredProcedure("sp_GetNextMaPhieuDat");

            if (data.Rows.Count > 0)
            {
                return data.Rows[0][0].ToString();
            }

            return "PDM_00001";
        }



        // Kiểm tra mã trước khi thêm mới
        public bool CheckExistMaPhieuDat(string maPhieuDat)
        {
            string query = "SELECT COUNT(*) FROM PhieuDatMon WHERE MaPhieuDat = @maPhieuDat";
            SqlParameter param = new SqlParameter("@maPhieuDat", maPhieuDat);
            object result = DataProvider.Instance.ExecuteScalar(query, new SqlParameter[] { param });

            return (int)result > 0;  // Nếu COUNT > 0, tức là mã đã tồn tại
        }



        // Chèn phiếu đặt mới
        public void InsertPhieuDat(DateTime ngayLap, string nhanVienLap, string hinhThuc, string maBan, string maKhachHang)
        {
            string maPhieuDat = GetNextMaPhieuDatFromDB();

            // Kiểm tra nếu mã đã tồn tại
            if (CheckExistMaPhieuDat(maPhieuDat))
            {
                throw new Exception($"Mã phiếu đặt {maPhieuDat} đã tồn tại!");
            }

            string query = @"
    INSERT INTO PhieuDatMon (MaPhieuDat, NgayLap, NhanVienLap, HinhThuc, MaBan, MaKhachHang) 
    VALUES (@maPhieuDat, @ngayLap, @nhanVienLap, @hinhThuc, @maBan, @maKhachHang)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@maPhieuDat", maPhieuDat),
        new SqlParameter("@ngayLap", ngayLap),
        new SqlParameter("@nhanVienLap", nhanVienLap),
        new SqlParameter("@hinhThuc", hinhThuc),
        new SqlParameter("@maBan", maBan),
        new SqlParameter("@maKhachHang", maKhachHang)
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }





    }
}
