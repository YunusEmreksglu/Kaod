using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangaKB.Classlar.JsonClass;

namespace MangaKB.Classlar
{
    public class Tag
    {
        public string Text { get; set; }
        public Color Color { get; set; }
    }

    public class Box
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Tag { get; set; }
    }

    public class Frame
    {
        public int id { get; set; }
        public Tag tag { get; set; }
        public List<Button> Buttons { get; set; }
    }

    public static class CommonMethods
    {
        public static List<Button> Corner(Rectangle rect, Tag tag, Panel panel)
        {
            List<Button> buttons = new List<Button>();

            buttons.Add(new Button() { Size = new Size(5, 5), Text = "", Tag = "0", Location = new Point(rect.Left, rect.Top) });
            buttons.Add(new Button() { Size = new Size(5, 5), Text = "", Tag = "1", Location = new Point(rect.Left + rect.Width, rect.Top) });
            buttons.Add(new Button() { Size = new Size(5, 5), Text = "", Tag = "2", Location = new Point(rect.Left + rect.Width, rect.Top + rect.Height) });
            buttons.Add(new Button() { Size = new Size(5, 5), Text = "", Tag = "3", Location = new Point(rect.Left, rect.Top + rect.Height) });

            foreach (Button button in buttons)
            {
                button.MouseMove += FormMouseMove;
                button.MouseDown += FormMouseDown;
                button.MouseUp += FormMouseUp;
                panel.Controls.Add(button);
                button.BringToFront();
            }

            ListButton.Add(new Frame() { Buttons = buttons, id = ButtonIndexT, tag = tag });
            ButtonIndexT++;

            return buttons;
        }

        public static void CornersLoad()
        {
            foreach (Frame bu in ListButton)
            {
                if (!(bu.id == 4444))
                {
                    pens(bu.Buttons, Image, bu.tag.Color);
                }

            }

        }

        public static void CornerLoad(Frame Frame, Image image, Color color)
        {
            pen(Frame.Buttons, image, color);
        }

        public static void pen(List<Button> ListButton, Image Image, Color iro)
        {
            // Create a new bitmap with the same dimensions to avoid modifying the original
            Bitmap tempBitmap = new Bitmap(Image.Width, Image.Height);
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                // First draw the original image
                g.DrawImage(Image, 0, 0);

                // Enable anti-aliasing for smoother lines
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Calculate points with proper offset
                Point p1 = new Point(ListButton[0].Location.X + ListButton[0].Width / 2,
                                   ListButton[0].Location.Y + ListButton[0].Height / 2);
                Point p2 = new Point(ListButton[1].Location.X + ListButton[1].Width / 2,
                                   ListButton[1].Location.Y + ListButton[1].Height / 2);
                Point p3 = new Point(ListButton[2].Location.X + ListButton[2].Width / 2,
                                   ListButton[2].Location.Y + ListButton[2].Height / 2);
                Point p4 = new Point(ListButton[3].Location.X + ListButton[3].Width / 2,
                                   ListButton[3].Location.Y + ListButton[3].Height / 2);

                // Create pen with proper settings
                using (Pen pen = new Pen(iro, 2))
                {
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


                    // Draw the rectangle using a single path for smoother corners
                    System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddLines(new Point[] { p1, p2, p3, p4, p1 });
                    g.DrawPath(pen, path);
                }
            }

            // Update the original image and picturebox
            Image = tempBitmap;
            ResimBox.Image = tempBitmap;
        }

        public static void pens(List<Button> ListButton, Image Image, Color iro)
        {
            // Create a new bitmap with the same dimensions to avoid modifying the original
            Bitmap tempBitmap = new Bitmap(Image.Width, Image.Height);
            Graphics g = Graphics.FromImage(Image);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;



            Point p1 = new Point(ListButton[0].Location.X + ListButton[0].Width / 2, ListButton[0].Location.Y + ListButton[0].Height / 2);
            Point p2 = new Point(ListButton[1].Location.X + ListButton[1].Width / 2, ListButton[1].Location.Y + ListButton[1].Height / 2);
            Point p3 = new Point(ListButton[2].Location.X + ListButton[2].Width / 2, ListButton[2].Location.Y + ListButton[2].Height / 2);
            Point p4 = new Point(ListButton[3].Location.X + ListButton[3].Width / 2, ListButton[3].Location.Y + ListButton[3].Height / 2);


            Pen pen = new Pen(iro, 2);


            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p1, p4);
            g.DrawLine(pen, p2, p3);
            g.DrawLine(pen, p4, p3);

            ResimBox.Image = Image;


        }

        public static void ImageLoad()
        {


            Bitmap overlayImage = new Bitmap(filePath);

            // Create new bitmap with white background
            Bitmap mainBitmap = new Bitmap(512, 728);
            using (Graphics g = Graphics.FromImage(mainBitmap))
            {
                g.Clear(Color.White);

                if (overlayImage.Width > 512 || overlayImage.Height > 728)
                {
                    // Scale image maintaining aspect ratio
                    float ratio = Math.Min(512f / overlayImage.Width, 728f / overlayImage.Height);
                    int newWidth = (int)(overlayImage.Width * ratio);
                    int newHeight = (int)(overlayImage.Height * ratio);
                    int x = (512 - newWidth) / 2;
                    int y = (728 - newHeight) / 2;

                    g.DrawImage(overlayImage, x, y, newWidth, newHeight);
                }
                else
                {
                    // Center the image if smaller than max dimensions
                    int x = (mainBitmap.Width - overlayImage.Width) / 2;
                    int y = (mainBitmap.Height - overlayImage.Height) / 2;
                    g.DrawImage(overlayImage, x, y);
                }
            }

            Image = mainBitmap;


        }

        public static void CornerRemove(int Sil, Panel panel)
        {

            panel.Controls.Remove(ListButton[Sil].Buttons[0]);
            ListButton[Sil].Buttons[0].Dispose();
            panel.Controls.Remove(ListButton[Sil].Buttons[1]);
            ListButton[Sil].Buttons[1].Dispose();
            panel.Controls.Remove(ListButton[Sil].Buttons[2]);
            ListButton[Sil].Buttons[2].Dispose();
            panel.Controls.Remove(ListButton[Sil].Buttons[3]);
            ListButton[Sil].Buttons[3].Dispose();
            Boxs[Sil].Tag = "4444";
            ListButton[Sil].id = 4444;

            ImageLoad();
            CornersLoad();

        }

        public static void CornerExactRemove()
        {
            Boxs = Boxs.Where(item => item.Tag != "4444").ToList();
            ListButton = ListButton.Where(item => item.id != 4444).ToList();
        }

        public static void CornersRemove(Panel panel)
        {
            Boxs.Clear();
            ButtonIndexT = 0;
            ListButton.Clear();

            foreach (Control control in panel.Controls.OfType<Button>().ToList())
            {
                panel.Controls.Remove(control);
                control.Dispose();
            }
        }

        public static void FormMouseDown(object sender, MouseEventArgs e)
        {

            ImageLoad();
            _isDragging = true;
            _lastLocation = e.Location;
            ResimBox.Invalidate();

        }

        public static void FormMouseMove(object sender, MouseEventArgs e)
        {


            int cerceveId = ListButton
            .FirstOrDefault(c => c.Buttons.Contains(sender as Button))?.id ?? -1;

            SelectButtonIndexT = cerceveId;

            if (_isDragging)
            {
                ListButton[cerceveId].Buttons[Convert.ToInt32((sender as Button).Tag.ToString())].Left += e.X - _lastLocation.X;
                ListButton[cerceveId].Buttons[Convert.ToInt32((sender as Button).Tag.ToString())].Top += e.Y - _lastLocation.Y;
                if (Convert.ToInt32((sender as Button).Tag.ToString()) % 2 == 0)
                {
                    ListButton[cerceveId].Buttons[Convert.ToInt32((sender as Button).Tag.ToString()) - 1 > -1 ? Convert.ToInt32((sender as Button).Tag.ToString()) - 1 : 3].Left += e.X - _lastLocation.X;
                    ListButton[cerceveId].Buttons[Convert.ToInt32((sender as Button).Tag.ToString()) + 1 < 4 ? Convert.ToInt32((sender as Button).Tag.ToString()) + 1 : 0].Top += e.Y - _lastLocation.Y;
                }
                else
                {
                    ListButton[cerceveId].Buttons[Convert.ToInt32((sender as Button).Tag.ToString()) - 1 > -1 ? Convert.ToInt32((sender as Button).Tag.ToString()) - 1 : 3].Top += e.Y - _lastLocation.Y;
                    ListButton[cerceveId].Buttons[Convert.ToInt32((sender as Button).Tag.ToString()) + 1 < 4 ? Convert.ToInt32((sender as Button).Tag.ToString()) + 1 : 0].Left += e.X - _lastLocation.X;
                }

                CornerLoad(ListButton[cerceveId], Image, ListButton[cerceveId].tag.Color);

            }



        }

        public static void FormMouseUp(object sender, MouseEventArgs e)
        {

            _isDragging = false;
            int cerceveId = ListButton
                .FirstOrDefault(c => c.Buttons.Contains(sender as Button))?.id ?? -1;



            Boxs[cerceveId] = new Box()
            {
                Left = Math.Min(ListButton[cerceveId].Buttons[0].Left, ListButton[cerceveId].Buttons[2].Left),
                Top = Math.Min(ListButton[cerceveId].Buttons[0].Top, ListButton[cerceveId].Buttons[2].Top),
                Width = Math.Abs(ListButton[cerceveId].Buttons[0].Left - ListButton[cerceveId].Buttons[2].Left),
                Height = Math.Abs(ListButton[cerceveId].Buttons[0].Top - ListButton[cerceveId].Buttons[2].Top),
                Tag = ListButton[cerceveId].tag.Text
            };
            CornersLoad();
        }


        // Additional variables for shared state

        public static JsonMain json = new JsonMain();
        public static List<Box> Boxs = new List<Box>();
        public static List<Frame> ListButton = new List<Frame>();
        public static Tag tag = new Tag();
        public static Bitmap Image = new Bitmap(512, 728);
        public static PictureBox ResimBox = new PictureBox();
        public static Point startPoint;
        public static bool isDrawing = false;
        public static string filePath;
        public static bool _isDragging = false;
        public static Point _lastLocation;
        public static int pictureBoxindex;
        public static int ButtonIndexT = 0;
        public static int SelectButtonIndexT = 0;
        public static List<AssetJson.AssetData> AssetDataJson = new List<AssetJson.AssetData>();

    }
}