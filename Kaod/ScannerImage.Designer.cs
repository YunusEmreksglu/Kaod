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
            bttnScanner = new Button();
            openFileDialog1 = new OpenFileDialog();
            panlPicturbox = new Panel();
            progressBar1 = new ProgressBar();
            bttnSave = new Button();
            panlTag = new Panel();
            bttnDelete = new Button();
            bttnSelectDelete = new Button();
            bttnImageLoad = new Button();
            bttnOpenEditPage = new Button();
            bttnTagAdd = new Button();
            textBox1 = new TextBox();
            bttnTagRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panlPicturbox.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
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
            // bttnScanner
            // 
            bttnScanner.Location = new Point(93, 50);
            bttnScanner.Name = "bttnScanner";
            bttnScanner.Size = new Size(248, 23);
            bttnScanner.TabIndex = 2;
            bttnScanner.Text = "Scanner";
            bttnScanner.UseVisualStyleBackColor = true;
            bttnScanner.Click += bttnScanner_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panlPicturbox
            // 
            panlPicturbox.BackColor = SystemColors.Control;
            panlPicturbox.Controls.Add(pictureBox1);
            panlPicturbox.Location = new Point(0, 88);
            panlPicturbox.Name = "panlPicturbox";
            panlPicturbox.Size = new Size(512, 728);
            panlPicturbox.TabIndex = 4;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(93, 21);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(248, 23);
            progressBar1.TabIndex = 5;
            // 
            // bttnSave
            // 
            bttnSave.Location = new Point(428, 31);
            bttnSave.Name = "bttnSave";
            bttnSave.Size = new Size(75, 23);
            bttnSave.TabIndex = 8;
            bttnSave.Text = "Save";
            bttnSave.UseVisualStyleBackColor = true;
            bttnSave.Click += bttnSave_Click;
            // 
            // panlTag
            // 
            panlTag.BackColor = SystemColors.Window;
            panlTag.BorderStyle = BorderStyle.FixedSingle;
            panlTag.Location = new Point(518, 224);
            panlTag.Name = "panlTag";
            panlTag.Size = new Size(188, 592);
            panlTag.TabIndex = 9;
            // 
            // bttnDelete
            // 
            bttnDelete.Location = new Point(585, 21);
            bttnDelete.Name = "bttnDelete";
            bttnDelete.Size = new Size(75, 23);
            bttnDelete.TabIndex = 10;
            bttnDelete.Text = "All delete";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += bttnDelete_Click;
            // 
            // bttnSelectDelete
            // 
            bttnSelectDelete.Location = new Point(566, 59);
            bttnSelectDelete.Name = "bttnSelectDelete";
            bttnSelectDelete.Size = new Size(102, 23);
            bttnSelectDelete.TabIndex = 11;
            bttnSelectDelete.Text = "Button delete";
            bttnSelectDelete.UseVisualStyleBackColor = true;
            bttnSelectDelete.Click += bttnSelectDelete_Click;
            // 
            // bttnImageLoad
            // 
            bttnImageLoad.Location = new Point(347, 31);
            bttnImageLoad.Name = "bttnImageLoad";
            bttnImageLoad.Size = new Size(75, 23);
            bttnImageLoad.TabIndex = 12;
            bttnImageLoad.Text = "image load";
            bttnImageLoad.UseVisualStyleBackColor = true;
            bttnImageLoad.Click += bttnImageLoad_Click;
            // 
            // bttnOpenEditPage
            // 
            bttnOpenEditPage.Location = new Point(12, 12);
            bttnOpenEditPage.Name = "bttnOpenEditPage";
            bttnOpenEditPage.Size = new Size(66, 70);
            bttnOpenEditPage.TabIndex = 13;
            bttnOpenEditPage.Text = "Open Edit Page";
            bttnOpenEditPage.UseVisualStyleBackColor = true;
            bttnOpenEditPage.Click += bttnOpenEditPage_Click;
            // 
            // bttnTagAdd
            // 
            bttnTagAdd.Location = new Point(539, 98);
            bttnTagAdd.Name = "bttnTagAdd";
            bttnTagAdd.Size = new Size(140, 26);
            bttnTagAdd.TabIndex = 0;
            bttnTagAdd.Text = "Tag add";
            bttnTagAdd.UseVisualStyleBackColor = true;
            bttnTagAdd.Click += bttnTagAdd_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(539, 140);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 23);
            textBox1.TabIndex = 15;
            // 
            // bttnTagRemove
            // 
            bttnTagRemove.Location = new Point(539, 178);
            bttnTagRemove.Name = "bttnTagRemove";
            bttnTagRemove.Size = new Size(140, 26);
            bttnTagRemove.TabIndex = 16;
            bttnTagRemove.Text = "Tag remove";
            bttnTagRemove.UseVisualStyleBackColor = true;
            bttnTagRemove.Click += bttnTagRemove_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(706, 851);
            Controls.Add(bttnTagRemove);
            Controls.Add(textBox1);
            Controls.Add(bttnTagAdd);
            Controls.Add(bttnOpenEditPage);
            Controls.Add(bttnImageLoad);
            Controls.Add(bttnSelectDelete);
            Controls.Add(bttnDelete);
            Controls.Add(panlTag);
            Controls.Add(bttnSave);
            Controls.Add(progressBar1);
            Controls.Add(panlPicturbox);
            Controls.Add(bttnScanner);
            Name = "Form1";
            Text = "Form1";
            Load += SistemYuklendiginde;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panlPicturbox.ResumeLayout(false);
            panlPicturbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button bttnScanner;
        private OpenFileDialog openFileDialog1;
        private Panel panlPicturbox;
        private ProgressBar progressBar1;
        private Button bttnSave;
        private Panel panlTag;
        private Button bttnDelete;
        private Button bttnSelectDelete;
        private Button bttnImageLoad;
        private Button bttnOpenEditPage;
        private Button bttnTagAdd;
        private TextBox textBox1;
        private Button bttnTagRemove;
    }
}
