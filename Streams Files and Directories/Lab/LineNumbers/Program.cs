using System;
using System.IO;

namespace LineNumbers
{
    public class Program
    {
        public static void Main()
        {
            using(var reader = new StreamReader(@"02. Line Numbers\input.txt"))
            {
                using(var writer = new StreamWriter("output.txt"))
                {
                    var line = reader.ReadLine();
                    var currentLine = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"{currentLine++}. {line}");
                        line = reader.ReadLine();
                    }                    
                }
            } 
        }
    }
}
