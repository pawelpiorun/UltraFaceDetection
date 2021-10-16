#include "UltraFaceDetectionAPI.h"

ULTRAFACE_API cv::Mat* Mat_Create()
{
	return new cv::Mat();
}
ULTRAFACE_API void Mat_Dispose(cv::Mat* image)
{
	delete image;
}
ULTRAFACE_API void Mat_Decode(unsigned char* data, int size, cv::Mat* dst)
{
	std::vector<char> input(data, data + size);
	cv::imdecode(cv::Mat(input), cv::IMREAD_COLOR, dst);
}

ULTRAFACE_API void UltraFace_Dispose(UltraFace* ultraFace)
{
	delete ultraFace;
}
ULTRAFACE_API UltraFace* UltraFace_Create()
{
	return new UltraFace("", 320, 240);
}
ULTRAFACE_API UltraFace* UltraFace_CreateTh(float threshold)
{
	return new UltraFace("", 320, 240, 4, threshold);
}
ULTRAFACE_API int UltraFace_Detect(UltraFace* detector, cv::Mat* image, FaceInfo* faces)
{
	std::vector<FaceInfo> faceList;
	detector->detect(*image, faceList);
	if (faceList.empty()) return 0;

	for (int i = 0; i < faceList.size(); i++)
		faces[i] = faceList[i];

	return faceList.size();
}
 