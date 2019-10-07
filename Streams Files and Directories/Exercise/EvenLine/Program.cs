using System;
using System.IO;

namespace EvenLines
{
    public class Program
    {
        public static void Main()
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                var lineCounter = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var pattern = @"[-!,.?]";

                    if (lineCounter++ % 2 == 0)
                    {
                        Console.WriteLine(ExtensionMethods.ReplaceAndReverse(line,pattern));
                    }
                }
            }
        }
    }
}
