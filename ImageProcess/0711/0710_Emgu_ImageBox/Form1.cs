using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using Emgu.Util;


namespace _0710_Emgu_ImageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string msg = "Cilck right mouse button to act";
            Bgr fwColor = new Bgr(0, 255, 255);
            Point point = new Point(20, 100);

            using (Image<Bgr, Byte> Image = new Image<Bgr, byte>(this.ClientSize))
            {
                MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX_SMALL, 1.0, 1.0);
                Image.Draw(msg, ref font, point, fwColor);
                ImageBox_canvas.Image = Image;
                // ImageBox_canvas.FunctionalMode = ImageBox.FunctionalModeOption.Everything;
                // 기능 모드
            }
        }
    }
}
