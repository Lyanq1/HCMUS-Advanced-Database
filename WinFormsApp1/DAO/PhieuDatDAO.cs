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

            SqlParameter param = new SqlParameter("@maPhieuDat", maPhieuDat);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { param });

            List<ChiTietPhieuDat> listChiTiet = new List<ChiTietPhieuDat>();

            foreach (DataRow row in data.Rows)
            {
                listChiTiet.Add(new ChiTietPhieuDat(row));
            }

            return listChiTiet;
        }
    }
}
