using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.WPF;

namespace OzOpenCVTesterWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Capture _capture = null;
        private bool _captureInProgress;
        private bool _inProcessing = false;

        public MainWindow()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            try
            {
                _capture = new Capture();
                _capture.ImageGrabbed += ProcessFrame;
                OnClick캡춰시작(null, null);
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (!_captureInProgress) return;
            _inProcessing = true;
            Mat frame = new Mat();
            _capture.Retrieve(frame, 0);
            사람찾기(frame);
            //흑백변환(frame);
            //얼굴찾기(frame);
            _inProcessing = false;
        }

        void 흑백변환(Mat image)
        {
            Mat grayFrame = new Mat();
            CvInvoke.CvtColor(image, grayFrame, ColorConversion.Bgr2Gray);
            Mat smallGrayFrame = new Mat();
            CvInvoke.PyrDown(grayFrame, smallGrayFrame);
            Mat smoothedGrayFrame = new Mat();
            CvInvoke.PyrUp(smallGrayFrame, smoothedGrayFrame);

            //Image<Gray, Byte> smallGrayFrame = grayFrame.PyrDown();
            //Image<Gray, Byte> smoothedGrayFrame = smallGrayFrame.PyrUp();
            Mat cannyFrame = new Mat();
            CvInvoke.Canny(smoothedGrayFrame, cannyFrame, 100, 60);

            //Image<Gray, Byte> cannyFrame = smoothedGrayFrame.Canny(100, 60);

            Application.Current.Dispatcher.Invoke(() =>
            {
                BitmapSource bitmap1 = BitmapSourceConvert.ToBitmapSource(cannyFrame);
                img.Source = bitmap1;
            });
            //grayscaleImageBox.Image = grayFrame;
            //smoothedGrayscaleImageBox.Image = smoothedGrayFrame;
            //cannyImageBox.Image = cannyFrame;
        }

        private void 사람찾기(Mat image)
        {
            bool tryUseCuda = true;
            long processingTime;
            var results = FindPedestrian.Find(image, tryUseCuda, out processingTime);
            foreach (var rect in results)
            {
               CvInvoke.Rectangle(image, rect, new Bgr(System.Drawing.Color.Red).MCvScalar);
            }
            Application.Current.Dispatcher.Invoke(() =>
            {
                BitmapSource bitmap1 = BitmapSourceConvert.ToBitmapSource(image);
                img.Source = bitmap1;
            });
        }

        void 얼굴찾기(Mat image)
        {
            long detectionTime;
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            //The cuda cascade classifier doesn't seem to be able to load "haarcascade_frontalface_default.xml" file in this release
            //disabling CUDA module for now
            bool tryUseCuda = false;

            DetectFace.Detect(
              image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
              faces, eyes,
              tryUseCuda,
              out detectionTime);

            Application.Current.Dispatcher.Invoke(() =>
            {
                후보리스트.Children.Clear();
            });
            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image, face, new Bgr(Color.Red).MCvScalar, 2);
                Mat faceimg = new Mat(image, face);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    System.Windows.Controls.Image ptr = new System.Windows.Controls.Image();
                    ptr.Source = BitmapSourceConvert.ToBitmapSource(faceimg);
                    ptr.Width = 128;
                    ptr.Height = 128;
                    후보리스트.Children.Add(ptr);
                });
            }
            foreach (Rectangle eye in eyes)
                CvInvoke.Rectangle(image, eye, new Bgr(Color.Blue).MCvScalar, 2);

            Application.Current.Dispatcher.Invoke(() =>
            {
                img.Source = BitmapSourceConvert.ToBitmapSource(image);
            });
        }

        private void OnClick캡춰시작(object sender, RoutedEventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    _capture.Pause();
                }
                else
                {
                    _capture.Start();
                }

                _captureInProgress = !_captureInProgress;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_capture != null)
            {
                StopCapture();
                if(_inProcessing)
                {
                    e.Cancel = true;

                    System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(10);
                    timer.Tick += new EventHandler((o, evt) => {
                        Close();
                    });
                    timer.Start();
                }
            }
        }

        void StopCapture()
        {
            _capture.ImageGrabbed -= ProcessFrame;
            if(_captureInProgress)
                _capture.Pause();
            _captureInProgress = false;
            _capture.Dispose();
        }

        private void OnClick동영상열기(object sender, RoutedEventArgs e)
        {
            string filepath = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".avi";
            dlg.Filter = "video file (*.avi)|*.avi|All Files (*.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                filepath = dlg.FileName;
            }

            if(filepath.Length<=0)
                return;

            try
            {
                StopCapture();
                _capture = new Capture(filepath);
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
                _captureInProgress = true;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }

        }

    }
}
