namespace ImageVideoMerge {
  public class VideoDetails {
    public VideoDetails(string path, int width, int height) {
      this.Path = path;
      this.Width = width;
      this.Height = height;
    }

    public string Path { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
  }
}
