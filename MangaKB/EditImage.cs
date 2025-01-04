using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TorchSharp.Modules;
using static MangaKB.Classlar.CommonMethods;
using MangaKB.Classlar;
using MangaKB.Classlar.JsonClass;


namespace MangaKB
{
    public partial class EditImage : Form
    {

        public EditImage()
        {
            InitializeComponent();
        }

        #region metot
        public void ResimleriSirala(int First, int Last)
        {

            panel2.Controls.Clear();
            panel7.Controls.Clear();

            int panel2zero = 0;
            int panel7zero = 0;

            for (int m = First; m < Last; m++)
            {
                pictureBoxindex = First;
                PictureBox pictureBox = new PictureBox() { Width = 120, Height = 170 };
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Tag = m;
                try
                {
                    string imagePath = AssetDataJson[m].asset.path.Contains("file:")
                        ? AssetDataJson[m].asset.path.Split("file:")[1]
                        : AssetDataJson[m].asset.path;

                    pictureBox.Image = new Bitmap(Image.FromFile(imagePath), new Size(120, 170));
                    pictureBox.Left = 5;
                    pictureBox.Validated += PicturBoxClick;
                    pictureBox.Click += PicturBoxClick;

                    if (json.DostaTarihi() > File.GetLastWriteTime($"C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\MangaDataS\\vott-json-export\\{AssetDataJson[m].asset.id}-asset.json"))
                    {
                        pictureBox.Location = new Point(5, 15 + (panel2zero * 185));
                        panel2.Controls.Add(pictureBox);
                        panel2zero++;
                    }

                    else
                    {
                        pictureBox.Location = new Point(5, 15 + (panel7zero * 185));
                        panel7.Controls.Add(pictureBox);
                        panel7zero++;
                    }

                    m.ToString();
                }
                catch (Exception ex)
                {
                    
                }

            }

        }

        public void ResimButton()
        {

            int zero = 1;
            for (int m = 0; m < AssetDataJson.Count; m++)
            {

                if (m == 0)
                {
                    Button button = new Button() { Width = 60, Height = 60 };
                    button.Text = $"{m.ToString()}<{(m + 50).ToString()}";
                    button.Location = new Point(5, 5);
                    button.Click += ResimButtonD;
                    panel4.Controls.Add(button);
                }
                else if (m % 50 == 0)
                {
                    Button button = new Button() { Width = 60, Height = 60 };
                    button.Text = $"{m.ToString()}<{(m + 50).ToString()}";
                    button.Location = new Point(5 + ((m % 100) == 0 ? 0 : 60), 5 + ((m / 100) * 60));
                    button.Click += ResimButtonD;
                    panel4.Controls.Add(button);
                    zero++;

                }


            }

        }

        public void ResimeOdaklan(int Ekle)
        {
            for (int i = 0; i < panel2.Controls.Count; i++)
            {
                if (panel2.Controls[i].Focused)
                {
                    // Bir sonraki kontrol varsa ona odaklan
                    int nextIndex = (i + Ekle) % panel2.Controls.Count;
                    panel2.Controls[nextIndex].Focus();
                    return;
                }
            }

            // Hiçbir kontrol odaklanmadıysa ilkine odaklan
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Focus();
            }
        }

        public void RaidoButton()
        {


            int l = 0;

            int aralik = 20;
            if(!(json.Tags() == null))
            {
                foreach (List<string> Tag in json.Tags())
                {
                    RadioButton radioButton = new RadioButton();

                    int left = l == 0 ? (l * (panel1.Width) / json.Tags().Count) : aralik + (l * (panel1.Width) / json.Tags().Count);
                    int top = 20 * 1;

                    radioButton.Name = Tag[0];
                    radioButton.Text = Tag[0];
                    radioButton.Left = left;
                    radioButton.Top = top;
                    radioButton.ForeColor = System.Drawing.ColorTranslator.FromHtml(Tag[1]);

                    radioButton.CheckedChanged += RaidoButtonCheckedChanged;

                    l++;

                    panel1.Controls.Add(radioButton);
                }
            }

        }
        #endregion

        
        private void SistemYuklendiginde(object sender, EventArgs e)
        {
            ResimBox = pictureBox1;

            RaidoButton();
            AssetDataJson = json.Images();
            ResimButton();
            panel3.Controls.Add(pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResimKesinSil();
            ResimYukle();

            json.Save(Kutular, pictureBox1.Width, pictureBox1.Height, new FileInfo(filePath), new Bitmap(Resim));
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
                Kenar(rect, new Tag { Text = tag.Text, Color = tag.Color }, panel3);
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
                pictureBox1.Invalidate(); // Paint olayını tetikle
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;


                ResimYukle();
                pictureBox1.Image = Resim;
            }

            ResimleriSil(panel3);

        }

