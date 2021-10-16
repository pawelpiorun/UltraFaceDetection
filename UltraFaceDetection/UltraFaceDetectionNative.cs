using System;
using System.Runtime.InteropServices;

namespace UltraFaceDetection
{
    public static class UltraFaceDetectionNative
    {

        [DllImport("UltraFaceDetectionNative.dll", EntryPoint = "UltraFace_Create")]
        internal extern static IntPtr Create();

        [DllImport("UltraFaceDetectionNative.dll", EntryPoint = "UltraFace_CreateTh")]
        internal extern static IntPtr Create(float threshold);

        [DllImport("UltraFaceDetectionNative.dll", EntryPoint = "UltraFace_Detect")]
        internal extern static int Detect(IntPtr ultraFacePtr, IntPtr imagePtr, FaceInfo[] faceInfos);

        [DllImport("UltraFaceDetectionNative.dll", EntryPoint = "UltraFace_Dispose")]
        internal extern static void Dispose(IntPtr ultraFacePtr);
    }
}
