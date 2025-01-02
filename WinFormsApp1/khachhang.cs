using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class khachhang : Form
    {
        Thread t;
        public static string Ten;
        public khachhang()
        {
            InitializeComponent();
            LoadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            fChonBan_LapMa f = new fChonBan_LapMa();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString().Trim();
            textBox2.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
        }
        private void LoadData()
        {
            Connection.Connect();

            string sql = "select Ten,DiaChi,TenKhuVuc from CHINHANH join KHUVUC on KHUVUC.MaKhuVuc = CHINHANH.MaKhuVuc";
            dataGridView1.DataSource = Connection.GetDataToTable(sql);

            dataGridView1.Font = new Font("Time New Roman", 13);
            dataGridView1.Columns[0].HeaderText = "Tên chi nhánh";
            dataGridView1.Columns[1].HeaderText = "Địa chỉ";
            dataGridView1.Columns[2].HeaderText = "Tên khu vực";

            dataGridView1.DefaultCellStyle.Font = new Font("Time New Roman", 13);
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            Connection.Disconnect();
        }

        private void khachhang_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng chọn một chi nhánh");
            }
            else
            {
                Ten = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
                this.Close();
                t = new Thread(DatMon);
                t.Start();
            }
        }
        private void DatMon()
        {
            Application.Run(new fDatMon());
        }
    }
}
