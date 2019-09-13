using System;
using System.Linq;

namespace _2x2EqualSquares
{
    public class Program
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            var count = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    bool equals = matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1];

                    if (equals)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
