using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class Program
    {
        public static void Main()
        {
            string startPath = @"start";
            string zipPath = @"result.zip";
            string extractPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\extractFolder";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath,extractPath);
        }
    }
}
