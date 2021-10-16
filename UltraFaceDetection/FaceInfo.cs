using System.Runtime.InteropServices;

namespace UltraFaceDetection
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FaceInfo
	{
		public float X1;
		public float Y1;
		public float X2;
		public float Y2;
		public float Score;
	}
}
