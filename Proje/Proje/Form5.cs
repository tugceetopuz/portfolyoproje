using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form5 : Form
    {
        Image img;
        string[] exten = { ".PNG", ".JPEG", ".JPG", ".GIF" };
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompressImage(textBoxSrc.Text, 30, textBoxOutPut.Text);
            MessageBox.Show ( "Resim Sıkıştırıldı");

        }


        private string CompressImage(string InputImage, int Quality, string OutPutDirectory)
        {
            using (Bitmap mybitmab = new Bitmap(@InputImage))
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder myEncoder =
                       System.Drawing.Imaging.Encoder.Quality;

                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, Quality);
                myEncoderParameters.Param[0] = myEncoderParameter;

                string NewOutputPath = @OutPutDirectory + "\\" + Path.GetFileNameWithoutExtension(InputImage) + Path.GetExtension(InputImage);

                 mybitmab.Save(NewOutputPath, jpgEncoder, myEncoderParameters);

                return NewOutputPath;
            }

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void textBoxOutPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSrc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images | *.png;*.jpg;*.jpeg;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxSrc.Text = ofd.FileName;
                img = Image.FromFile(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                textBoxOutPut.Text = fbd.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }
    }
}
