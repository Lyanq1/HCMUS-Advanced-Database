using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class fDatMon : Form
    {
        public fDatMon()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["TenMon"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["GiaHienTai"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
        }


        private void LoadData()
        {
            Connection.Connect();

            string sql = "select m.MaMon, m.TenMon, mu.TenMuc, m.GiaHienTai, " +
                "cn.Ten from mon m join muc mu on mu.MaMuc = m.MaMuc join THUCDON td on td.MaThucDon = mu.MaThucDon " +
                "join CHINHANH cn on cn.MaChiNhanh = td.MaChiNhanh where cn.Ten = N'" + khachhang.Ten + "'";
            dataGridView1.DataSource = Connection.GetDataToTable(sql);

            dataGridView1.Font = new Font("Time New Roman", 13);
            dataGridView1.Columns[0].HeaderText = "Mã món";
            dataGridView1.Columns[1].HeaderText = "Tên món";
            dataGridView1.Columns[2].HeaderText = "Tên mục";
            dataGridView1.Columns[3].HeaderText = "Giá";
            dataGridView1.Columns[4].HeaderText = "Tên chi nhánh";

            dataGridView1.DefaultCellStyle.Font = new Font("Time New Roman", 13);
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 300;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            Connection.Disconnect();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
