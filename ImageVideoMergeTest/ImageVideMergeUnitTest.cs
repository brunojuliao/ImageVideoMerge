using ImageVideoMerge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ImageVideoMergeTest {
  [TestClass]
  public class ImageVideMergeUnitTest {
    [TestMethod]
    public void TestNullFfmpegPath() {
      try {
        var merger = new ImageVideoMerger(null);
      } catch(ArgumentException) {
      }
    }

    [TestMethod]
    public void TestEmptyFfmpegPath() {
      try {
        var merger = new ImageVideoMerger(null);
      } catch (ArgumentException) {
      }
    }

    [TestMethod]
    public void TestInvalidFfmpegPath() {
      try {
        var merger = new ImageVideoMerger(@"c:\f.exe");
      } catch (ArgumentException) {
      }
    }

    [TestMethod]
    [DeploymentItem("Assets", "Assets")]
    public void TestValid() {
      var currentPath = Directory.GetCurrentDirectory();
      var merger = new ImageVideoMerger(Path.Combine(currentPath, @"Assets\Progs\ffmpeg.exe"));
      var bytes = merger.Merge(
        new VideoDetails(Path.Combine(currentPath, @"Assets\Videos\v1.mp4"), 1280, 720),
        new ImageDetails(Path.Combine(currentPath, @"Assets\Images\d1.png"), 0, 3, 600, 300, 100, 100),
        new ImageDetails(Path.Combine(currentPath, @"Assets\Images\d2.png"), 5, 8, 600, 300, 100, 100)
      );

      Assert.IsTrue(bytes != null && bytes.Length > 0);
      
      var temp = Path.GetTempFileName();
      File.Delete(temp);
      temp = Path.ChangeExtension(temp, ".mp4");

      if (File.Exists(temp))
        File.Delete(temp);

      File.WriteAllBytes(temp, bytes);
      
    }
  }
}
