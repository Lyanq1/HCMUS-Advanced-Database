   using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DAO.DTO
{
    public class ChiTietPhieuDat
    {
        public string MaPhieuDat { get; set; }
        public string MaMon { get; set; }
        public int SoLuongMon { get; set; }
        public string TenMon { get; set; } // Tên món
        public decimal GiaHienTai { get; set; } // Giá hiện tại

        // Constructor



        public ChiTietPhieuDat(DataRow row)
        {
            MaPhieuDat = row["MaPhieuDat"].ToString();
            MaMon = row["MaMon"].ToString();
            SoLuongMon = int.Parse(row["SoLuongMon"].ToString());
            TenMon = row["TenMon"].ToString();
            GiaHienTai = decimal.Parse(row["GiaHienTai"].ToString());
        }
    }
}