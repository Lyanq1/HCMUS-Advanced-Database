﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            fDatBan f = new fDatBan();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien f = new QuanLyNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void nhanvien_Load(object sender, EventArgs e)
        {

        }
    }
}
