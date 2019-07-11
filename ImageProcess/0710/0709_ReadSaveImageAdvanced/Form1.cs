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
    /*
        LUT. Look Up Table은 명도의 총량 8비트 즉 256의 경우를 전체를 저장하고 있는 것이다.
        고로 각 index값에 따른 결과값을 가지고 있도록 하는 것인데 예로
        double newValue = index / 127.0 - 1.0;
        newValue = 255.0 * newValue * newValue;
        LUT[index] = (int)newValue;
        이러한 모든 명도 256개에 대한 결과의 수를 모두 계산하여 LUT에 저장한다.
        즉 각 명도(index)에 대한 결과는 LUT[명도]라는 결과가 도출된다.
        고로 프로그래머는 이러한 형태를 
        for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
        이러한 형식으로 LUT를 사용하도록 한다.
        grayArray[y, x] = LUT[grayArray[y, x]];
        위를 해석 하자면, 이미지를 픽셀로 나누고 좌표 (y,x)의  명도가 
        grayArray[y,x]에 저장되었다. 이에 명도 변화를 위하여
        LUT[grayArray[y, x]];
        을 통하여 LUT[이미지좌표(x,y)의 명도]를 LUT에서 찾아내어 grayArray에 대입하는 것이다.
        즉 일일히 계산하는 것이아닌 LUT로 인하여 단순히 찾아서 대입만 하면 되는 프로그램을
        만든것이다. 즉 전체 픽셀 수 만큼 계산하지 않고 처음의 256번만큼만 계산한다면
        이후로는 찾는다는 과정만으로도 변환이 가능해진다는 것이다.
        */
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
        void displayGrayArray(int leftTopX, int leftTopY,int[,] grayA,int Width,int Height)
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
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }

        private void Menu_brightness_subtract_Click(object sender, EventArgs e)
        {
            adjustBright(-35);
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
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
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        private void Menu_contrast_decrease_Click(object sender, EventArgs e)
        {
            adjustContrast(1.0 / 1.4);
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        void inverseByLUT()
        {
            int x, y, index;
            int[] LUT = new int[256];
            for(index = 0; index < 256; index++)
            {
                LUT[index] = 255 - index;
                // 위치 반전을 통한 inverse
            }
            for(y = 0; y < bitmap.Height; y++)
            {
                for(x=0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
        }
        private void Menu_inverse_Click(object sender, EventArgs e)
        {
            inverseByLUT();
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        void adjustGamma(double gamma_Value)
        {
            int x, y, index;
            int[] LUT = new int[256];
            // LUT란 look-up 테이블 처럼 사용하여 픽셀의 조절을 하기 위하여
            // 8bit의 크기로 하여 증감을 원활하게 할 수 있도록 해주는 것이다.
            for(index = 0; index < 256; index++)
            {
                LUT[index] = (int)(255.0 * Math.Pow((double)index / 255.0, 1.0 / gamma_Value));
                // 인덱스 값을 할당하는 과정에서 Pow(역함수)를 통하여
                // 1 이상 증가량은 증가하고 1이하 증가량은 
                // 본래의 양보다 감소하는 형태의 그림이 그려진다.
            }
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
        }
        private void Menu_gamma_larger_Click(object sender, EventArgs e)
        {
            adjustGamma(1.5); // 명도 증가
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        private void Menu_gamma_between_Click(object sender, EventArgs e)
        {
            adjustGamma(0.5); // 명도 감소
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        void adjustContrastAlpha(int alphaValue)
        {
            // alphaValue에 따라 값이 변하는 증감 폭이 늘어나거나 줄어든다.
            int x, y, index, newValue;
            int[] LUT = new int[256];
            for (index = 0; index < 256; index++)
            {
                newValue = (int)(255.0 / (255.0 - 2.0 * alphaValue) * (index - alphaValue));
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
        void adjustContrast()
        {
            // 스무드 함수를 사용한 대비증가 방법.
            // 제한이 걸려있지 않다. 어차피 최대 최소를 벗어나지 못하기 때문이다.
            // 이러한 형식은 adjustContrastAlpha()는 직선형이 가지는 한계를
            // 벗어나 곡선형식의 계산방법으로 개선되었다.
            int x, y, index;
            double newValue;
            int[] LUT = new int[256];
            // 곡선 형태이기 때문에 127을 기준으로 증감이 되는 형식이 다르기에 나눈다.
            for(index = 0; index <= 127; index++)
            {
                LUT[index] = (int)(index * index / 127.0);
                // 127을 기준으로 나뉘어 증감에 차이를 둔다.
            }
            for (index = 128; index <256; index++)
            {
                newValue = index - 255.0;
                newValue = newValue * newValue / 127.0;
                newValue = 255.0 - newValue;
                LUT[index] = (int)newValue;
            }
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
        }
        void adjustContrastDecAlpha(int alphaValue)
        {
            int x, y, index,newValue;
            int[] LUT = new int[256];
            // increaseAlpha와 똑같이 alphaValue를 통하여 증감의 기울기에 차이가 생기는 것이다.
            for (index = 0; index < 256; index++)
            {
                newValue = (int)((255.0 - 2.0 * alphaValue) / 255.0 * index + alphaValue);
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
        // alphaValue가 사용되는 형식은 alphaValue를 통하여 기울기에 차이가 생기고
        // 이를 통하여 각 값에 따라 증감을 두는 것이다.
        private void Menu_contrast_lut_increase_Click(object sender, EventArgs e)
        {
            adjustContrastAlpha(30);
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }

        private void Menu_contrast_lut_increase_smooth_Click(object sender, EventArgs e)
        {
            adjustContrast();
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }

        private void Menu_contrast_lut_decrease_Click(object sender, EventArgs e)
        {
            adjustContrastDecAlpha(50);
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        // 기타 변환. 볼록 파라볼라 변환 함수
        private void Menu_parabola_cap_Click(object sender, EventArgs e)
        {
            int x, y, index;
            int[] LUT = new int[256];
            for(index= 0; index < 256; index++)
            {
                double newValue = index / 127.0 - 1.0;
                newValue = 255.0 * newValue * newValue;
                newValue = 255.0 - newValue;
                // 이것이 cup과의 차이점이다.
                // 약 명도 170을 기준으로 170이하의 것들은 밝아지도록
                // 계산이 된다. 즉 전체적으로 밝아진다.
                if (newValue > 255.0) newValue = 255.0;
                if (newValue < 0) newValue = 0.0;
                LUT[index] = (int)newValue;
            }
            display_LUT(LUT);
        }

        private void Menu_parabola_cup_Click(object sender, EventArgs e)
        {            
            int x, y, index;
            int[] LUT = new int[256];
            for(index = 0; index < 256; index++)
            {
                double newValue = index / 127.0 - 1.0;
                newValue = 255.0 * newValue * newValue;
                // 약 명도 70까지의 명도는 밝아지지만 이후의
                // 70이상의 명도는 전체적으로 어두워 지게 된다.
                if (newValue > 255.0) newValue = 255.0;
                if (newValue < 0.0) newValue = 0.0;
                LUT[index] = (int)newValue;
            }
            display_LUT(LUT);
        }

        void display_LUT(int[] LUT)
        {
            // LUT.Look Up Table을 사용하여 출력하는 경우 사용할 것이다.
            int x, y;
            for (y = 0; y < bitmap.Height; y++)
            {
                for (x = 0; x < bitmap.Width; x++)
                {
                    grayArray[y, x] = LUT[grayArray[y, x]];
                }
            }
            displayGrayArray(0, 0, grayArray, bitmap.Width, bitmap.Height);
        }
        HistogramForm histogram;
        private void Menu_histogram_Click(object sender, EventArgs e)
        {
            
        }
        /*
LUT. Look Up Table은 명도의 총량 8비트 즉 256의 경우를 전체를 저장하고 있는 것이다.
고로 각 index값에 따른 결과값을 가지고 있도록 하는 것인데 예로
double newValue = index / 127.0 - 1.0;
newValue = 255.0 * newValue * newValue;
LUT[index] = (int)newValue;
이러한 모든 명도 256개에 대한 결과의 수를 모두 계산하여 LUT에 저장한다.
즉 각 명도(index)에 대한 결과는 LUT[명도]라는 결과가 도출된다.
고로 프로그래머는 이러한 형태를 
for (y = 0; y < bitmap.Height; y++)
   {
       for (x = 0; x < bitmap.Width; x++)
       {
           grayArray[y, x] = LUT[grayArray[y, x]];
       }
   }
이러한 형식으로 LUT를 사용하도록 한다.
grayArray[y, x] = LUT[grayArray[y, x]];
위를 해석 하자면, 이미지를 픽셀로 나누고 좌표 (y,x)의  명도가 
grayArray[y,x]에 저장되었다. 이에 명도 변화를 위하여
LUT[grayArray[y, x]];
을 통하여 LUT[이미지좌표(x,y)의 명도]를 LUT에서 찾아내어 grayArray에 대입하는 것이다.
즉 일일히 계산하는 것이아닌 LUT로 인하여 단순히 찾아서 대입만 하면 되는 프로그램을
만든것이다. 즉 전체 픽셀 수 만큼 계산하지 않고 처음의 256번만큼만 계산한다면
이후로는 찾는다는 과정만으로도 변환이 가능해진다는 것이다.
*/
    }
}
