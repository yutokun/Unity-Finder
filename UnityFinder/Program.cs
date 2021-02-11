using System.Diagnostics;

namespace UnityFinder
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\Unity Hub\Unity Hub.exe",
                Arguments = "-- --headless editors --installed",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            var process = new Process { StartInfo = startInfo };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            return output.Contains(args[0]) ? 0 : 1;
        }
    }
}
