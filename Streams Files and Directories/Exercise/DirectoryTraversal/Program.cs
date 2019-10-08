using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    public class Program
    {
        public static void Main()
        {
            var files = new Dictionary<string,List<FileData>>();
            var directoryFiles= Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach (var file in directoryFiles)
            {
                
                var extension = new FileInfo(file).Extension;
                if (!files.ContainsKey(extension))
                {
                    files.Add(extension, new List<FileData>());
                }

                var name = new FileInfo(file).Name;
                var size = new FileInfo(file).Length;
                files[extension].Add(new FileData(name, size));
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.CreateText(path+@"\\report.txt").Close();

            using (StreamWriter writer = new StreamWriter(path+"\\report.txt"))
            {
                foreach (var extension in files.OrderByDescending(x => x.Value.Count()).ThenBy(x => x.Key))
                {
                    writer.WriteLine(extension.Key);

                    foreach (var file in extension.Value.OrderByDescending(x => x.Size))
                    {
                        writer.WriteLine($"--{file.Name} - {file.Size / 1000:F3}kb");
                    }
                }
            }            
        }
    }
}
