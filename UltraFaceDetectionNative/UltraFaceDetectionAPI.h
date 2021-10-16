#pragma once
#include "cv_dnn_ultraface.h"

#define ULTRAFACE_API __declspec(dllexport)

extern "C"
{
	ULTRAFACE_API cv::Mat* Mat_Create();
	ULTRAFACE_API void Mat_Dispose(cv::Mat* image);
	ULTRAFACE_API void Mat_Decode(unsigned char* data, int size, cv::Mat* dst);
	ULTRAFACE_API UltraFace* UltraFace_Create();
	ULTRAFACE_API void UltraFace_Dispose(UltraFace* ultraFace);
	ULTRAFACE_API UltraFace* UltraFace_CreateTh(float threshold);
	ULTRAFACE_API int UltraFace_Detect(UltraFace* detector, cv::Mat* image, FaceInfo* faces);
}