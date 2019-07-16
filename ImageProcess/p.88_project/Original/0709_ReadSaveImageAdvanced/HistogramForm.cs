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
    public partial class HistogramForm : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        const int HISTO_WIDTH = 256;
        const int HISTO_HEIGHT = 200;        
        public HistogramForm(int[,]grayArray,int Width,int Height)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(HISTO_WIDTH, HISTO_HEIGHT);
            setShadowBitmap();
            viewHistogram(0, 0, grayArray, Width, Height);
        }
        void setShadowBitmap()
        {
            // bitmap을 graphics 객체에 등록 및 초기화
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(BackColor);
        }

        private void HistogramForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(bitmap, 0, 0);
        }
        void viewHistogram(int leftTopX,int leftTopY,int[,] histoArray,int Width,int Height)
        {
            int x, y;
            Color color;
            Bitmap histoBitmap = new Bitmap(HISTO_WIDTH, HISTO_HEIGHT);
            int[] histogram = new int[256];
            histogram.Initialize();
            for (y = 0; y < Height; y ++)
            {
                for (x = 0; x < Width; x++)
                {
                    histogram[histoArray[y, x]]++;
                    // 이미지에서 받은 grayArray인 histoArray에서 받은 명도의 값을
                    // 각 명도들의 수를 저장할 histogram의 맞는 위치에 서 ++되도록 한다는 것이다.
                    // 즉 각 픽셀들의 명도값에 해당하는 histogram[명도]에 +1 됨으로서
                    // 저절로 그래프를 형성하는 것이다.
                }
            }
            int max_cnt = 0;
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                if (histogram[x] > max_cnt)
                    max_cnt = histogram[x];
                // histogram의 가장많은 명도를 찾아내는 것이다.
            }
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                for (y = 0; y < HISTO_HEIGHT; y++)
                {
                    color = Color.FromArgb(180, 180, 180);
                    histoBitmap.SetPixel(x, y, color);
                }
            }
            for (x = 0; x < HISTO_WIDTH; x++)
            {
                double dHeight = (double)histogram[x] * (HISTO_HEIGHT - 1) / (double)max_cnt;
                // 위에서 찾은 가장 많은 빈도의 명도의 수를 기준으로 그리기 위하여
                // 해당 계산을 통해 전체적인 값들을 변환하여 아래 loop문에서 출력토록 하는 것이다.                
                for (y = 0; y < (int)dHeight; y++)
                {
                    // 위에서 계산된 값만큼 반복하는 것이니, 전체적으로
                    // 해당 비율만큼 y를 반복하여 그래프를 채우려고 하는 것이다.
                    color = Color.FromArgb(0, 0, 0); // 검은색
                    histoBitmap.SetPixel(x, (HISTO_HEIGHT - 1) - y, color);
                    // 1번째 요소는 배열의 시작 요소의 주소값의 상수값을 가진다.
                    // 즉 변환하지 못하도록 상수로 고정시키는 것이다.
                    // X값은 각 index, 즉 명도들에 대한 값이고 y는 그 명도들의 수를 표현한 것이다.
                    // 그리하여 x값은 고정하고 필요한 만큼 y의 수를 검은 색으로 칠하도록 하는 것이다.
                }
            }
            graphics.DrawImage(histoBitmap, leftTopX, leftTopY);
            // graphics = Graphics.FromImage(bitmap);
            // graphics는 위에서 보는 것과 같이
            // setshadow에서 bitmap과 연결시켰기 때문에 지금까지 진행된 bitmap정보가
            // graphics에 백업이 되어있는 것이다.
            Invalidate();
            // 그렇기에 다시 Paint를 강제적으로 실행시키어
            // graphics에 저장된 bitmap을 그린다.
        }
    }
}
