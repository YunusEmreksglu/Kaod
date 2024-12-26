namespace MangaKB
{
    partial class Form1
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
            pictureBox1 = new PictureBox();
            button2 = new Button();
            openFileDialog1 = new OpenFileDialog();
            panel1 = new Panel();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            panel2 = new Panel();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button8 = new Button();
            textBox1 = new TextBox();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 728);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // button2
            // 
            button2.Location = new Point(93, 50);
            button2.Name = "button2";
            button2.Size = new Size(248, 23);
            button2.TabIndex = 2;
            button2.Text = "Algıla";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 728);
            panel1.TabIndex = 4;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(93, 21);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(248, 23);
            progressBar1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(428, 31);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Kaydet;
            // 
            // panel2
            // 
            panel2.Location = new Point(518, 224);
            panel2.Name = "panel2";
            panel2.Size = new Size(188, 592);
            panel2.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(585, 21);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "Hepsini Sil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Sil;
            // 
            // button4
            // 
            button4.Location = new Point(585, 59);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 11;
            button4.Text = "Button Sil";
            button4.UseVisualStyleBackColor = true;
            button4.Click += SecilenSil;
            // 
            // button5
            // 
            button5.Location = new Point(347, 31);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 12;
            button5.Text = "image load";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(12, 12);
            button6.Name = "button6";
            button6.Size = new Size(66, 70);
            button6.TabIndex = 13;
            button6.Text = "Düzenleme Sayfasını Aç";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button8
            // 
            button8.Location = new Point(539, 98);
            button8.Name = "button8";
            button8.Size = new Size(140, 26);
            button8.TabIndex = 0;
            button8.Text = "Tag Ekle";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(539, 140);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 23);
            textBox1.TabIndex = 15;
            // 
            // button7
            // 
            button7.Location = new Point(539, 178);
            button7.Name = "button7";
            button7.Size = new Size(140, 26);
            button7.TabIndex = 16;
            button7.Text = "Tag Sil";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(706, 851);
            Controls.Add(button7);
            Controls.Add(textBox1);
            Controls.Add(button8);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(panel2);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(panel1);
            Controls.Add(button2);
            Name = "Form1";
            Text = "Form1";
            Load += SistemYuklendiginde;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button2;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private ProgressBar progressBar1;
        private Button button1;
        private Panel panel2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button8;
        private TextBox textBox1;
        private Button button7;
    }
}
