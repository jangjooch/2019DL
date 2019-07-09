using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0708_GrayLevel
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Boolean mouse_down = false;
        Boolean UpDown;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 클릭시
            mouse_down = true;
            int x, y, band;
            double rate;
            Color color;
            int[,] grayArray = new int[ClientSize.Height, ClientSize.Width];
            Graphics graphics = CreateGraphics();
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            if (e.Button == MouseButtons.Left)
            {
                UpDown = true;
                rate = 256.0 / ClientSize.Width;
                band = ClientSize.Width / 8;
                for (y = 0; y < ClientSize.Height; y++)
                {
                    for (x = 0; x < ClientSize.Width; x++)
                    {
                        grayArray[y, x] = (int)((x / band) * band * rate);
                    }
                }
            }
            else
            {
                UpDown = false;
                rate = 256.0 / ClientSize.Height;
                band = ClientSize.Height / 8;
                for (x = 0; x < ClientSize.Width; x++)
                {
                    for (y = 0; y < ClientSize.Height; y++)
                    {
                        grayArray[y, x] = (int)((y / band) * band * rate);
                    }
                }
            }
            for (y = 0; y < ClientSize.Height; y++)
            {
                for (x = 0; x < ClientSize.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    bitmap.SetPixel(x, y, color);
                }
            }
            graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            graphics.Dispose();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            if (mouse_down)
            {
                graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                graphics.Dispose();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int x, y,band;
            double rate;
            Graphics graphics = CreateGraphics();
            Color color;
            int[,] grayArray = new int[ClientSize.Height, ClientSize.Width];
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            if (UpDown)
            {
                UpDown = true;
                rate = 256.0 / ClientSize.Width;
                band = ClientSize.Width / 8;
                for (y = 0; y < ClientSize.Height; y++)
                {
                    for (x = 0; x < ClientSize.Width; x++)
                    {
                        grayArray[y, x] = (int)((x / band) * band * rate);
                    }
                }
            }
            else
            {
                rate = 256.0 / ClientSize.Height;
                band = ClientSize.Height / 8;
                for (x = 0; x < ClientSize.Width; x++)
                {
                    for (y = 0; y < ClientSize.Height; y++)
                    {
                        grayArray[y, x] = (int)((y / band) * band * rate);
                    }
                }
            }
            for (y = 0; y < ClientSize.Height; y++)
            {
                for (x = 0; x < ClientSize.Width; x++)
                {
                    color = Color.FromArgb(grayArray[y, x], grayArray[y, x], grayArray[y, x]);
                    bitmap.SetPixel(x, y, color);
                }
            }
            graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            graphics.Dispose();
        }
    }
}
