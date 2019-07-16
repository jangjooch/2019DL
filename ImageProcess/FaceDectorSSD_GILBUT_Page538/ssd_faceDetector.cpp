#include "opencv2/opencv.hpp"
#include <iostream>

using namespace cv;
using namespace cv::dnn;
using namespace std;

//Caffe 프레임워크에서 학습한 경우
const String model = "res10_300x300_ssd_iter_140000_fp16.caffemodel";
const String config = "deploy.prototxt";

//TensorFlow 프레임워크에서 학습한 경우
//const String model = "opencv_face_detector_uint8.pb";
//const String config = "opencv_face_detector.pbtxt";

int main(void)
{
	//컴퓨터에 연결된 기본 카메라 장치를 열어서 cap에 저장
	VideoCapture cap(0);

	//카메라 열기에 실패하면 에러메시지 출력하고 실행 종료함.
	if (!cap.isOpened()) {
		cerr << "Camera open failed!" << endl;
		return -1;
	}
	//모델 파일과 구성 파일을 이용하여 Net 객체 net 을 생성.
	Net net = readNet(model, config);

	if (net.empty()) {
		cerr << "Net open failed!" << endl;
		return -1;
	}

	Mat frame;
	while (true) {
		cap >> frame;//카메라의 매 프레임을 frame 변수에 저장함.
		if (frame.empty())
			break;
		//frame 영상을 이용하여 네크워크 입력 블롭을 설정
		Mat blob = blobFromImage(frame, 1, Size(300, 300), Scalar(104, 177, 123));
		net.setInput(blob);
		//네크워크 실행 결과를 res 행렬에 저장합니다.
		Mat res = net.forward();

		Mat detect(res.size[2], res.size[3], CV_32FC1, res.ptr<float>());

		for (int i = 0; i < detect.rows; i++) {
			float confidence = detect.at<float>(i, 2);
			if (confidence < 0.5)
				break;

			int x1 = cvRound(detect.at<float>(i, 3) * frame.cols);
			int y1 = cvRound(detect.at<float>(i, 4) * frame.rows);
			int x2 = cvRound(detect.at<float>(i, 5) * frame.cols);
			int y2 = cvRound(detect.at<float>(i, 6) * frame.rows);

			rectangle(frame, Rect(Point(x1, y1), Point(x2, y2)), Scalar(0, 255, 0));

			String label = format("Face: %4.3f", confidence);
			putText(frame, label, Point(x1, y1 - 1), FONT_HERSHEY_SIMPLEX, 0.8, Scalar(0, 255, 0));
		}

		imshow("frame", frame);
		if (waitKey(1) == 27)
			break;
	}

	return 0;
}
