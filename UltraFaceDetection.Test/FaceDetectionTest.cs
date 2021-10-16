using FluentAssertions;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace UltraFaceDetection.Test
{
    [CollectionDefinition("FaceDetectionTesT", DisableParallelization = true)]
    public class FaceDetectionTest
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void AnyFacesAreDetected(string path)
        {
            var faces = new UltraFaceDetector().DetectFaces(path);
            faces.Should().NotBeEmpty();
        }

        public static IEnumerable<object[]> GetTestData()
        {
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (!dir.Name.Equals("UltraFaceDetection"))
                dir = dir.Parent;

            var imgsDir = Path.Combine(dir.FullName, "sampleimg");
            var files = Directory.EnumerateFiles(imgsDir);
            foreach (var file in files)
                yield return new object[] { file };
        }
    }
}
