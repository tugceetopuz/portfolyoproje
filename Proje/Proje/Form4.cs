using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form4 : Form
    {
        Image img;
        string[] exten = { ".PNG", ".JPEG", ".JPG", ".GIF" };
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < exten.Length; i++)
                comboBox.Items.Add(exten[i]);

        }

        private void buttonSec1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images | *.png;*.jpg;*.jpeg;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtslct.Text = ofd.FileName;
                img = Image.FromFile(ofd.FileName);
            }
        }

        private void buttonSec2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                txtsv.Text = fbd.SelectedPath;
        }

        private void buttonBoyutlandir_Click(object sender, EventArgs e)
        {
            int w = Convert.ToInt32(txtw.Text), h = Convert.ToInt32(txth.Text);
            img = Resize(img, w, h);
            ((Button)sender).Enabled = false;
            MessageBox.Show("image resized");
        }

        Image Resize(Image image, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.DrawImage(image, 0, 0, w, h);
            graphic.Dispose();

            return bmp;
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            int dot = 0, slash = 0;
            for (int j = txtslct.Text.Length - 1; j >= 0; j--)
                if (txtslct.Text[j] == '.')
                    dot = j;
                else if (txtslct.Text[j] == '\\')
                {
                    slash = j;
                    break;
                }

            img.Save(txtsv.Text + "\\" + txtslct.Text.Substring(slash + 1, dot - slash - 1) + exten[comboBox.SelectedIndex]);
            ((Button)sender).Enabled = false;
            MessageBox.Show("image saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }
    }
}
