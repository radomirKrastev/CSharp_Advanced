using System;
using System.IO;

namespace MergeFiles
{
    public class Program
    {
        public static void Main()
        {
            using(var readerOne = new StreamReader("FileOne.txt"))
            {
                var lineFirstFile = readerOne.ReadLine();

                using (var readerTwo = new StreamReader("FileTwo.txt"))
                {
                    using (var writer = new StreamWriter("Output.txt"))
                    {
                        var lineSecondFile = readerTwo.ReadLine();

                        while (true)
                        {
                            if(lineFirstFile == null && lineSecondFile == null)
                            {
                                break;
                            }

                            if (lineFirstFile != null)
                            {
                                writer.WriteLine(lineFirstFile);
                                lineFirstFile = readerOne.ReadLine();
                            }
                            if (lineSecondFile != null)
                            {
                                writer.WriteLine(lineSecondFile);
                                lineSecondFile = readerTwo.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
