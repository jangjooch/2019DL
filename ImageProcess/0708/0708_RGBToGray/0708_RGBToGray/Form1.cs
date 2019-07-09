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
            if (open_picture.ShowDialog() == DialogResult.OK)
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
            Bitmap bitmap = new Bitmap(image);
            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    brightness = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    gray = Color.FromArgb(brightness, brightness, brightness);
                    bitmap.SetPixel(x, y, gray);
                }

            }
            graphics.DrawImage(bitmap, 30 + bitmap.Width, 50, bitmap.Width, bitmap.Height);
            // 30 + bitmap.Width에서 이 없으면 겹쳐버리기에 이를 방지하고자 함.
            graphics.Dispose();
        }
    }
}
