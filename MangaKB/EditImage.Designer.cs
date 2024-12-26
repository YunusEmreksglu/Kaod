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
            KYBT = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            SLBT = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            button1 = new Button();
            panel4 = new Panel();
            panel6 = new Panel();
            button3 = new Button();
            panel5 = new Panel();
            button4 = new Button();
            panel7 = new Panel();
            panel8 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // KYBT
            // 
            resources.ApplyResources(KYBT, "KYBT");
            KYBT.Name = "KYBT";
            KYBT.UseVisualStyleBackColor = true;
            KYBT.Click += button1_Click;
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
            // SLBT
            // 
            resources.ApplyResources(SLBT, "SLBT");
            SLBT.Name = "SLBT";
            SLBT.UseVisualStyleBackColor = true;
            SLBT.Click += SLBT_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel4
            // 
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // panel6
            // 
            panel6.Controls.Add(button3);
            panel6.Controls.Add(panel2);
            panel6.Controls.Add(panel4);
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
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel8);
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // button4
            // 
            resources.ApplyResources(button4, "button4");
            button4.Name = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            resources.ApplyResources(panel7, "panel7");
            panel7.Name = "panel7";
            // 
            // panel8
            // 
            resources.ApplyResources(panel8, "panel8");
            panel8.Name = "panel8";
            // 
            // EditImage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(button1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(SLBT);
            Controls.Add(button2);
            Controls.Add(KYBT);
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

        private Button KYBT;
        private PictureBox pictureBox1;
        private Button button2;
        private Button SLBT;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button1;
        private Panel panel4;
        private Panel panel6;
        private Button button3;
        private Panel panel5;
        private Button button4;
        private Panel panel7;
        private Panel panel8;
    }
}