namespace WinFormsApp1
{
    partial class fQuanLyNhanVien
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
            panel1 = new Panel();
            dtgvNhanVien = new DataGridView();
            panel2 = new Panel();
            btnEditNV = new Button();
            btnDeleteNV = new Button();
            btnAddNV = new Button();
            panel3 = new Panel();
            panel12 = new Panel();
            tbBranchNV = new TextBox();
            label7 = new Label();
            panel11 = new Panel();
            tbSectionNV = new TextBox();
            label6 = new Label();
            panel10 = new Panel();
            tbEndDateNV = new TextBox();
            label5 = new Label();
            panel9 = new Panel();
            tbBirthNV = new TextBox();
            a = new Label();
            panel8 = new Panel();
            tbStartDateNV = new TextBox();
            label4 = new Label();
            panel7 = new Panel();
            tbSexNV = new TextBox();
            label3 = new Label();
            panel6 = new Panel();
            tbNameNV = new TextBox();
            label2 = new Label();
            panel5 = new Panel();
            tbIDNV = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            tbFindNV = new TextBox();
            btnFindNV = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvNhanVien).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtgvNhanVien);
            panel1.Location = new Point(4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 365);
            panel1.TabIndex = 0;
            // 
            // dtgvNhanVien
            // 
            dtgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvNhanVien.Location = new Point(3, 3);
            dtgvNhanVien.Name = "dtgvNhanVien";
            dtgvNhanVien.RowHeadersWidth = 51;
            dtgvNhanVien.Size = new Size(468, 359);
            dtgvNhanVien.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnEditNV);
            panel2.Controls.Add(btnDeleteNV);
            panel2.Controls.Add(btnAddNV);
            panel2.Location = new Point(4, 374);
            panel2.Name = "panel2";
            panel2.Size = new Size(474, 71);
            panel2.TabIndex = 1;
            // 
            // btnEditNV
            // 
            btnEditNV.Location = new Point(312, 3);
            btnEditNV.Name = "btnEditNV";
            btnEditNV.Size = new Size(159, 65);
            btnEditNV.TabIndex = 2;
            btnEditNV.Text = "Sửa thông tin";
            btnEditNV.UseVisualStyleBackColor = true;
            btnEditNV.Click += btnEditNV_Click;
            // 
            // btnDeleteNV
            // 
            btnDeleteNV.Location = new Point(157, 3);
            btnDeleteNV.Name = "btnDeleteNV";
            btnDeleteNV.Size = new Size(149, 65);
            btnDeleteNV.TabIndex = 1;
            btnDeleteNV.Text = "Xóa nhân viên";
            btnDeleteNV.UseVisualStyleBackColor = true;
            // 
            // btnAddNV
            // 
            btnAddNV.Location = new Point(3, 3);
            btnAddNV.Name = "btnAddNV";
            btnAddNV.Size = new Size(148, 65);
            btnAddNV.TabIndex = 0;
            btnAddNV.Text = "Thêm nhân viên";
            btnAddNV.UseVisualStyleBackColor = true;
            btnAddNV.Click += btnAddNV_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel12);
            panel3.Controls.Add(panel11);
            panel3.Controls.Add(panel10);
            panel3.Controls.Add(panel9);
            panel3.Controls.Add(panel8);
            panel3.Controls.Add(panel7);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(panel5);
            panel3.Location = new Point(481, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(316, 367);
            panel3.TabIndex = 2;
            // 
            // panel12
            // 
            panel12.Controls.Add(tbBranchNV);
            panel12.Controls.Add(label7);
            panel12.Location = new Point(3, 290);
            panel12.Name = "panel12";
            panel12.Size = new Size(310, 36);
            panel12.TabIndex = 9;
            // 
            // tbBranchNV
            // 
            tbBranchNV.Location = new Point(132, 4);
            tbBranchNV.Name = "tbBranchNV";
            tbBranchNV.Size = new Size(175, 27);
            tbBranchNV.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(3, 4);
            label7.Name = "label7";
            label7.Size = new Size(90, 23);
            label7.TabIndex = 0;
            label7.Text = "Chi nhánh";
            // 
            // panel11
            // 
            panel11.Controls.Add(tbSectionNV);
            panel11.Controls.Add(label6);
            panel11.Location = new Point(3, 248);
            panel11.Name = "panel11";
            panel11.Size = new Size(310, 36);
            panel11.TabIndex = 8;
            // 
            // tbSectionNV
            // 
            tbSectionNV.Location = new Point(132, 4);
            tbSectionNV.Name = "tbSectionNV";
            tbSectionNV.Size = new Size(175, 27);
            tbSectionNV.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(3, 4);
            label6.Name = "label6";
            label6.Size = new Size(76, 23);
            label6.TabIndex = 0;
            label6.Text = "Bộ phận";
            // 
            // panel10
            // 
            panel10.Controls.Add(tbEndDateNV);
            panel10.Controls.Add(label5);
            panel10.Location = new Point(3, 206);
            panel10.Name = "panel10";
            panel10.Size = new Size(310, 36);
            panel10.TabIndex = 7;
            // 
            // tbEndDateNV
            // 
            tbEndDateNV.Location = new Point(133, 3);
            tbEndDateNV.Name = "tbEndDateNV";
            tbEndDateNV.Size = new Size(175, 27);
            tbEndDateNV.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(3, 4);
            label5.Name = "label5";
            label5.Size = new Size(129, 23);
            label5.TabIndex = 0;
            label5.Text = "Ngày nghỉ việc";
            // 
            // panel9
            // 
            panel9.Controls.Add(tbBirthNV);
            panel9.Controls.Add(a);
            panel9.Location = new Point(3, 125);
            panel9.Name = "panel9";
            panel9.Size = new Size(310, 36);
            panel9.TabIndex = 6;
            // 
            // tbBirthNV
            // 
            tbBirthNV.Location = new Point(133, 6);
            tbBirthNV.Name = "tbBirthNV";
            tbBirthNV.Size = new Size(175, 27);
            tbBirthNV.TabIndex = 6;
            // 
            // a
            // 
            a.AutoSize = true;
            a.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            a.Location = new Point(3, 4);
            a.Name = "a";
            a.Size = new Size(89, 23);
            a.TabIndex = 0;
            a.Text = "Ngày sinh";
            // 
            // panel8
            // 
            panel8.Controls.Add(tbStartDateNV);
            panel8.Controls.Add(label4);
            panel8.Location = new Point(3, 164);
            panel8.Name = "panel8";
            panel8.Size = new Size(310, 36);
            panel8.TabIndex = 4;
            // 
            // tbStartDateNV
            // 
            tbStartDateNV.Location = new Point(132, 4);
            tbStartDateNV.Name = "tbStartDateNV";
            tbStartDateNV.Size = new Size(175, 27);
            tbStartDateNV.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(3, 4);
            label4.Name = "label4";
            label4.Size = new Size(123, 23);
            label4.TabIndex = 0;
            label4.Text = "Ngày làm việc";
            // 
            // panel7
            // 
            panel7.Controls.Add(tbSexNV);
            panel7.Controls.Add(label3);
            panel7.Location = new Point(3, 85);
            panel7.Name = "panel7";
            panel7.Size = new Size(310, 36);
            panel7.TabIndex = 3;
            // 
            // tbSexNV
            // 
            tbSexNV.Location = new Point(132, 7);
            tbSexNV.Name = "tbSexNV";
            tbSexNV.Size = new Size(175, 27);
            tbSexNV.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 0;
            label3.Text = "Giới tính";
            // 
            // panel6
            // 
            panel6.Controls.Add(tbNameNV);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(3, 42);
            panel6.Name = "panel6";
            panel6.Size = new Size(310, 36);
            panel6.TabIndex = 2;
            // 
            // tbNameNV
            // 
            tbNameNV.Location = new Point(132, 4);
            tbNameNV.Name = "tbNameNV";
            tbNameNV.Size = new Size(175, 27);
            tbNameNV.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(64, 23);
            label2.TabIndex = 0;
            label2.Text = "Họ tên";
            // 
            // panel5
            // 
            panel5.Controls.Add(tbIDNV);
            panel5.Controls.Add(label1);
            panel5.Location = new Point(3, 1);
            panel5.Name = "panel5";
            panel5.Size = new Size(310, 36);
            panel5.TabIndex = 1;
            // 
            // tbIDNV
            // 
            tbIDNV.Location = new Point(132, 4);
            tbIDNV.Name = "tbIDNV";
            tbIDNV.Size = new Size(175, 27);
            tbIDNV.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(3, 4);
            label1.Name = "label1";
            label1.Size = new Size(117, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã nhân viên";
            // 
            // panel4
            // 
            panel4.Controls.Add(tbFindNV);
            panel4.Controls.Add(btnFindNV);
            panel4.Location = new Point(481, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(316, 66);
            panel4.TabIndex = 3;
            // 
            // tbFindNV
            // 
            tbFindNV.Location = new Point(3, 20);
            tbFindNV.Name = "tbFindNV";
            tbFindNV.Size = new Size(230, 27);
            tbFindNV.TabIndex = 4;
            // 
            // btnFindNV
            // 
            btnFindNV.Location = new Point(237, 5);
            btnFindNV.Name = "btnFindNV";
            btnFindNV.Size = new Size(74, 57);
            btnFindNV.TabIndex = 3;
            btnFindNV.Text = "Tìm";
            btnFindNV.UseVisualStyleBackColor = true;
            btnFindNV.Click += btnFindNV_Click;
            // 
            // fQuanLyNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "fQuanLyNhanVien";
            Text = "fQuanLyNhanVien";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvNhanVien).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dtgvNhanVien;
        private Panel panel2;
        private Button btnEditNV;
        private Button btnDeleteNV;
        private Button btnAddNV;
        private Panel panel3;
        private Panel panel4;
        private Button btnFindNV;
        private Label label1;
        private TextBox tbFindNV;
        private Panel panel5;
        private TextBox tbIDNV;
        private Panel panel10;
        private TextBox tbEndDateNV;
        private Label label5;
        private Panel panel9;
        private TextBox tbBirthNV;
        private Label a;
        private Panel panel8;
        private TextBox tbStartDateNV;
        private Label label4;
        private Panel panel7;
        private TextBox tbSexNV;
        private Label label3;
        private Panel panel6;
        private TextBox tbNameNV;
        private Label label2;
        private Panel panel12;
        private TextBox tbBranchNV;
        private Label label7;
        private Panel panel11;
        private TextBox tbSectionNV;
        private Label label6;
    }
}