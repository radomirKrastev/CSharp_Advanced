using System;
using System.Linq;

namespace MaximalSum
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
            var matrix = new int[rows, cols];

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

            var biggestSum = int.MinValue;
            var currentRow = 0;
            var currentCol = 0;

            for (int row = 0; row < rows-2; row++)
            {
                for (int col = 0; col < cols-2; col++)
                {
                    var currentSum = 0;

                    for (int r = row; r< row+3; r++)
                    {
                        for (int c = col; c < col+3; c++)
                        {
                            currentSum += matrix[r, c];
                        }
                    }

                    if (currentSum > biggestSum)
                    {
                        currentRow = row;
                        currentCol = col;
                        biggestSum = currentSum;
                    }
                }
            }

            Console.WriteLine("Sum = "+biggestSum);
            for (int r = currentRow; r < currentRow + 3; r++)
            {
                for (int c = currentCol; c < currentCol + 3; c++)
                {
                    Console.Write(matrix[r, c]+" "); 
                }

                Console.WriteLine();
            }
        }
    }
}
