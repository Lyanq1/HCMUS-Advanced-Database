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
using WinFormsApp1.DTO;

namespace WinFormsApp1
{
    public partial class fQuanLyNhanVien : Form
    {
        public fQuanLyNhanVien()
        {
            InitializeComponent();
            LoadListEmployee();
            AddEmployeeBinding();
        }

        void LoadListEmployee()
        {
            dtgvNhanVien.DataSource = EmployeeDAO.Instance.GetListEmployee();
        }

        void AddEmployeeBinding()
        {
            tbIDNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaNhanVien", true, DataSourceUpdateMode.Never));
            tbNameNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            tbBirthNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            tbSexNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            tbStartDateNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NgayVaoLam", true, DataSourceUpdateMode.Never));
            tbEndDateNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NgayNghiViec", true, DataSourceUpdateMode.Never));
            tbSectionNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "BoPhanPhuTrach", true, DataSourceUpdateMode.Never));
            tbBranchNV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "ChiNhanhLamViec", true, DataSourceUpdateMode.Never));
        }

        List<Employee> SearchEmployeeByName(string HoTen)
        {
            List<Employee> listEmployee = EmployeeDAO.Instance.SearchEmployeeByName(HoTen);

            return listEmployee;
        }

        private void btnFindNV_Click(object sender, EventArgs e)
        {
            dtgvNhanVien.DataSource = SearchEmployeeByName(tbFindNV.Text);
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            string maNhanVien = tbIDNV.Text;
            string hoTen = tbNameNV.Text;
            string ngaySinh = tbBirthNV.Text;
            string gioiTinh = tbSexNV.Text;
            string ngayVaoLam = tbStartDateNV.Text;
            string ngayNghiViec = tbEndDateNV.Text;
            string boPhanPhuTrach = tbSectionNV.Text;
            string chiNhanhLamViec = tbBranchNV.Text;

            if (EmployeeDAO.Instance.InsertEmployee(maNhanVien, hoTen, ngaySinh, gioiTinh, ngayVaoLam, ngayNghiViec, boPhanPhuTrach, chiNhanhLamViec))
            {
                MessageBox.Show("Thêm nhân viên thành công.");
                LoadListEmployee();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm nhân viên.");
            }

        }

        private void btnEditNV_Click(object sender, EventArgs e)
        {
            string maNhanVien = tbIDNV.Text;
            string hoTen = tbNameNV.Text;
            string ngaySinh = tbBirthNV.Text;
            string gioiTinh = tbSexNV.Text;
            string ngayVaoLam = tbStartDateNV.Text;
            string ngayNghiViec = tbEndDateNV.Text;
            string boPhanPhuTrach = tbSectionNV.Text;
            string chiNhanhLamViec = tbBranchNV.Text;

            if (EmployeeDAO.Instance.UpdateEmployee(maNhanVien, hoTen, ngaySinh, gioiTinh, ngayVaoLam, ngayNghiViec, boPhanPhuTrach, chiNhanhLamViec))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công.");
                LoadListEmployee();
            }
            else
            {
                MessageBox.Show("Lỗi khi sửa nhân viên.");
            }
        }
    }
}
