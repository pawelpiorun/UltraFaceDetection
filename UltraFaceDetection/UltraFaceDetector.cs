using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace UltraFaceDetection
{
    public interface IFaceDetector
    {
        IEnumerable<FaceInfo> DetectFaces(string imagePath, Rectangle? roi = null);
        IEnumerable<FaceInfo> DetectFaces(byte[] imageData, Rectangle? roi = null);
    }

    public class UltraFaceDetector
    {
        private static int FaceInfoBufferLength = 50;
        private static float Threshold = 0.6f;

        private IntPtr ultraFacePtr;
        private IntPtr imagePtr;
        private FaceInfo[] faceInfos;

        public UltraFaceDetector()
        {
            ultraFacePtr = UltraFaceDetectionNative.Create(Threshold);
            faceInfos = new FaceInfo[FaceInfoBufferLength];
        }

        public IEnumerable<FaceInfo> DetectFaces(string imagePath, Rectangle? roi = null)
        {
            try
            {
                var bytes = File.ReadAllBytes(imagePath);
                return DetectFaces(bytes, roi);
            }
            catch(Exception x)
            {
                Console.WriteLine(x.Message);
            }
            return null;
        }

        public IEnumerable<FaceInfo> DetectFaces(byte[] imageData, Rectangle? roi = null)
        {
            try
            {
                imagePtr = OpenCV.CreateMat();
                OpenCV.DecodeImage(imageData, imageData.Length, imagePtr);

                var facesCount = UltraFaceDetectionNative.Detect(ultraFacePtr, imagePtr, faceInfos);
                return faceInfos.Select(inf => new FaceInfo() { X1 = inf.X1, X2 = inf.X2, Y1 = inf.Y1, Y2 = inf.Y2, Score = inf.Score })
                    .ToList();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                OpenCV.DisposeMat(imagePtr);
            }
            return null;
        }

        ~UltraFaceDetector()
        {
            UltraFaceDetectionNative.Dispose(ultraFacePtr);
        }
    }
}
