using System;
using System.Linq;

namespace DiagonalDifference
{
    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];

            var rows = size;
            var cols = size;

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            var primaryDiagonalSum = 0;
            for (int i = 0; i < size; i++)
            {
                primaryDiagonalSum += matrix[i, i];
            }

            var secondaryDiagonalSum = 0;
            var secondaryDiagonalCol = size - 1;
            for (int row = 0; row < size; row++)
            {
                secondaryDiagonalSum += matrix[row, secondaryDiagonalCol--];
            }

            var difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(difference);
        }
    }
}
