namespace WinFormsApp1
{
    partial class fChonBan_LapMa
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
            buttonChange = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // flpTable
            // 
            flpTable.Location = new Point(218, 12);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(376, 393);
            flpTable.TabIndex = 6;
            flpTable.Paint += flpTable_Paint;
            // 
            // buttonChange
            // 
            buttonChange.Location = new Point(91, 398);
            buttonChange.Margin = new Padding(3, 2, 3, 2);
            buttonChange.Name = "buttonChange";
            buttonChange.Size = new Size(100, 41);
            buttonChange.TabIndex = 14;
            buttonChange.Text = "Cập nhật";
            buttonChange.UseVisualStyleBackColor = true;
            buttonChange.Click += buttonChange_Click;
            // 
            // button2
            // 
            button2.Location = new Point(638, 398);
            button2.Name = "button2";
            button2.Size = new Size(95, 41);
            button2.TabIndex = 15;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // fChonBan_LapMa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(buttonChange);
            Controls.Add(flpTable);
            Name = "fChonBan_LapMa";
            Text = "fChonBan_LapMa";
            Load += fChonBan_LapMa_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpTable;
        private Button buttonChange;
        private Button button2;
    }
}