using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0709_ShadowBitmap
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Boolean UpDown;
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
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Paint 이벤트에서는 Graphics 객체가 전달될 수 있으므로 이를
            // 아래와 같은 방법으로 사용할 수 있다.
            // Invalidate()를 통해 실행될 수 있다.
            Graphics gr = e.Graphics;
            gr.DrawImage(bitmap, 0, 0);
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int x, y, band;
            double rate;
            Color color;
            int[,] grayArray = new int[ClientSize.Height, ClientSize.Width];
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            if (UpDown)
            {                
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
            Invalidate();
            // 위 코드가 없으면 Form에 할당된 것이 아닌 Graphics는 출력되지 않는다.
            // 고로 invalidate()를 실행시킴으로서 Form1_Paint의 이벤트를 실행시킨다.
            // 즉 Graphics에 백업된 정보를 이용하여 출력되는 것이다. 
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int x, y, band;
            double rate;
            Color color;
            int[,] grayArray = new int[ClientSize.Height, ClientSize.Width];
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
            graphics.DrawString("Shadow Bitamp (Save : s)", Font, Brushes.LightBlue, 50, 50);
            Invalidate();
            // 위 코드가 없으면 Form에 할당된 것이 아닌 Graphics는 출력되지 않는다.
            // 고로 invalidate()를 실행시킴으로서 Graphics에 백업된 정보를 이용하여
            // 출력되는 것이다.
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                sfdSave.Title = "Save Image";
                sfdSave.OverwritePrompt = true;
                sfdSave.Filter = "Bitmap File(*.bmp)|*.bmp|GIF File(*.gif)|*.gif|JPEG File(*.jpg)|*jpg";
                if (sfdSave.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = sfdSave.FileName;
                    string strLowFileName = sfdSave.FileName.ToLower();
                    bitmap.Save(strLowFileName);
                }
            }
        }

        
    }
}
