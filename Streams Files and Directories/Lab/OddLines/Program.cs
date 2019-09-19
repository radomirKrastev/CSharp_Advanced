using System;
using System.IO;

namespace OddLines
{
    public class Program
    {
        public static void Main()
        {
            using (var reader = new StreamReader("input.txt"))
            {
                var counter = 0;
                var line = reader.ReadLine();

                using (var writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        if (counter++ % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        line = reader.ReadLine();
                    }                    
                }                
            }
        }
    }
}
