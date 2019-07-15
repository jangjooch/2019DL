
#include <opencv2/highgui.hpp>
// C:\opencv\build\include\opencv\highgui.hpp 이다.
// imshow등 편의성을 위함.

using namespace cv;

int main() {

	Mat image(300, 400, CV_8UC1, Scalar(200));
	// CV_8UC1의 C1은 Channel 1이라는 것이다.
	// Scalar(intValue) intValue에 따라 배경의 색이 바뀐다.
	imshow("PLAY VIDEO", image);
	// cv::imshow이다.
	// image를 받아 보여준다.
	waitKey(0);

	return 0;
}