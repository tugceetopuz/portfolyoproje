using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//adding reference to library
using System.Drawing.Imaging;

namespace Proje
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void scrColorComponent_Scroll(object sender, ScrollEventArgs e)
        {
            //redrawing & adjusting the selected color
            SelectedColor.BackColor = Color.FromArgb(RedSelection.Value, GreenSelection.Value, BlueSelection.Value);
            ColorPictur();
        }
        private void ColorPictur()
        {
            //applyig color
            picToned.Image = ToColorTone(picOriginal.Image, SelectedColor.BackColor);
        }
        private Bitmap ToColorTone(Image image, Color color)
        {
            //creating a new bitmap image with selected color.
            float scale = BrightnessSelection.Value / 128f;

            float r = color.R / 255f * scale;
            float g = color.G / 255f * scale;
            float b = color.B / 255f * scale;

            // Color Matrix
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {r, 0, 0, 0, 0},
                new float[] {0, g, 0, 0, 0},
                new float[] {0, 0, b, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });
            ImageAttributes ImAttribute = new ImageAttributes();
            ImAttribute.SetColorMatrix(cm);

            //Color Matrix on new bitmap image
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width - 1, 0),
                new Point(0, image.Height - 1),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            Bitmap myBitmap = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(myBitmap))
            {
                graphics.DrawImage(image, points, rect, GraphicsUnit.Pixel, ImAttribute);
            }
            return myBitmap;
        }

        private void SavePicBtn_Click(object sender, EventArgs e)
        {
            //saving image file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";

            sfd.ShowDialog();
            string filename = sfd.FileName;
            picToned.Image.Save(filename);

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            //setting initial values
            RedSelection.Value = 128;
            GreenSelection.Value = 128;
            BlueSelection.Value = 128;
            BrightnessSelection.Value = 128;
            SelectedColor.BackColor = Color.FromArgb(RedSelection.Value, GreenSelection.Value, BlueSelection.Value);
            ColorPictur();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png|video|*..avi|Tüm Dosyalar|*.*";
            dosya.Title = "";
            dosya.ShowDialog();
            string Dosyayolu = dosya.FileName;
            picOriginal.ImageLocation = Dosyayolu;
            picToned.ImageLocation = Dosyayolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }
    }
}