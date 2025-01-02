using System;
using System.Collections.Generic;
using System.Data;
using WinFormsApp1.DAO;
using WinFormsApp1.DAO.DTO;
using Microsoft.Data.SqlClient; // Thay thế System.Data.SqlClient

namespace WinFormsApp1
{
    public class TableDAO
    {
        private static TableDAO instance;

        // Sử dụng lock để đảm bảo thread-safe
        private static readonly object lockObj = new object();

        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new TableDAO();
                        }
                    }
                }
                return instance;
            }
        }

        public static int TableWidth = 60;
        public static int TableHeight = 60;

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> list = new List<Table>();

            // Gọi phương thức ExecuteQuery để lấy dữ liệu từ cơ sở dữ liệu
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC LayThongTinBan");

            // Duyệt từng dòng trong DataTable và khởi tạo đối tượng Table
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table); // Thêm vào danh sách
            }

            return list; // Trả về danh sách
        }

        public void CapNhatTinhTrangBan(string maBan)
        {
            string query = "EXEC TinhTrangBan @MaBan";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaBan", maBan)
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

        public string GetMaBanByID(string maBan)
        {
            string query = "SELECT MaBan FROM Ban WHERE MaBan = @maBan";
            SqlParameter param = new SqlParameter("@maBan", maBan);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { param });

            if (data.Rows.Count > 0)
            {
                return data.Rows[0]["MaBan"].ToString();
            }
            return null; // Trả về null nếu không tìm thấy
        }

    }
}
