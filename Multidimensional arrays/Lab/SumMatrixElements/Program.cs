using System;
using System.Linq;

namespace SumMatrixElements
{
    public class Program
    {
        public static void Main()
        {
            var data = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = data[0];
            var cols = data[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            var sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
