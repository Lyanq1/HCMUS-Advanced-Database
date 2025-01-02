namespace WinFormsApp1
{
    partial class fLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            label2 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            label3 = new Label();
            panel2 = new Panel();
            textBox2 = new TextBox();
            label4 = new Label();
            button3 = new Button();
            button4 = new Button();
            panel3 = new Panel();
            textBox3 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 116);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 1;
            label1.Click += label1_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 24);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 3;
            label2.Text = "Trang đăng nhập";
            label2.Click += label2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(49, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(285, 62);
            panel1.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(7, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 23);
            textBox1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 9);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "Username";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(49, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(285, 62);
            panel2.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 27);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(240, 23);
            textBox2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 9);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 0;
            label4.Text = "Password";
            // 
            // button3
            // 
            button3.BackColor = Color.LightCoral;
            button3.FlatAppearance.BorderColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.InfoText;
            button3.Location = new Point(49, 218);
            button3.Name = "button3";
            button3.Size = new Size(81, 33);
            button3.TabIndex = 2;
            button3.Text = "Login";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Bisque;
            button4.FlatAppearance.BorderColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.InfoText;
            button4.Location = new Point(215, 218);
            button4.Name = "button4";
            button4.Size = new Size(81, 33);
            button4.TabIndex = 7;
            button4.Text = "Sign up";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(textBox3);
            panel3.Location = new Point(2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(553, 48);
            panel3.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.CornflowerBlue;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 15F);
            textBox3.ForeColor = SystemColors.Menu;
            textBox3.Location = new Point(125, 11);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(117, 27);
            textBox3.TabIndex = 0;
            textBox3.Text = "SuShiX  App";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // fLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 276);
            Controls.Add(panel3);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "fLogin";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private NotifyIcon notifyIcon1;
        private Label label2;
        private Panel panel1;
        private TextBox textBox1;
        private Label label3;
        private Panel panel2;
        private TextBox textBox2;
        private Label label4;
        private Button button3;
        private Button button4;
        private Panel panel3;
        private TextBox textBox3;
    }
}
