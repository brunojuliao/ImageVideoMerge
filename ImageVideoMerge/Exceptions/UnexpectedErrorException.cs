using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ImageVideoMerge.Exceptions
{
  [Serializable]
  public class UnexpectedErrorException : Exception
  {
    public UnexpectedErrorException() : base() { }
    public UnexpectedErrorException(string message) : base(message) { }
    public UnexpectedErrorException(string message, Exception ex) : base(message, ex) { }
    protected UnexpectedErrorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }
}
