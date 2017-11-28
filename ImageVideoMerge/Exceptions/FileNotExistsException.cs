using System;
using System.Runtime.Serialization;

namespace ImageVideoMerge.Exceptions {
  [Serializable]
  public class FileNotExistsException : Exception
  {
    public FileNotExistsException(string fileName) : base($"File \"{fileName}\" could not be accessed") { }
    public FileNotExistsException(string fileName, string message) : base($"File \"{fileName}\" could not be accessed. {message}") { }
    protected FileNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
