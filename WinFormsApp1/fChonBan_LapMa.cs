using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.DAO;
using WinFormsApp1.DAO.DTO;

namespace WinFormsApp1
{
    public partial class fChonBan_LapMa : Form
    {
        public fChonBan_LapMa()
        {
            InitializeComponent();
            LoadTable();  // Tự động load bàn khi form mở
        }

        private Table selectedTable;

        // Load danh sách bàn vào giao diện
        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight,
                    Text = item.MaBan + Environment.NewLine + item.TinhTrang,
                    BackColor = item.TinhTrang == 0 ? Color.White : Color.Pink
                };

                btn.Click += btn_click;
                btn.Tag = item;

                flpTable.Controls.Add(btn);
            }
        }

        // Sự kiện click khi chọn bàn
        void btn_click(object sender, EventArgs e)
        {
            selectedTable = (sender as Button).Tag as Table;
        }

        // Tìm button tương ứng với bàn
        private Button FindButtonByTable(Table table)
        {
            foreach (Control control in flpTable.Controls)
            {
                if (control is Button btn && btn.Tag is Table t && t.MaBan == table.MaBan)
                {
                    return btn;
                }
            }
            return null;
        }

        // Sự kiện click nút cập nhật
        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (selectedTable != null)
            {
                // Cập nhật tình trạng bàn
                TableDAO.Instance.CapNhatTinhTrangBan(selectedTable.MaBan);

                selectedTable.TinhTrang = selectedTable.TinhTrang == 0 ? 1 : 0;

                Button btn = FindButtonByTable(selectedTable);
                if (btn != null)
                {
                    btn.Text = selectedTable.MaBan + Environment.NewLine + selectedTable.TinhTrang;
                    btn.BackColor = selectedTable.TinhTrang == 0 ? Color.White : Color.Pink;
                }

                // Thêm dòng mới vào PhieuDatMon
                // Chỉ tạo phiếu mới nếu bàn đang trống (TinhTrang = 0)
                if (selectedTable.TinhTrang == 1)
                {
                    try
                    {
                        string maPhieuDatMoi = TaoPhieuDatMoi(selectedTable.MaBan);
                        MessageBox.Show($"Đã tạo phiếu đặt mới: {maPhieuDatMoi}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm phiếu đặt: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"Bàn {selectedTable.MaBan} đã có khách, không tạo phiếu mới.");
                }


                MessageBox.Show($"Đã cập nhật tình trạng bàn {selectedTable.MaBan}.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi cập nhật.");
            }
        }

        // Tạo phiếu đặt mới
        private string TaoPhieuDatMoi(string maBan)
        {
            // 1. Lấy mã phiếu đặt mới từ SQL (Stored Procedure)
            string newMaPhieuDat = PhieuDatMonDAO.Instance.GetNextMaPhieuDatFromDB();

            // 2. Random Nhân viên và Khách hàng
            Random rand = new Random();
            string nhanVienLap = "NV_" + rand.Next(1, 501);  // NV_1 đến NV_500
            string maKhachHang = "KH_" + rand.Next(1, 10001); // KH_1 đến KH_10000

            // 3. Chèn vào bảng
            PhieuDatMonDAO.Instance.InsertPhieuDat(DateTime.Now, nhanVienLap, "Tại quầy", maBan, maKhachHang);

            return newMaPhieuDat;
        }


        private void fChonBan_LapMa_Load(object sender, EventArgs e)
        {
            LoadTable();  // Load bàn khi form load
        }


        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
