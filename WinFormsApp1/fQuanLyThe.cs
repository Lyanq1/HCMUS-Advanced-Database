using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class fQuanLyThe : Form
    {
        //string connectString = @"Data Source = LYAN\SQLEXPRESS01;Initial Catalog = SuShiX;Integrated Security = True; Trust Server Certificate=True";
        SqlConnection con = new SqlConnection(@"Data Source = LYAN\SQLEXPRESS01;Initial Catalog = SuShiX;Integrated Security = True; Trust Server Certificate=True");
        SqlDataAdapter adt;
        DataTable dt = new DataTable();

        public fQuanLyThe()
        {
            InitializeComponent();

        }

        private void fQuanLyThe_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_DangKyThe", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("HoTen", SqlDbType.NVarChar).Value = textBox1.Text;
            cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = textBox2.Text;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox3.Text;
            cmd.Parameters.Add("@SoCCCD", SqlDbType.NVarChar).Value = textBox4.Text;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = textBox5.Text;
            cmd.Parameters.Add("@NhanVienLap", SqlDbType.NVarChar).Value = textBox6.Text;
            cmd.Parameters.Add("@NgayLap", SqlDbType.NVarChar).Value = dateTimePicker1.Value;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm thẻ thành công");
            con.Close();
        }
    }
}