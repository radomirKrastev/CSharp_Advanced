using System;
using System.IO;

namespace FolderSize
{
    public class Program
    {
        public static void Main()
        {
            var currentDirectory = Directory.GetCurrentDirectory()+ "\\New folder";
            
            var filesSize = GetFiles(currentDirectory);

            Console.WriteLine(filesSize);
        }

        private static long GetFiles(string directory)
        {
            var totalSize = 0L;
            var subDirectories = Directory.GetDirectories(directory);

            foreach (var subDirectory in subDirectories)
            {
                totalSize+= GetFiles(subDirectory);
            }

            var files = Directory.GetFiles(directory);

            foreach (var file in files)
            {
                totalSize+= new FileInfo(file).Length;
            }

            return totalSize;
        }
    }
}
