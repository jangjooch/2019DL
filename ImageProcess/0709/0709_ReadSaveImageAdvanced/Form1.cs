using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0709_ReadSaveImageAdvanced
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Boolean UpDown;
        Image image;
        int[,] grayArray;
        public Form1()
        {
            InitializeComponent();
            setShadowBitmap();
        }
        void setShadowBitmap()
        {
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            graphics = Graphics.FromImage(bitmap);
            // bitmap을 기준으로 Graphics 객체 생성.
            // 즉 Form에 graphics가 생성되는 것이 아닌
            // bitmap에 할당되어 백업된다. 즉 실행하면
            // 우리가 보기에는 Form에 그려지는 것과 똑같지만
            // 실상은 graphics에서 bitmap자체를 바로 그리는 것이다.
            graphics.Clear(BackColor);
            // 폼 생성시 화면을 초기화함.
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String filterName = "All Files(*.*)|*.*|Bitmap File(*.bmp)|*.bmp|";
            filterName = filterName
                + "Gif File(*.gif)|*.gif|Jpeg File(*.jpg)|*.jpg";
            ofdOpen.Title = "Open File";
            ofdOpen.Filter = filterName;
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                string strFilename = ofdOpen.FileName;
                image = Image.FromFile(strFilename);
                this.ClientSize = new System.Drawing.Size(image.Width, image.Height);
                setShadowBitmap();
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                copyBitmap2Array();
            }
            Invalidate();
            // Invalidate는 Paint이벤트를 강제하는 것이다.
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdSave.Title = "Save Image";
            sfdSave.OverwritePrompt = true;
            String filterName = "All Files(*.*)|*.*|Bitmap File(*.bmp)|*.bmp|";
            filterName = filterName
                + "Gif File(*.gif)|*.gif|Jpeg File(*.jpg)|*.jpg";
            sfdSave.Filter = filterName;
            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                string strFileName = sfdSave.FileName.ToLower();
                bitmap.Save(strFileName);
            }
        }

        private void ToGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x, y, brightness;
            Color color, gray;
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
            image = bitmap;
            setShadowBitmap();
            graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            Invalidate();

            // Graphics gr = CreateGraphics();
            // gr.DrawImage(bitmap, 0, 0);
            // 이 방법은 Form1_Paint의 이벤트를 참고하여 한것이다,
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(bitmap, 0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                if (menuStrip1.Visible)
                {
                    menuStrip1.Visible = false;
                }
                else
                {
                    menuStrip1.Visible = true;
                }
            }
        }
        void copyBitmap2Array()
        {
            int x, y, brightness;
            Color color;
            grayArray = new int[bitmap.Height, bitmap.Width];
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    color = bitmap.GetPixel(x, y);
                    brightness = color.R;
                    grayArray[y, x] = brightness;
                }                
            }
        }
        void displayDrayArray(int leftTopX, int leftTopY,int[,] grayA,int Width,int Height)
        {
            int x, y;
            Color color;
            Bitmap gBitmap = new Bitmap(Width, Height);
            for (y = 0; y < Height; y++)
            {
                for (x = 0; x < Width; x++)
                {
                    color = Color.FromArgb(grayA[y, x], grayA[y, x], grayA[y, x]);
                    gBitmap.SetPixel(x, y, color);
                }
            }
            graphics.DrawImage(gBitmap, leftTopX, leftTopY, gBitmap.Width, gBitmap.Height);
            Invalidate();
        }
        void adjustBright(int brightValue)
        {
            // 2번째 방법. 계산량이 적어 1번째보다 유용하다.
            int x, y, index, newValue;
            int[] LUT = new int[256];
            for (index = 0; index < 256; index++)
            {
                newValue = index + brightValue;
                if (newValue > 255) newValue = 255;
                if (newValue < 0) newValue = 0;
                LUT[index] = newValue;
            }
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }                                    
            }
        }
        // 1번째 방법
        /*void adjustBright(int brightValue)
        {
            // 명도 조절
            int x, y;
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = grayArray[y, x] + brightValue;
                    if (grayArray[y, x] > 255) grayArray[y, x] = 255;
                    if (grayArray[y, x] < 0) grayArray[y, x] = 0;
                }
            }
        }*/
        private void Menu_brightness_add_Click(object sender, EventArgs e)
        {
            adjustBright(35);
            displayDrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }

        private void Menu_brightness_subtract_Click(object sender, EventArgs e)
        {
            adjustBright(-35);
            displayDrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        void adjustContrast(double contrastValue)
        {
            // 대비 조절
            int x, y;
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = (int)(grayArray[y, x] * contrastValue);
                    if (grayArray[y, x] > 255) grayArray[y, x] = 255;
                    // 1.4의 경우 어두운 부분은 더욱 어둡게, 밝은 부분은 더욱 밝도록 바꾸는 것이다.
                }
            }
        }
        private void Menu_contrast_increase_Click(object sender, EventArgs e)
        {
            adjustContrast(1.4);
            displayDrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        private void Menu_contrast_decrease_Click(object sender, EventArgs e)
        {
            adjustContrast(1.0 / 1.4);
            displayDrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
    }
}
