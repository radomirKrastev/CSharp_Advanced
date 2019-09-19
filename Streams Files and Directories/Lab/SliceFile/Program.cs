using System;
using System.IO;

namespace SliceFile
{
    public class Program
    {
        public static void Main()
        {
            var parts = int.Parse(Console.ReadLine());

            using(var readFile = new FileStream("sliceMe.txt",FileMode.Open))
            {
                var partSize = (int)Math.Ceiling((double)readFile.Length / parts);
                
                for (int i = 1; i <= parts; i++)
                {
                    var currentPartSize = 0;

                    using(var createFile = new FileStream($"Part-{i}.txt", FileMode.Create))
                    {
                        var buffer = new Byte[partSize];
                        var read = readFile.Read(buffer, 0, buffer.Length);

                        while (read == buffer.Length)
                        {
                            currentPartSize += buffer.Length;
                            createFile.Write(buffer, 0, Math.Min(buffer.Length,partSize-currentPartSize));
                            if (currentPartSize >= partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
