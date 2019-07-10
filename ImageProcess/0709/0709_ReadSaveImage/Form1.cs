using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0709_ReadSaveImage
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Boolean UpDown;
        Image image;
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void MeauItem_open_Click(object sender, EventArgs e)
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
            }
            Invalidate();
            // Invalidate는 Paint이벤트를 강제하는 것이다.
        }
        

        private void MeauItem_save_Click(object sender, EventArgs e)
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
        private void MeauItem_togray_Click(object sender, EventArgs e)
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
            // menuitem_open_click을 참고하여 만든것이다.
            // 즉 Paint이벤트를 강제로 발동시키어 그린다.
            // 고로 밑의 것과 다를 바 없다.

            // Graphics gr = CreateGraphics();
            // gr.DrawImage(bitmap, 0, 0);
            // 이 방법은 Form1_Paint의 이벤트를 참고하여 한것이다,
        }

        private void MeauItem_exit_Click(object sender, EventArgs e)
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
                if (menuStrip_file.Visible)
                {
                    menuStrip_file.Visible = false;
                }
                else
                {
                    menuStrip_file.Visible = true;
                }
            }
        }        
        private void MenuItem_brightness_add_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_brightness_subtract_Click(object sender, EventArgs e)
        {

        }
        private void IncreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void MenuItem_contrast_decrease_Click(object sender, EventArgs e)
        {

        }
    }
}
