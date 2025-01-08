namespace MangaKB
{
    partial class EditImage
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
            if (disposing)
            {
                
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditImage));
            bttnSave = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            bttnDelete = new Button();
            panlTag = new Panel();
            panlImages = new Panel();
            panel3 = new Panel();
            bttnExport = new Button();
            panlImagesbttn = new Panel();
            panel6 = new Panel();
            button3 = new Button();
            panel5 = new Panel();
            button4 = new Button();
            panlImagesNotSave = new Panel();
            panlImagesbttnNotSave = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // bttnSave
            // 
            resources.ApplyResources(bttnSave, "bttnSave");
            bttnSave.Name = "bttnSave";
            bttnSave.UseVisualStyleBackColor = true;
            bttnSave.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // bttnDelete
            // 
            resources.ApplyResources(bttnDelete, "bttnDelete");
            bttnDelete.Name = "bttnDelete";
            bttnDelete.UseVisualStyleBackColor = true;
            bttnDelete.Click += SLBT_Click;
            // 
            // panlTag
            // 
            resources.ApplyResources(panlTag, "panlTag");
            panlTag.BackColor = SystemColors.Window;
            panlTag.BorderStyle = BorderStyle.FixedSingle;
            panlTag.Name = "panlTag";
            // 
            // panlImages
            // 
            resources.ApplyResources(panlImages, "panlImages");
            panlImages.BackColor = SystemColors.Window;
            panlImages.BorderStyle = BorderStyle.FixedSingle;
            panlImages.Name = "panlImages";
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // bttnExport
            // 
            resources.ApplyResources(bttnExport, "bttnExport");
            bttnExport.Name = "bttnExport";
            bttnExport.UseVisualStyleBackColor = true;
            bttnExport.Click += button1_Click_1;
            // 
            // panlImagesbttn
            // 
            resources.ApplyResources(panlImagesbttn, "panlImagesbttn");
            panlImagesbttn.BackColor = SystemColors.Window;
            panlImagesbttn.BorderStyle = BorderStyle.FixedSingle;
            panlImagesbttn.Name = "panlImagesbttn";
            // 
            // panel6
            // 
            panel6.Controls.Add(button3);
            panel6.Controls.Add(panlImages);
            panel6.Controls.Add(panlImagesbttn);
            resources.ApplyResources(panel6, "panel6");
            panel6.Name = "panel6";
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            button3.Name = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(button4);
            panel5.Controls.Add(panlImagesNotSave);
            panel5.Controls.Add(panlImagesbttnNotSave);
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // button4
            // 
            resources.ApplyResources(button4, "button4");
            button4.Name = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // panlImagesNotSave
            // 
            resources.ApplyResources(panlImagesNotSave, "panlImagesNotSave");
            panlImagesNotSave.BackColor = SystemColors.Window;
            panlImagesNotSave.BorderStyle = BorderStyle.FixedSingle;
            panlImagesNotSave.Name = "panlImagesNotSave";
            // 
            // panlImagesbttnNotSave
            // 
            resources.ApplyResources(panlImagesbttnNotSave, "panlImagesbttnNotSave");
            panlImagesbttnNotSave.BackColor = SystemColors.Window;
            panlImagesbttnNotSave.BorderStyle = BorderStyle.FixedSingle;
            panlImagesbttnNotSave.Name = "panlImagesbttnNotSave";
            // 
            // EditImage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(bttnExport);
            Controls.Add(panel3);
            Controls.Add(panlTag);
            Controls.Add(bttnDelete);
            Controls.Add(button2);
            Controls.Add(bttnSave);
            KeyPreview = true;
            Name = "EditImage";
            Load += SistemYuklendiginde;
            KeyDown += EditImage_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button bttnSave;
        private PictureBox pictureBox1;
        private Button button2;
        private Button bttnDelete;
        private Panel panlTag;
        private Panel panlImages;
        private Panel panel3;
        private Button bttnExport;
        private Panel panlImagesbttn;
        private Panel panel6;
        private Button button3;
        private Panel panel5;
        private Button button4;
        private Panel panlImagesNotSave;
        private Panel panlImagesbttnNotSave;
    }
}