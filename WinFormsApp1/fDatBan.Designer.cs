namespace WinFormsApp1
{
    partial class fDatBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpTable = new FlowLayoutPanel();
            lvPhieuDat = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            lvChiTietPhieuDat = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            btnThanhToan = new Button();
            lvHoaDon = new ListView();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            button2 = new Button();
            SuspendLayout();
            // 
            // flpTable
            // 
            flpTable.Location = new Point(25, 43);
            flpTable.Margin = new Padding(3, 4, 3, 4);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(429, 524);
            flpTable.TabIndex = 5;
            flpTable.Paint += flowLayoutPanel1_Paint;
            // 
            // lvPhieuDat
            // 
            lvPhieuDat.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            lvPhieuDat.GridLines = true;
            lvPhieuDat.Location = new Point(461, 43);
            lvPhieuDat.Margin = new Padding(3, 4, 3, 4);
            lvPhieuDat.Name = "lvPhieuDat";
            lvPhieuDat.Size = new Size(446, 111);
            lvPhieuDat.TabIndex = 6;
            lvPhieuDat.UseCompatibleStateImageBehavior = false;
            lvPhieuDat.View = View.Details;
            lvPhieuDat.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Ma Phieu";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "NgayLap";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ma NV";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Hinh Thuc";
            columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Ban";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Ma KH";
            columnHeader6.Width = 70;
            // 
            // lvChiTietPhieuDat
            // 
            lvChiTietPhieuDat.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            lvChiTietPhieuDat.GridLines = true;
            lvChiTietPhieuDat.Location = new Point(461, 184);
            lvChiTietPhieuDat.Margin = new Padding(3, 4, 3, 4);
            lvChiTietPhieuDat.Name = "lvChiTietPhieuDat";
            lvChiTietPhieuDat.Size = new Size(446, 176);
            lvChiTietPhieuDat.TabIndex = 7;
            lvChiTietPhieuDat.UseCompatibleStateImageBehavior = false;
            lvChiTietPhieuDat.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Ma Mon";
            columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Ten Mon";
            columnHeader8.Width = 140;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "So Luong";
            columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Gia";
            columnHeader10.Width = 80;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(461, 512);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(114, 55);
            btnThanhToan.TabIndex = 9;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // lvHoaDon
            // 
            lvHoaDon.Columns.AddRange(new ColumnHeader[] { columnHeader11, columnHeader12, columnHeader13, columnHeader14, columnHeader15 });
            lvHoaDon.Location = new Point(461, 367);
            lvHoaDon.Name = "lvHoaDon";
            lvHoaDon.Size = new Size(442, 121);
            lvHoaDon.TabIndex = 10;
            lvHoaDon.UseCompatibleStateImageBehavior = false;
            lvHoaDon.View = View.Details;
            lvHoaDon.SelectedIndexChanged += lvHoaDon_SelectedIndexChanged;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "MaHoaDon";
            columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Thanh Tien";
            columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "So Tien Duoc Giam";
            columnHeader13.Width = 120;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Tong Tien";
            columnHeader14.Width = 120;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Ma Phieu";
            // 
            // button2
            // 
            button2.Location = new Point(792, 512);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(109, 55);
            button2.TabIndex = 12;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // fDatBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(button2);
            Controls.Add(lvHoaDon);
            Controls.Add(btnThanhToan);
            Controls.Add(lvChiTietPhieuDat);
            Controls.Add(lvPhieuDat);
            Controls.Add(flpTable);
            Margin = new Padding(3, 4, 3, 4);
            Name = "fDatBan";
            Text = "fDatBan";
            Load += fDatBan_Load;
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flpTable;
        private ListView lvPhieuDat;
        private ListView lvChiTietPhieuDat;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnThanhToan;
        private ListView lvHoaDon;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private Button button2;
        private ColumnHeader columnHeader15;
    }
}