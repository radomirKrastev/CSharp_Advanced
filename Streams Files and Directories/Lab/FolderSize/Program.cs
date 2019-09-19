using System;
using System.IO;

namespace FolderSize
{
    public class Program
    {
        public static void Main()
        {
            string [] files = Directory.GetFiles("TestFolder");
            double filesTotalSum = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                filesTotalSum += fileInfo.Length;
            }

            filesTotalSum = filesTotalSum / 1024 / 1024;
            File.WriteAllText("output.txt",filesTotalSum.ToString());
        }
    }
}
