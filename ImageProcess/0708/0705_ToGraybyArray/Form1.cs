using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0705_ToGraybyArray
{
    public partial class Form1 : Form
    {
        Image image;
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_open_Click(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            String filterName = "All Files(*.*)|*.*|Bitmap File(*.bmp)|*.bmp|";
            filterName = filterName
                + "Gif File(*.gif)|*.gif|Jpeg File(*.jpg)|*.jpg";
            ofdOpen.Title = "Open RGB";
            ofdOpen.Filter = filterName;
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                string strFilename = ofdOpen.FileName;
                image = Image.FromFile(strFilename);
                graphics.DrawImage(image, 20, 50, image.Width, image.Height);
            }
            graphics.Dispose();
        }

        private void Button_gray_Click(object sender, EventArgs e)
        {
            int x, y;
            int brightness;
            const int ADD_VALUE = 30;
            Color color;
            int[,] grayArray = new int[image.Height, image.Width];
            Graphics graphics = CreateGraphics();
            bitmap = new Bitmap(image);
            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    color = bitmap.GetPixel(x, y);
                    brightness = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    grayArray[y, x] = brightness;
                }
            }
            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    grayArray[y, x] += ADD_VALUE;
                    if(grayArray[y, x] > 255)
                    {
                        grayArray[y, x] = 255;
                    }
                }
            }
            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    bitmap.SetPixel(x, y, color);
                }
            }
            graphics.DrawImage(bitmap, 20 + bitmap.Width, 50, bitmap.Width, bitmap.Height);
            graphics.Dispose();
        }
        // 픽셀 단위로 영상을 변환.

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.DrawImage(image, 20, 50, image.Width, image.Height);
            graphics.DrawImage(bitmap, 20 + bitmap.Width, 50, bitmap.Width, bitmap.Height);
            graphics.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            if (image == null)
            {

            }
            else
            {
                graphics.DrawImage(image, 20, 50, image.Width, image.Height);
                if (bitmap != null)
                {
                    graphics.DrawImage(bitmap, 20 + bitmap.Width, 50, bitmap.Width, bitmap.Height);
                }                
            }
            graphics.Dispose();
        }
    }
}
