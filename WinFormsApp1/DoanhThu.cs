using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.DAO;

namespace WinFormsApp1
{
    public partial class DoanhThu : Form
    {
        public DoanhThu()
        {
            InitializeComponent();
            LoadForm();
        }

        void LoadForm()
        {
            comboBox1.Items.Add("Theo Ngày");
            comboBox1.Items.Add("Theo Tháng");
            comboBox1.Items.Add("Theo Quý");
            comboBox1.Items.Add("Theo Năm");
            comboBox1.SelectedIndex = 0;  // Mặc định là "Theo Ngày"

            LoadComboBoxNăm();
            LoadComboBoxThangQuy();
        }

        void LoadComboBoxNăm()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 10; year <= currentYear; year++)
            {
                comboBox2.Items.Add(year.ToString());
            }
            comboBox2.SelectedIndex = 0;
        }

        void LoadComboBoxThangQuy()
        {
            comboBox3.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                comboBox3.Items.Add($"Tháng {i}");
            }
            comboBox3.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();

            dateTimePicker11.Visible = selected == "Theo Ngày";
            comboBox2.Visible = selected != "Theo Ngày";
            comboBox3.Visible = selected != "Theo Ngày" && selected != "Theo Năm";

            if (selected == "Theo Quý")
            {
                comboBox3.Items.Clear();
                for (int i = 1; i <= 4; i++)
                {
                    comboBox3.Items.Add($"Quý {i}");
                }
            }
            else if (selected == "Theo Tháng")
            {
                LoadComboBoxThangQuy();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TinhDoanhThu();
        }

        private void TinhDoanhThu()
        {
            try
            {
                string loai = comboBox1.SelectedItem.ToString();
                DateTime ngay = dateTimePicker11.Value;
                int nam = int.Parse(comboBox2.SelectedItem.ToString());
                int thangQuy = comboBox3.SelectedIndex + 1;

                if ((loai == "Theo Tháng" || loai == "Theo Quý") && comboBox3.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn Tháng hoặc Quý!", "Lỗi");
                    return;
                }

                DataTable dt = new DataTable();

                switch (loai)
                {
                    case "Theo Ngày":
                        dt = PhieuDatMonDAO.Instance.GetDoanhThuTheoNgay(ngay);
                        break;
                    case "Theo Tháng":
                        dt = PhieuDatMonDAO.Instance.GetDoanhThuTheoThang(nam, thangQuy);
                        break;
                    case "Theo Quý":
                        dt = PhieuDatMonDAO.Instance.GetDoanhThuTheoQuy(nam, thangQuy);
                        break;
                    case "Theo Năm":
                        dt = PhieuDatMonDAO.Instance.GetDoanhThuTheoNam(nam);
                        break;
                }

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Tính tổng doanh thu
                decimal doanhThu = 0;
                if (dt.Columns.Contains("DoanhThu"))
                {
                    doanhThu = dt.AsEnumerable().Sum(row => row.Field<decimal>("DoanhThu"));
                }
                MessageBox.Show($"Tổng doanh thu: {doanhThu:C}", "Kết Quả");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
