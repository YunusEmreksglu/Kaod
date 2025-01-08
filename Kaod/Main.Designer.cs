namespace MangaKB
{
    partial class Main
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
            listBox1 = new ListBox();
            button1 = new Button();
            llCretion = new LinkLabel();
            llAdd = new LinkLabel();
            textBox1 = new TextBox();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            bttnCN = new Button();
            textBox2 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(211, 274);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(45, 12);
            button1.Name = "button1";
            button1.Size = new Size(137, 23);
            button1.TabIndex = 1;
            button1.Text = "Open the Project";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // llCretion
            // 
            llCretion.AutoSize = true;
            llCretion.Location = new Point(32, -1);
            llCretion.Name = "llCretion";
            llCretion.Size = new Size(52, 15);
            llCretion.TabIndex = 3;
            llCretion.TabStop = true;
            llCretion.Text = "Creation";
            llCretion.LinkClicked += llCretion_LinkClicked;
            // 
            // llAdd
            // 
            llAdd.AutoSize = true;
            llAdd.Location = new Point(25, 0);
            llAdd.Name = "llAdd";
            llAdd.Size = new Size(29, 15);
            llAdd.TabIndex = 4;
            llAdd.TabStop = true;
            llAdd.Text = "Add";
            llAdd.LinkClicked += llAdd_LinkClicked;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(47, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(71, 23);
            textBox1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(3, 24);
            button2.Name = "button2";
            button2.Size = new Size(71, 23);
            button2.TabIndex = 6;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(183, 144);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "Name:\n\nLocation:\n\nTags:\n\nAssetSayisi:";
            // 
            // button3
            // 
            button3.Location = new Point(-1, 150);
            button3.Name = "button3";
            button3.Size = new Size(183, 23);
            button3.TabIndex = 8;
            button3.Text = "Change the Location Project";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(llCretion);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(12, 321);
            panel1.Name = "panel1";
            panel1.Size = new Size(126, 52);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 21);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Name";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(button2);
            panel2.Controls.Add(llAdd);
            panel2.Location = new Point(144, 321);
            panel2.Name = "panel2";
            panel2.Size = new Size(79, 52);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(bttnCN);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(richTextBox1);
            panel3.Controls.Add(button3);
            panel3.Location = new Point(229, 41);
            panel3.Name = "panel3";
            panel3.Size = new Size(183, 274);
            panel3.TabIndex = 11;
            // 
            // bttnCN
            // 
            bttnCN.Location = new Point(-1, 208);
            bttnCN.Name = "bttnCN";
            bttnCN.Size = new Size(183, 23);
            bttnCN.TabIndex = 10;
            bttnCN.Text = "Change the Name Project";
            bttnCN.UseVisualStyleBackColor = true;
            bttnCN.Click += bttnCN_Click;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(-1, 179);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(184, 23);
            textBox2.TabIndex = 9;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 386);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Main";
            Load += Main_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private LinkLabel llCretion;
        private LinkLabel llAdd;
        private TextBox textBox1;
        private Button button2;
        private RichTextBox richTextBox1;
        private Button button3;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Button bttnCN;
        private TextBox textBox2;
    }
}