using System;
using System.Diagnostics;

namespace ImageVideoMerge
{
    public static class Helper
    {
      /// <summary>
      /// Static method to run programs through command. It supports arguments and also return strings if needed.
      /// </summary>
      /// <param name="command">Full path to the aplication to be run</param>
      /// <param name="args">Single string to be sent as arguments on application run</param>
      /// <param name="returnString">Optional Boolean to know whether text from console should be returned or not. False is default.</param>
      /// <returns></returns>
      public static string Cmd(string command, string args, bool returnString = false)
      {
        try
        {
          var process = new Process()
          {
            StartInfo = new ProcessStartInfo
            {
              FileName = command,
              Arguments = args,
              RedirectStandardOutput = true,
              UseShellExecute = false,
              CreateNoWindow = true,
            }
          };
          process.Start();
          var result = string.Empty;
          if (returnString)
            result = process.StandardOutput.ReadToEnd();
          else
            while (!process.StandardOutput.EndOfStream)
              Console.Write((char)process.StandardOutput.Read());
          process.WaitForExit();

          return result;
        }
        catch (Exception ex)
        {
          throw new Exception($"Unexpected error: {ex.Message}", ex);
        }
      }
  }
}
