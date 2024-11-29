namespace WinFormsApp1
{
    partial class fSignup
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
            panel5 = new Panel();
            textBox1 = new TextBox();
            label4 = new Label();
            btnLogin = new Button();
            panel3 = new Panel();
            txbPassword = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            txbUserName = new TextBox();
            label1 = new Label();
            panel4 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AccessibleName = "anh";
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 315);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // panel5
            // 
            panel5.AccessibleName = "";
            panel5.Controls.Add(textBox1);
            panel5.Controls.Add(label4);
            panel5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            panel5.Location = new Point(9, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(505, 85);
            panel5.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 26);
            textBox1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(227, 14);
            label4.Name = "label4";
            label4.Size = new Size(51, 19);
            label4.TabIndex = 1;
            label4.Text = "Email";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(208, 283);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(121, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng ký";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel3
            // 
            panel3.AccessibleName = "";
            panel3.Controls.Add(txbPassword);
            panel3.Controls.Add(label2);
            panel3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            panel3.Location = new Point(12, 186);
            panel3.Name = "panel3";
            panel3.Size = new Size(505, 85);
            panel3.TabIndex = 1;
            panel3.Paint += panel3_Paint;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(141, 36);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(251, 26);
            txbPassword.TabIndex = 2;
            txbPassword.TextChanged += txbPassword_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 14);
            label2.Name = "label2";
            label2.Size = new Size(78, 19);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.AccessibleName = "";
            panel2.Controls.Add(txbUserName);
            panel2.Controls.Add(label1);
            panel2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            panel2.Location = new Point(12, 95);
            panel2.Name = "panel2";
            panel2.Size = new Size(505, 85);
            panel2.TabIndex = 0;
            panel2.Paint += panel2_Paint;
            // 
            // txbUserName
            // 
            txbUserName.Location = new Point(141, 36);
            txbUserName.Name = "txbUserName";
            txbUserName.Size = new Size(251, 26);
            txbUserName.TabIndex = 2;
            txbUserName.TextChanged += txbUserName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 14);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 1;
            label1.Text = "Tên đăng nhập";
            label1.Click += label1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Location = new Point(157, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(239, 62);
            panel4.TabIndex = 1;
            panel4.Paint += panel4_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 19);
            label3.Name = "label3";
            label3.Size = new Size(232, 25);
            label3.TabIndex = 2;
            label3.Text = "SushiX management app";
            label3.Click += label3_Click;
            // 
            // fSignup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 407);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "fSignup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "signup";
            Load += fSignup_Load;
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox txbPassword;
        private Label label2;
        private TextBox txbUserName;
        private Label label1;
        private Panel panel4;
        private Label label3;
        private Button btnLogin;
        private Panel panel5;
        private TextBox textBox1;
        private Label label4;
    }
}