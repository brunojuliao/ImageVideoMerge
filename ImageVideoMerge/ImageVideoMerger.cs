using ImageVideoMerge.Exceptions;
using System;
using System.IO;

namespace ImageVideoMerge {
  public class ImageVideoMerger {
    private readonly string ffmpegPath;

    public ImageVideoMerger(string ffmpegPath) {

      if (string.IsNullOrEmpty(ffmpegPath) || !File.Exists(ffmpegPath))
        throw new ArgumentException("The path specified for ffmpeg is invalid!");

      this.ffmpegPath = ffmpegPath;
    }

    public byte[] Merge(VideoDetails videoDetails, params ImageDetails[] imageDetailsList) {
      if (videoDetails == null)
        throw new ArgumentException("Invalid videoDetails! It must contains at least one item.");
      if (imageDetailsList == null || imageDetailsList.Length == 0)
        throw new ArgumentException("Invalid imageDetails! It must contains at least one item.");

      var args = new System.Text.StringBuilder($"-i \"{videoDetails.Path}\" ");
      foreach (var imageDetails in imageDetailsList)
        args.Append($"-i \"{imageDetails.Path}\" ");

      args.Append("-filter_complex \"");

      var cont = 0;
      foreach (var imageDetails in imageDetailsList) {
        args.Append($"[{++cont}:v] scale={imageDetails.Width}:{imageDetails.Height} [r{cont}:v];");
      }

      cont = 0;
      var curName = string.Empty;
      foreach (var imageDetails in imageDetailsList) {
        var prevName = cont++ == 0 ? "0:v" : new string((char)(95 + cont), 1);
        curName = new string((char)(96 + cont), 1);
        args.Append($"[{prevName}][r{cont}:v] overlay = {imageDetails.X} / 2:({imageDetails.Y}) / 2:enable = 'between(t,{imageDetails.StartSecond},{imageDetails.EndSecond})' [{curName}];");
      }
      args = new System.Text.StringBuilder(args.ToString().Substring(0, args.Length - $" [{curName}];".Length)); //Removing " [letter];". Otherwise, the ffmpeg will fail.

      var tempOutput = Path.GetTempFileName();
      File.Delete(tempOutput);
      tempOutput = Path.ChangeExtension(tempOutput, ".mp4");

      if (File.Exists(tempOutput))
        File.Delete(tempOutput);

      args.Append($"\" -pix_fmt yuv420p -c:a copy \"{tempOutput}\"");

      Helper.Cmd(this.ffmpegPath, args.ToString());

      if (!File.Exists(tempOutput))
        throw new FileNotExistsException(tempOutput, "The expected temp file was not created. Try to run with command returning data to check what's being sent to command.");

      var result = File.ReadAllBytes(tempOutput);

      File.Delete(tempOutput);

      return result;
    }
  }
}
