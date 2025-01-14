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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        JsonMain JsonMain = new JsonMain();
        private void Main_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < JsonMain.LocationList().Count; i++)
            {
                listBox1.Items.Add(JsonMain.LocationList()[i].name);
            }

        }

        private void llCretion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.SelectedPath;
                JsonMain.LocationCreate(textBox1.Text, filePath + "\\");
            }



            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.LocationList().Count; i++)
            {
                listBox1.Items.Add(JsonMain.LocationList()[i].name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JsonMain.LocationInfo(listBox1.SelectedIndex);
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();

        }

        private void llAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Vott Files (*.Vott)|*.Vott";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                JsonMain.LocationAdd(new FileInfo(openFileDialog.FileName).Name.Split(".")[0], openFileDialog.FileName);
            }

            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.LocationList().Count; i++)
            {
                listBox1.Items.Add(JsonMain.LocationList()[i].name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JsonMain.LocationRemove(listBox1.SelectedIndex);

            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.LocationList().Count; i++)
            {
                listBox1.Items.Add(JsonMain.LocationList()[i].name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBox1.SelectedIndex == -1))
            {
                JsonMain.InfoClass Info = JsonMain.Info(listBox1.SelectedIndex);

                richTextBox1.Text = (
                    "Name:" + Info.Name +
                    "\n\n" +
                    "Location:" + Info.Location +
                    "\n\n" +
                    "Tags:" + Info.Tags +
                    "\n\n" +
                    "AssetSayisi:" + Info.AssetCount);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.SelectedPath;
                JsonMain.LocationChange(listBox1.SelectedIndex, filePath);
            }

            listBox1.SelectedIndex = -1;
            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.LocationList().Count; i++)
            {
                listBox1.Items.Add(JsonMain.LocationList()[i].name);
            }
        }

        private void bttnCN_Click(object sender, EventArgs e)
        {
            JsonMain.LocationNameChange(listBox1.SelectedIndex, textBox2.Text);

            listBox1.SelectedIndex = -1;
            listBox1.Items.Clear();
            for (int i = 0; i < JsonMain.LocationList().Count; i++)
            {
                listBox1.Items.Add(JsonMain.LocationList()[i].name);
            }
        }
    }
}
