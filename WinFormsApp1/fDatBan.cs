using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.DAO;
using WinFormsApp1.DAO.DTO;

namespace WinFormsApp1
{
    public partial class fDatBan : Form
    {
        public fDatBan()
        {
            InitializeComponent();
            LoadTable();
        }

        #region Methods

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
            // Lấy thông tin bàn từ nút được click
            Table selectedTable = (sender as Button).Tag as Table;

            if (selectedTable != null)
            {
                string maBan = selectedTable.MaBan;

                // Hiển thị danh sách phiếu đặt theo bàn
                ShowPhieuDatByMaBan(maBan);

                // Lấy mã phiếu đầu tiên để hiển thị chi tiết (nếu có)
                if (lvPhieuDat.Items.Count > 0)
                {
                    string maPhieuDat = lvPhieuDat.Items[0].SubItems[0].Text; // Lấy MaPhieuDat của dòng đầu tiên
                    ShowChiTietPhieuDat(maPhieuDat); // Hiển thị chi tiết phiếu đặt
                }
                else
                {
                    lvChiTietPhieuDat.Items.Clear(); // Xóa ListView chi tiết nếu không có phiếu đặt
                }
            }
        }


        // Hiển thị danh sách Phiếu Đặt theo Mã Bàn
        void ShowPhieuDatByMaBan(string maBan)
        {
            // Lấy danh sách Phiếu Đặt Món từ DAO
            List<PhieuDatMon> listPhieu = PhieuDatMonDAO.Instance.GetPhieuDatByMaBan(maBan);

            // Xóa dữ liệu cũ trong ListView
            lvPhieuDat.Items.Clear();

            // Thêm dữ liệu mới
            foreach (PhieuDatMon phieu in listPhieu)
            {
                ListViewItem item = new ListViewItem(phieu.MaPhieuDat);
                item.SubItems.Add(phieu.NgayLap.ToString("dd/MM/yyyy"));
                item.SubItems.Add(phieu.NhanVienLap);
                item.SubItems.Add(phieu.HinhThuc);
                item.SubItems.Add(phieu.MaBan);
                item.SubItems.Add(phieu.MaKhachHang);

                lvPhieuDat.Items.Add(item);
            }
        }



        // Hiển thị chi tiết Phiếu Đặt
        void ShowChiTietPhieuDat(string maPhieuDat)
        {
            // Lấy danh sách chi tiết phiếu đặt từ DAO
            List<ChiTietPhieuDat> listChiTiet = PhieuDatMonDAO.Instance.GetChiTietPhieuDatByMaPhieu(maPhieuDat);

            // Xóa dữ liệu cũ trong ListView Chi Tiết
            lvChiTietPhieuDat.Items.Clear();

            foreach (ChiTietPhieuDat chiTiet in listChiTiet)
            {
                ListViewItem item = new ListViewItem(chiTiet.MaMon);
                item.SubItems.Add(chiTiet.TenMon);
                item.SubItems.Add(chiTiet.SoLuongMon.ToString());
                item.SubItems.Add(chiTiet.GiaHienTai.ToString("N2"));

                lvChiTietPhieuDat.Items.Add(item);
            }
        }


        // Hiển thị Hóa Đơn 
        // Hiển thị Hóa Đơn 
        void ShowHoaDonByMaPhieu(string maPhieuDat)
        {
            // Lấy danh sách hóa đơn từ DAO theo MaPhieu
            List<HoaDon> hoaDonList = HoaDonDAO.Instance.GetHoaDonByMaPhieu(maPhieuDat);

            // Xóa dữ liệu cũ trong ListView HoaDon
            lvHoaDon.Items.Clear();

            // Thêm dữ liệu mới vào ListView
            foreach (HoaDon hoaDon in hoaDonList)
            {
                ListViewItem item = new ListViewItem(hoaDon.MaHoaDon); // Cột 1: Mã hóa đơn
                item.SubItems.Add(hoaDon.ThanhTien.ToString("N2"));    // Cột 2: Giá trị trước giảm giá (ThanhTien)
                item.SubItems.Add(hoaDon.SoTienDuocGiam.ToString("N2")); // Cột 3: Số tiền được giảm
                item.SubItems.Add(hoaDon.TongTien.ToString("N2"));     // Cột 4: Giá trị sau giảm giá (TongTien)
                item.SubItems.Add(hoaDon.MaPhieu);                    // Cột 5: Mã phiếu đặt

                lvHoaDon.Items.Add(item);
            }
        }


        void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lvPhieuDat.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Phiếu Đặt cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phiếu đặt
            string maPhieuDat = lvPhieuDat.SelectedItems[0].Text;

            // Lấy tổng tiền (trước giảm giá) từ ChiTietPhieuDat
            decimal thanhTien = HoaDonDAO.Instance.GetTongTienByMaPhieu(maPhieuDat);

            // Lấy giá trị giảm giá từ bảng THE
            decimal giamGia;
            try
            {
                giamGia = HoaDonDAO.Instance.GetGiamGiaByMaPhieu(maPhieuDat);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy giá trị giảm giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính tiền giảm giá và tổng tiền sau giảm giá
            decimal soTienGiam = thanhTien * giamGia / 100;
            decimal tongTien = thanhTien - soTienGiam;

            // Lấy mã hóa đơn mới
            string maxMaHoaDon = HoaDonDAO.Instance.GetMaxMaHoaDon();
            int nextNumber = int.Parse(maxMaHoaDon.Substring(3)) + 1;
            string maHoaDon = "HD_" + nextNumber;

            // Lưu hóa đơn vào database
            try
            {
                HoaDonDAO.Instance.InsertHoaDon(maHoaDon, thanhTien, soTienGiam, tongTien, maPhieuDat);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị hóa đơn mới trên lvHoaDon
            ShowHoaDonByMaPhieu(maPhieuDat);

            // Thông báo thanh toán thành công
            MessageBox.Show($"Thanh toán thành công!\nMã Hóa Đơn: {maHoaDon}\nTổng tiền: {tongTien:N2} VNĐ",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }







        #endregion





        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fDatBan_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
