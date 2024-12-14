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
            panel2 = new Panel();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            panel3 = new Panel();
            comboBox3 = new ComboBox();
            panel4 = new Panel();
            flpTable = new FlowLayoutPanel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(numericUpDown1);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(459, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(313, 63);
            panel2.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(14, 37);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(14, 8);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(248, 18);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(62, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(162, 8);
            button1.Name = "button1";
            button1.Size = new Size(80, 42);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(comboBox3);
            panel3.Location = new Point(459, 355);
            panel3.Name = "panel3";
            panel3.Size = new Size(313, 70);
            panel3.TabIndex = 3;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(14, 44);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.Location = new Point(459, 117);
            panel4.Name = "panel4";
            panel4.Size = new Size(310, 220);
            panel4.TabIndex = 4;
            // 
            // flpTable
            // 
            flpTable.Location = new Point(22, 32);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(419, 393);
            flpTable.TabIndex = 5;
            flpTable.Paint += flowLayoutPanel1_Paint;
            // 
            // fDatBan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flpTable);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "fDatBan";
            Text = "fDatBan";
            Load += fDatBan_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Panel panel3;
        private ComboBox comboBox3;
        private Panel panel4;
        private FlowLayoutPanel flpTable;
    }
}