        private void SLBT_Click(object sender, EventArgs e)
        {
            ResimleriSil(panel3);
            ResimYukle();
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

        private void PicturBoxClick(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;

            button1.Text = pictureBox.Tag.ToString();

            ResimleriSil(panel3);

            pictureBoxindex = Convert.ToInt32(pictureBox.Tag);

            try
            {
                filePath = AssetDataJson[pictureBoxindex].asset.path.Split("file:")[1];
                ResimYukle();
            }
            catch
            {
                filePath = AssetDataJson[pictureBoxindex].asset.path;
                ResimYukle();
            }

            foreach (AssetJson.Region Box in AssetDataJson[pictureBoxindex].regions)
            {
                float oran = (728 / (float)(new Bitmap(filePath)).Height);
                float Eksik = -5 + ((512 - ((float)(new Bitmap(filePath).Size.Width) * oran)) / 2);

                Rectangle rect = new Rectangle();


                rect = new Rectangle()
                {
                    X = Convert.ToInt32(Box.boundingBox.left)
,
                    Y = Convert.ToInt32(Box.boundingBox.top) 
,
                    Width = Convert.ToInt32(Box.boundingBox.width)
,
                    Height = Convert.ToInt32(Box.boundingBox.height)  
                };



                foreach (RadioButton radioButton in panel1.Controls)
                {
                    if (radioButton.Text == Box.tags[0])
                    {
                        Kutular.Add(new Kutu() { Left = rect.Left, Top = rect.Top, Width = rect.Width, Height = rect.Height, Tag = Box.tags[0] });
                        Kenar(rect, new Tag { Text = Box.tags[0], Color = radioButton.ForeColor }, panel3);

                    }
                }

            }

            KenarlarLoad();

            pictureBox1.Image = Resim;







        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            json.Export();

            panel2.Controls.Clear();
            panel7.Controls.Clear();

            ResimButton();


        }

        private void ResimButtonD(object? sender, EventArgs e)
        {
            Button button = sender as Button;

            ResimleriSirala(Convert.ToInt32(button.Text.Split('<')[0]), Convert.ToInt32(button.Text.Split('<')[1]));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AssetDataJson = json.Images();
            ResimleriSirala(pictureBoxindex, pictureBoxindex + 50);

            try
            {
                filePath = AssetDataJson[pictureBoxindex].asset.path.Split("file:")[1];
                ResimYukle();
            }
            catch
            {
                filePath = AssetDataJson[pictureBoxindex].asset.path;
                ResimYukle();
            }

            foreach (AssetJson.Region Box in AssetDataJson[pictureBoxindex].regions)
            {
                Rectangle rect = new Rectangle()
                {
                    X = Convert.ToInt32(Box.boundingBox.left)
                    ,
                    Y = Convert.ToInt32(Box.boundingBox.top)
                    ,
                    Width = Convert.ToInt32(Box.boundingBox.width)
                    ,
                    Height = Convert.ToInt32(Box.boundingBox.height)
                };


                foreach (RadioButton radioButton in panel1.Controls)
                {
                    if (radioButton.Text == Box.tags[0])
                    {

                        Kutular.Add(new Kutu() { Left = rect.Left, Top = rect.Top, Width = rect.Width, Height = rect.Height, Tag = Box.tags[0] });
                        Kenar(rect, new Tag { Text = Box.tags[0], Color = radioButton.ForeColor }, panel3);

                    }
                }

            }

            KenarlarLoad();

            pictureBox1.Image = Resim;

        }

        private void EditImage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.W: { ResimeOdaklan(-1); break; }
                case Keys.S: { ResimeOdaklan(1); break; }
                case Keys.Delete: { ResimSil(SelectButtonIndexT,panel3); break; }
            }


        }
    }
}