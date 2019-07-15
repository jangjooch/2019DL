using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorBrightBy3Array
{
    public partial class Form1 : Form
    {
        Image image;

        public Form1()
        {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            Graphics gr = CreateGraphics();
            string filterName = "All Files(*.*)|*.*|Bitmap File(*.bmp)|*.bmp|";
            filterName = filterName + "Gif Fle(*.gif)|*.gif|Jpeg File(*.jpg)|*.jpg";
            ofdOpen.Title = "RGB 컬러영상 파일 열기";
            ofdOpen.Filter = filterName;
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                string strFilename = ofdOpen.FileName;
                image = Image.FromFile(strFilename);
                gr.DrawImage(image, 10, 50, image.Width, image.Height);
            }
            gr.Dispose();
        }

        private void btColorBright3_Click(object sender, EventArgs e)
        {
            int x, y, z;
            const int ADD_VALUE = 50;
            Color color;
            int[,,] colorArray =
                new int[3, image.Height, image.Width];
            Graphics gr = CreateGraphics();
            Bitmap gBitmap = new Bitmap(image);

             // Z의 역할은 각각 RGB값을 뜻하는 것이다. 
            for (y = 0; y < image.Height; y++)
                for (x = 0; x < image.Width; x++)
                {
                    color = gBitmap.GetPixel(x, y);
                    colorArray[0, y, x] = color.R;
                    colorArray[1, y, x] = color.G;
                    colorArray[2, y, x] = color.B;
                }
            for(z =0; z <3; ++z)
                for (y = 0; y < image.Height; y++)
                    for (x = 0; x < image.Width; x++)
                    {
                        colorArray[z, y, x] += ADD_VALUE ;
                        if(colorArray[z, y, x] > 255)
                            colorArray[z, y, x] = 255;
                    }
            // 태두리의 RGB값을 127로 만들어 버린다.
            for (z = 0; z < 3; ++z)
                for (y = 0; y < 10; y++)
                    for (x = 0; x < image.Width; x++)
                    {
                        colorArray[z, y, x] = 127 ;
                        colorArray[z, image.Height-1-y, x] = 127;
                    }

            for (x = 0; x < 10 ; x++)
                for (y = 0; y < image.Height ; y++)
                    for (z = 0; z < 3; ++z)                        
                    {
                        colorArray[z, y, x] = 127;
                        colorArray[z, y, image.Width-1-x] = 127;
                    }
            for (y = 0; y < image.Height; y++)
                for (x = 0; x < image.Width; x++)
                {
                    color = Color.FromArgb(
                        colorArray[0, y, x],  // R
                        colorArray[1, y, x],  // G
                        colorArray[2, y, x]); // B
                    gBitmap.SetPixel(x, y, color);
                    // 증가된 값들을 대입.
                }

            gr.DrawImage(gBitmap, 20 + gBitmap.Width, 50,
                gBitmap.Width, gBitmap.Height);
            gr.Dispose();
        }
    }
}
