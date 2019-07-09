using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0708_ReadImage
{
    public partial class Form1 : Form // Form 이라는 것에서 소속됨.
    {
        public Form1()
        {
            // Form1 생성자
            InitializeComponent();
            // Form1.Designer에 있다.
            // 생성될 때 모든 요소들을 초기화한다.
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics tempGraphics = e.Graphics;
            // 이러한 방식으로 Form1 자체에 Graphics를 줄 수 있다.
            // 주의점으로 여기에 MessageBox를 준다면
            // foreground에 있을때 계속 실행되는 것이므로 MessageBox가 없어지지 않는다.
        }
        // Form1이 foreground에 나타날 시 실행되는 이벤트
        private void Button_Open_Click(object sender, EventArgs e)
        {
            Image image;
            String filterName = "All Files(*.*)|*.*|Bitmap File(*.bmp)|*.bmp|";
            filterName = filterName
                + "Gif File(*.gif)|*.gif|Jpeg File(*.jpg)|*.jpg";
            // 파일 확장자 추가. 허용되는 파일 확장자의 형태 지정
            // 즉 filter를 설정하는 것으로 ofdOpen으로 생성되는
            // 파일 탐색기에서의 확장자를 지정하는 것이다.
            Graphics graphics = CreateGraphics();
            // Graphics graphics = this.CreateGraphics(); 동일.
            // CreateGraphics();는 인스턴스 메소드임으로 this.으로 불러올 수 있다.
            // System.Drawing의 네임스페이스에 속해있음.
            // 3가지의 방식으로 Graphics을 선언하는 하나의 방식이다.
            ofdOpen.Title = "Open File";
            ofdOpen.Filter = filterName;
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                // ofdOpen에서 생성된 Dialog가 정상적으로
                // 필터를 거치어 리턴이 오는경우. 즉 선택을 했을 경우
                string strFileName = ofdOpen.FileName;
                // 리턴된 파일의 경로 반환
                image = Image.FromFile(strFileName);
                // 해당 경로에 있는 이미지 객체 생성
                // FromFile은 클래스 메소드임으로 클래스에서 직접 호출해야 한다.
                graphics.DrawImage(image, 10, 100, image.Width, image.Height);
                // (이미지, x좌표, y좌표, 이미지 넓이, 이미지 높이)
            }
            graphics.Dispose();
            // Grapics 객체 해제
        }        
    }
}