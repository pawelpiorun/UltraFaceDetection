using System;
using System.Runtime.InteropServices;

namespace UltraFaceDetection
{
    public static class OpenCV
    {
        [DllImport("UltraFaceDetectionNative.dll", EntryPoint = "Mat_Create")]
        internal extern static IntPtr CreateMat();

        [DllImport("UltraFaceDetectionNative.dll", EntryPoint = "Mat_Decode")]
        internal extern static void DecodeImage(byte[] imageBytes, int length, IntPtr imagePtr);

        [DllImport("UltraFaceDetectionNative.dll", EntryPoint = "Mat_Dispose")]
        internal extern static void DisposeMat(IntPtr imagePtr);
    }
}
