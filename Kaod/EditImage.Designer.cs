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
            panel3 = new Panel();
            bttnExport = new Button();
            panlImagesNotSave = new Panel();
            panlImagesbttnNotSave = new Panel();
            panlImagesbttn = new Panel();
            panlImages = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
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
            // panlImagesbttn
            // 
            resources.ApplyResources(panlImagesbttn, "panlImagesbttn");
            panlImagesbttn.BackColor = SystemColors.Window;
            panlImagesbttn.BorderStyle = BorderStyle.FixedSingle;
            panlImagesbttn.Name = "panlImagesbttn";
            // 
            // panlImages
            // 
            resources.ApplyResources(panlImages, "panlImages");
            panlImages.BackColor = SystemColors.Window;
            panlImages.BorderStyle = BorderStyle.FixedSingle;
            panlImages.Name = "panlImages";
            // 
            // EditImage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panlImagesNotSave);
            Controls.Add(panlImagesbttnNotSave);
            Controls.Add(panlImages);
            Controls.Add(panlImagesbttn);
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
            ResumeLayout(false);
        }

        #endregion

        private Button bttnSave;
        private PictureBox pictureBox1;
        private Button button2;
        private Button bttnDelete;
        private Panel panlTag;
        private Panel panel3;
        private Button bttnExport;
        private Panel panlImagesNotSave;
        private Panel panlImagesbttnNotSave;
        private Panel panlImagesbttn;
        private Panel panlImages;
    }
}