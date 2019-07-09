using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0708_RGBToGray
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
            open_picture.Title = "Open RGB";
            open_picture.Filter = filterName;
            if(open_picture.ShowDialog() == DialogResult.OK)
            {
                string strFilename = open_picture.FileName;
                image = Image.FromFile(strFilename);
                graphics.DrawImage(image, 20, 50, image.Width, image.Height);
            }
            graphics.Dispose();
        }

        private void Button_gray_Click(object sender, EventArgs e)
        {
            int x, y, brightness;
            Color color, gray;
            Graphics graphics = CreateGraphics();
            bitmap = new Bitmap(image);
            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    brightness = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    // 흑백화 하기위한 이상적인 rgb 값.
                    gray = Color.FromArgb(brightness, brightness, brightness);
                    bitmap.SetPixel(x, y, gray);
                }
            }
            graphics.DrawImage(bitmap, 20 + bitmap.Width, 50, bitmap.Width, bitmap.Height);
            graphics.Dispose();
        }

        private void Button_open_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {            
            //button_gray.Location.Offset((int)ActiveForm.Location.X - 10, 12);            
            //button_open.Location.Offset((int)ActiveForm.Location.X - 10, 41);            
            Graphics graphics = CreateGraphics();
            graphics.DrawImage(image, 20, 50, image.Width, image.Height);
            graphics.DrawImage(bitmap, 20 + bitmap.Width, 50, bitmap.Width, bitmap.Height);
            graphics.Dispose();
            // 폼 사이즈 변경에도 사진이 계속 짤리지 않도록 다시 그려줌            
        }

        private void Button_brighter_Click(object sender, EventArgs e)
        {
            int x, y;
            int r, g, b;
            const int ADD_VALUE = 20;
            Color color;
            Graphics graphics = CreateGraphics();
            bitmap = new Bitmap(image);
            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    r = color.R + ADD_VALUE;if (r > 255) r = 255;
                    g = color.G + ADD_VALUE;if (g > 255) g = 255;
                    b = color.B + ADD_VALUE;if (b > 255) b = 255;
                    color = Color.FromArgb(r, g, b);
                    bitmap.SetPixel(x, y, color);
                }
            }
            graphics.DrawImage(bitmap, 20 + bitmap.Width, 50, bitmap.Width, bitmap.Height);
            graphics.Dispose();
        }
    }
}
