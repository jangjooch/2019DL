using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0708_PaintEventEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            string msg = "Drawing Rectangle";
            Pen BlackPen = new Pen(Color.Black, 2.0f);
            // graphics를 통해 그릴 것의 윤곽선. 색깔, 선 굵기
            Point p1 = new Point(70, 80);
            Point p2 = new Point(220, 180);
            Size size1 = new Size(150, 100);
            Font font = new Font(msg, 20, FontStyle.Bold);
            // string을 출력하기 위하여 폰트 내용, 크기, 폰트스타일(option)을 사용하여 생성
            graphics.DrawString(msg, font, Brushes.Black, 70, 30);
            // 폰트에 기본형 폰드 Font(크기 10)도 줄 수 잇다.
            Rectangle rectangle = new Rectangle(p1, size1);
            // Rectangle 객체는 원과 사각형을 그릴 때, 사용될 수 있다.
            graphics.DrawRectangle(BlackPen, rectangle);
            graphics.DrawEllipse(BlackPen, rectangle);
            graphics.DrawLine(BlackPen, p1, p2);            
            graphics.Dispose();
            
        }
    }
}
