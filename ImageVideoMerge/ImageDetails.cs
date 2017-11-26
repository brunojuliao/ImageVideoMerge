namespace ImageVideoMerge {
  public class ImageDetails {
    public ImageDetails(string path, int startSecond, int endSecond, int width, int height, int x, int y) {
      this.Path = path;
      this.StartSecond = startSecond;
      this.EndSecond = endSecond;
      this.Width = width;
      this.Height = height;
      this.X = x;
      this.Y = y;
    }

    public string Path { get; set; }
    public int StartSecond { get; set; }
    public int EndSecond { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
  }
}
