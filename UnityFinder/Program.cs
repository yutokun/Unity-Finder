using System;
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

            var unity = args[0];
            Console.Write($"Finding Unity {unity} ... ");

            var process = new Process { StartInfo = startInfo };
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var result = output.Contains(unity);

            Console.WriteLine($"is{(result ? " " : " NOT ")}installed.");

            return result ? 0 : 1;
        }
    }
}
