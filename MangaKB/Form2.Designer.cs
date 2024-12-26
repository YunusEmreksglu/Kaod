namespace MangaKB
{
    partial class Form2
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
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            textBox1 = new TextBox();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
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
            button1.Text = "Aç";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(21, 327);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(46, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Olustur";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(176, 327);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(28, 15);
            linkLabel2.TabIndex = 4;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Ekle";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 345);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(71, 23);
            textBox1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(158, 345);
            button2.Name = "button2";
            button2.Size = new Size(61, 23);
            button2.TabIndex = 6;
            button2.Text = "Silme";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(229, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(183, 123);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "İsmi:\n\nKonum:\n\nTagler:\n\nAssetSayisi:";
            // 
            // button3
            // 
            button3.Location = new Point(229, 180);
            button3.Name = "button3";
            button3.Size = new Size(183, 23);
            button3.TabIndex = 8;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 407);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private TextBox textBox1;
        private Button button2;
        private RichTextBox richTextBox1;
        private Button button3;
    }
}