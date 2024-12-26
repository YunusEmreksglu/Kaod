using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangaKB.Classlar;
using System.Windows.Forms.Design;

namespace MangaKB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        JsonMain JsonMain = new JsonMain();
        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < JsonMain.KonumListesi().Count; i++)
            {
                listBox1.Items.Add(JsonMain.KonumListesi()[i].name);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.SelectedPath;
                JsonMain.KonumOlusturma(textBox1.Text, filePath + "\\");
            }



            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.KonumListesi().Count; i++)
            {
                listBox1.Items.Add(JsonMain.KonumListesi()[i].name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JsonMain.KonumBilgisi(listBox1.SelectedIndex);
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Vott Files (*.Vott)|*.Vott";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                JsonMain.KonumEkleme(new FileInfo(openFileDialog.FileName).Name.Split(".")[0], openFileDialog.FileName);
            }

            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.KonumListesi().Count; i++)
            {
                listBox1.Items.Add(JsonMain.KonumListesi()[i].name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JsonMain.KonumSilme(listBox1.SelectedIndex);

            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.KonumListesi().Count; i++)
            {
                listBox1.Items.Add(JsonMain.KonumListesi()[i].name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedIndex == -1))
            {
                JsonMain.Bilgi bilgi = JsonMain.ToplamBilgi(listBox1.SelectedIndex);

                richTextBox1.Text = richTextBox1.Text.Replace("İsmi:" +
                    "\n\n" +
                    "Konum:" +
                    "\n\n" +
                    "Tagler:" +
                    "\n\n" +
                    "AssetSayisi:",
                    "İsmi:" + bilgi.isim +
                    "\n\n" +
                    "Konum:" + bilgi.konum +
                    "\n\n" +
                    "Tagler:" + bilgi.Tagler +
                    "\n\n" +
                    "AssetSayisi:" + bilgi.AssetSayisi);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.SelectedPath;
                JsonMain.Bilgidegistir(listBox1.SelectedIndex,filePath);
            }

            JsonMain.Bilgi bilgi = JsonMain.ToplamBilgi(listBox1.SelectedIndex);

            richTextBox1.Text = richTextBox1.Text.Replace("İsmi:" +
                "\n\n" +
                "Konum:" +
                "\n\n" +
                "Tagler:" +
                "\n\n" +
                "AssetSayisi:",
                "İsmi:" + bilgi.isim +
                "\n\n" +
                "Konum:" + bilgi.konum +
                "\n\n" +
                "Tagler:" + bilgi.Tagler +
                "\n\n" +
                "AssetSayisi:" + bilgi.AssetSayisi);

            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.KonumListesi().Count; i++)
            {
                listBox1.Items.Add(JsonMain.KonumListesi()[i].name);
            }
        }
    }
}
