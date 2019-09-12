using System;
using System.Linq;

namespace PrimaryDiagonal
{
    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            var currentRow = 0;
            var currentCol = 0;
            var sum = 0;

            while(currentRow<size && currentCol < size)
            {
                sum += matrix[currentRow++, currentCol++];
            }

            Console.WriteLine(sum);
        }
    }
}
