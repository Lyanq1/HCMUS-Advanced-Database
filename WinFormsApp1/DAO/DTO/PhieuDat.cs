using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DAO.DTO
{
    public class PhieuDatMon
    {
        // Constructor nhận các tham số
        public PhieuDatMon(string maPhieuDat, DateTime ngayLap, string nhanVienLap, string hinhThuc, string maBan, string maKhachHang)
        {
            this.MaPhieuDat = maPhieuDat;
            this.NgayLap = ngayLap;
            this.NhanVienLap = nhanVienLap;
            this.HinhThuc = hinhThuc;
            this.MaBan = maBan;
            this.MaKhachHang = maKhachHang;
        }

        // Constructor nhận DataRow
        public PhieuDatMon(DataRow row)
        {
            this.MaPhieuDat = row["MaPhieuDat"].ToString();
            this.NgayLap = (DateTime)row["NgayLap"];
            this.NhanVienLap = row["NhanVienLap"]?.ToString(); // Nullable
            this.HinhThuc = row["HinhThuc"]?.ToString(); // Nullable
            this.MaBan = row["MaBan"]?.ToString(); // Nullable
            this.MaKhachHang = row["MaKhachHang"]?.ToString(); // Nullable
        }

        // Properties
        private string maPhieuDat;
        public string MaPhieuDat
        {
            get { return maPhieuDat; }
            set { maPhieuDat = value; }
        }

        private DateTime ngayLap;
        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }

        private string nhanVienLap;
        public string NhanVienLap
        {
            get { return nhanVienLap; }
            set { nhanVienLap = value; }
        }

        private string hinhThuc;
        public string HinhThuc
        {
            get { return hinhThuc; }
            set { hinhThuc = value; }
        }

        private string maBan;
        public string MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }

        private string maKhachHang;
        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
    }
}
