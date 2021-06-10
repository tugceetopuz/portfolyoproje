using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
    

    private static ImageCodecInfo TipBilgisi(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        private void Btn4_Click (Image Resim)
        {
            Bitmap myBitmap;
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            myBitmap = new Bitmap(Resim);

            myImageCodecInfo = TipBilgisi("image/jpeg");

            myEncoder = System.Drawing.Imaging.Encoder.Quality;

            myEncoderParameters = new EncoderParameters(1);

           
            myEncoderParameter = new EncoderParameter(myEncoder, 1L);

            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap.Save("Kayıt Edilecek Dizin", myImageCodecInfo, myEncoderParameters);
        }

       
        
        Bitmap bmp;
        public void Btn3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Resim Dosyası |*.jpg;*.nef;*.png|video|*..avi|Tüm Dosyalar|*.*";
            sfd.Title = "";
            sfd.FileName = "resim";
            DialogResult sonuc = sfd.ShowDialog();
            if(sonuc==DialogResult.OK)
            {
                pictureBox2.Image.Save(sfd.FileName);
            }
        }

        public void Btn6_Click(object sender, EventArgs e)
        {
            int xofseti, yofseti;
            var a=Convert.ToInt32(textBox1.Text);
            

            var orjinalGoruntu=new Bitmap (pictureBox1.Image);
            var goruntuGenislik = orjinalGoruntu.Width;
            var goruntuYukseklik = orjinalGoruntu.Height;

            var piksellestirilmisGoruntu = new Bitmap(goruntuGenislik, goruntuYukseklik);

            for (var i=0;i<goruntuGenislik;i += a)
            {
                for (var j = 0; j < goruntuYukseklik; j += a)
                {
                    xofseti = yofseti = a/2;
                    if(i+xofseti>=goruntuGenislik)
                    {
                        xofseti = goruntuGenislik - i - 1;
                    }
                    if (j + yofseti >= goruntuYukseklik)
                    {
                        yofseti = goruntuYukseklik - j - 1;
                    }
                    var piksel = orjinalGoruntu.GetPixel(i + xofseti , j + yofseti);

                    for (var x=i;x<i+a && x < goruntuGenislik;x++)
                    {
                        for (var y = j; y < j + a && y < goruntuYukseklik; y++)
                        {
                            piksellestirilmisGoruntu.SetPixel(x, y, piksel);
                        }
                    }
                }
            }
            pictureBox2.Image = piksellestirilmisGoruntu;

        }
        Color renk;
       
        
    
        private void Btn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png|video|*..avi|Tüm Dosyalar|*.*";
            dosya.Title = "";
            dosya.ShowDialog();
            string Dosyayolu = dosya.FileName;
            pictureBox1.ImageLocation = Dosyayolu;
            pictureBox2.ImageLocation = Dosyayolu;
        }

        private void Btn_yaziekle_Click(object sender, EventArgs e)
        {
            label3.Text = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }

       










        /* private void Btn4_Click(object sender, EventArgs e)
         {

         }*/
    }

}

    

