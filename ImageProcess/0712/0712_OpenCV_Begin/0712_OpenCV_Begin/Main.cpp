
#include <opencv2/highgui.hpp>
// C:\opencv\build\include\opencv\highgui.hpp �̴�.
// imshow�� ���Ǽ��� ����.

using namespace cv;

int main() {

	Mat image(300, 400, CV_8UC1, Scalar(200));
	// CV_8UC1�� C1�� Channel 1�̶�� ���̴�.
	// Scalar(intValue) intValue�� ���� ����� ���� �ٲ��.
	imshow("PLAY VIDEO", image);
	// cv::imshow�̴�.
	// image�� �޾� �����ش�.
	waitKey(0);

	return 0;
}