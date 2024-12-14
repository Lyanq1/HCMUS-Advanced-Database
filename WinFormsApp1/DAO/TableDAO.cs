using System;
using System.Collections.Generic;
using System.Data;
using WinFormsApp1.DAO;
using WinFormsApp1.DAO.DTO;

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

        public static int TableWidth = 50;
        public static int TableHeight = 50;

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
    }
}
