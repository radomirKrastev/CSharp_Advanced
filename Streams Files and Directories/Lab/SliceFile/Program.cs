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
                    
                    using (var writeFile = new FileStream($"Part-{i}.txt", FileMode.Create))
                    {
                        while (true)
                        {
                            var buffer = new Byte[4096];
                            var read = readFile.Read(buffer, 0, buffer.Length);

                            if (read == 0)
                            {
                                break;
                            }

                            if(currentPartSize+read >= partSize)
                            {
                                writeFile.Write(buffer, 0, partSize-currentPartSize);
                                break;
                            }
                            else
                            {
                                writeFile.Write(buffer, 0, buffer.Length);
                                currentPartSize += read;
                            }
                        }
                    }
                }
            }
        }
    }
}
