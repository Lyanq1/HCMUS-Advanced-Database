using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DAO.DTO
{
    public class Table
    {
        public Table(string maban, int tinhtrang)
        {
            this.MaBan = maban;
            this.TinhTrang = tinhtrang;
        }

        public Table(DataRow row)
        {
            this.MaBan = row["maban"].ToString();
            this.TinhTrang = (int)row["tinhtrang"];
        }
        private int tinhtrang;

        public int TinhTrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }


        private string maban;

        public string MaBan
        {
            get { return maban; }
            set { maban = value; }
        }
    }
}
