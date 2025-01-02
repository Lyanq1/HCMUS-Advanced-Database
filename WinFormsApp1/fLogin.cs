using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WindowsFormsApp1;
using System.Collections.Specialized;

namespace WinFormsApp1
{
    public partial class fLogin : Form
    {
        string tendangnhap;
        string matkhau;
        static public string idTaiKhoan;
        Thread t;
        //string connectString = @"Data Source = LYAN\SQLEXPRESS01;Initial Catalog = SuShiX;Integrated Security = True; Trust Server Certificate=True";
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataAdapter adt;
        //DataTable dt = new DataTable();

        public fLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection(connectString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //con.Open();
                //cmd = new SqlCommand("Select * from BAN", con);
                //adt = new SqlDataAdapter(cmd);
                //adt.Fill(dt);
                //dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Hello World!";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fQuanLyThe f = new fQuanLyThe();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //fDatBan f = new fDatBan();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            tendangnhap = textBox1.Text.Trim().ToString();
            matkhau = textBox2.Text.Trim().ToString();
            string sql = "select MATAIKHOAN from TAIKHOAN  where MATKHAU= '" + matkhau + "' and TENDANGNHAP= '" + tendangnhap + "'";
            Connection.Connect();
            idTaiKhoan = Connection.GetFieldValues(sql);
            
            Connection.Disconnect();
            if (idTaiKhoan != "")
            {
                this.Close();
                t = new Thread(open_Form);
                t.Start();
            }

        }

        private void open_Form()
        {
            Connection.Connect();

            if (Connection.GetFieldValues("select MaKhachHang from KHACHHANG where MaKhachHang='" + idTaiKhoan + "'") != "")
            {
                Application.Run(new khachhang());
            }

            else if (Connection.GetFieldValues("select MaNhanVien from NHANVIEN where MaNhanVien='" + idTaiKhoan + "'") != "")
            {
                Application.Run(new nhanvien());
            }
           

        }


    }
}
