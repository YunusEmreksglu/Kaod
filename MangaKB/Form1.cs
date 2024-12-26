using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Tokenizers;
using SkiaSharp;
using static MangaKB.Classlar.CommonMethods;
using MangaKB.Classlar;


namespace MangaKB
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void RaidoButton()
        {
            panel2.Controls.Clear();


            int l = 0;

            int aralik = 20;
            try
            {
                if (!(json.Tags() == null))
                {
                    foreach (List<string> Tag in json.Tags())
                    {
                        RadioButton radioButton = new RadioButton();

                        int left = 5;
                        int top = l == 0 ? (l * (panel1.Width) / json.Tags().Count) : aralik + (l * (panel1.Width) / json.Tags().Count);

                        radioButton.Name = Tag[0];
                        radioButton.Text = Tag[0];
                        radioButton.Left = left;
                        radioButton.Top = top;
                        radioButton.Tag = l;
                        radioButton.ForeColor = System.Drawing.ColorTranslator.FromHtml(Tag[1]);

                        radioButton.CheckedChanged += RaidoButtonCheckedChanged;

                        l++;

                        panel2.Controls.Add(radioButton);
                    }
                }
            }
            catch
            {

            }

        }



        MLImage imagePath;

        int i = 0;




        private void SistemYuklendiginde(object sender, EventArgs e)
        {

            RaidoButton();

            ResimBox = pictureBox1;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ResimleriSil(panel1);
            ResimYukle();

            int x = 0;


            Bitmap mh = new Bitmap(pictureBox1.Image);

            Graphics g = Graphics.FromImage(mh);
            Pen pen = new Pen(Color.BurlyWood, 3);

            MLModel1.ModelInput a = new MLModel1.ModelInput() { Image = imagePath };


            progressBar1.Maximum = (int)MLModel1.Predict(a).PredictedBoundingBoxes.Length / 4;


            for (int y = 0; y < progressBar1.Maximum; y++)
            {
                if (0.5 < MLModel1.Predict(a).Score[y])
                {
                    float[] v = MLModel1.Predict(a).PredictedBoundingBoxes;
                    string t = MLModel1.Predict(a).PredictedLabel[y].ToString() + MLModel1.Predict(a).Score[y].ToString();

                    float oran = 728 / (float)new Bitmap(filePath).Height;



                    int left = (int)Math.Round((float)v[0 + (y * 4)] * oran);
                    int top = (int)Math.Round((float)v[1 + (y * 4)] * oran) - 1;
                    int width = (int)Math.Round(((float)v[2 + (y * 4)] * oran) - ((float)v[0 + (y * 4)] * oran)) - 1;
                    int height = (int)Math.Round(((float)v[3 + (y * 4)] * oran) - ((float)v[1 + (y * 4)] * oran)) - 1;

                    left = 512 / 2 > left ? left + 1 : left - 1;
                    top = 728 / 2 > top ? top + 1 : top - 1;

                    foreach (RadioButton radioButton in panel2.Controls)
                    {
                        if (radioButton.Text == MLModel1.Predict(a).PredictedLabel[y].ToString())
                        {
                            ResimYukle();
                            Kutular.Add(new Kutu() { Left = left, Top = top, Width = width, Height = height, Tag = MLModel1.Predict(a).PredictedLabel[y].ToString() });
                            Kenar(new Rectangle(left, top, width, height), tag = new Tag() { Text = MLModel1.Predict(a).PredictedLabel[y].ToString(), Color = radioButton.ForeColor }, panel1);



                        }
                    }



                }

                progressBar1.Value = y + 1;



            }
            pictureBox1.Image = mh;

            KenarlarLoad();


        }

        private void RaidoButtonCheckedChanged(object sender, EventArgs e)
        {

            RadioButton radioButton = sender as RadioButton;
            tag = new Tag()
            {
                Text = radioButton.Text,
                Color = radioButton.ForeColor
            };

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !(tag.Text == (null) && _isDragging == false))
            {
                isDrawing = false;

                var rect = new Rectangle(
                    Math.Min(startPoint.X, pictureBox1.PointToClient(MousePosition).X),
                    Math.Min(startPoint.Y, pictureBox1.PointToClient(MousePosition).Y),
                    Math.Abs(startPoint.X - pictureBox1.PointToClient(MousePosition).X),
                    Math.Abs(startPoint.Y - pictureBox1.PointToClient(MousePosition).Y)
                );

                Kutular.Add(new Kutu() { Left = rect.Left, Top = rect.Top, Width = rect.Width, Height = rect.Height, Tag = tag.Text });
                Kenar(rect, new Tag { Text = tag.Text, Color = tag.Color }, panel1);
                KenarlarLoad();
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && _isDragging == false && !(tag.Text == null))
            {
                startPoint = e.Location;
                isDrawing = true;
            }


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && !(tag.Text == (null)))
            {
                pictureBox1.Invalidate(); // Paint olayýný tetikle
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen thickPen = new Pen(tag.Color, 5);

            if (isDrawing && !(tag.Text == (null)))
            {

                // Fare hareket ederken kareyi çiz
                var rect = new Rectangle(
                    Math.Min(startPoint.X, pictureBox1.PointToClient(MousePosition).X),
                    Math.Min(startPoint.Y, pictureBox1.PointToClient(MousePosition).Y),
                    Math.Abs(startPoint.X - pictureBox1.PointToClient(MousePosition).X),
                    Math.Abs(startPoint.Y - pictureBox1.PointToClient(MousePosition).Y)
                );
                e.Graphics.DrawRectangle(thickPen, rect); // Siyah renkte kare çiz

            }
        }

        private void Kaydet(object sender, EventArgs e)
        {

            ResimKesinSil();
            ResimYukle();

            json.Save(Kutular, pictureBox1.Width, pictureBox1.Height, new FileInfo(filePath), new Bitmap(Resim));
        }

        private void Sil(object sender, EventArgs e)
        {
            ResimleriSil(panel1);
            ResimYukle();
            KenarlarLoad();

            pictureBox1.Image = Resim;
        }

        private void SecilenSil(object sender, EventArgs e)
        {
            ResimSil(SelectButtonIndexT, panel1);
            ResimYukle();
            KenarlarLoad();

            pictureBox1.Image = Resim;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Resmi PictureBox'a yükle
                filePath = openFileDialog1.FileName;

                ResimYukle();

                pictureBox1.Image = Resim;


                // Resim yolunu sakla
                imagePath = MLImage.CreateFromFile(openFileDialog1.FileName);

                MessageBox.Show($"Resmin yolu: {filePath}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditImage editImage = new EditImage();
            editImage.ShowDialog();
        }


        private void button8_Click(object sender, EventArgs e)
        {

            int red = new Random().Next(0, 256);  // 0-255 arasý rastgele deðer
            int green = new Random().Next(0, 256);
            int blue = new Random().Next(0, 256);

            json.TagEkle(textBox1.Text, $"#{red:X2}{green:X2}{blue:X2}");

            RaidoButton();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach(RadioButton radioButton in panel2.Controls)
            {
                if (radioButton.Checked)
                {
                    json.TagSilme(Convert.ToInt32(radioButton.Tag));
                }
            }

            RaidoButton();
        }
    }
}
