using System;
using System.IO;

namespace LineNumbers
{
    public class Program
    {
        public static void Main()
        {
            File.Create("output.txt").Close();
            var allLines = File.ReadAllLines("text.txt");

            for (int i = 0; i < allLines.Length; i++)            
            {
                var line = allLines[i];
                var lettersCount = 0;
                var punctuationCount = 0;

                foreach (var c in line)
                {
                    if (Char.IsPunctuation(c))
                    {
                        punctuationCount++;
                    }
                    else if (Char.IsLetter(c))
                    {
                        lettersCount++;
                    }
                }

                allLines[i] = $"Line {i + 1}: {line} ({lettersCount})({punctuationCount})";
            }

            File.AppendAllLines("output.txt",allLines);
        }
    }
}
