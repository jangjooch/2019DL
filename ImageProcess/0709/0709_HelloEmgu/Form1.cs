using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Emgu 추가
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using Emgu.Util;


namespace _0709_HelloEmgu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_hello_Click(object sender, EventArgs e)
        {
            string formName = "EmguCV testing";
            string msg = "Hello EmguCV";
            Bgr bgColor = new Bgr(255, 255, 255);
            Bgr fwColor = new Bgr(255, 0, 0);
            Point point = new Point(20, 100);
            CvInvoke.cvNamedWindow(formName);
            using (Image<Bgr,Byte> img = new Image<Bgr, Byte>(400, 200, bgColor))
            {
                MCvFont f = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 1.2, 1.2);
                img.Draw(msg, ref f, point, fwColor);
                CvInvoke.cvShowImage(formName, img.Ptr);
                CvInvoke.cvWaitKey(0);
            }
            CvInvoke.cvDestroyWindow(formName);
        }
    }
}
