using System;
using System.Linq;

namespace MatrixShuffling
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
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }

            var command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                if (command.Count() != 5 || command[0]!="swap")
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine().Split();
                    continue;
                }

                var firstRow = int.Parse(command[1]);
                var firstCol = int.Parse(command[2]);
                var secondRow = int.Parse(command[3]);
                var secondCol = int.Parse(command[4]);

                var validRows = (firstRow >= 0 && firstRow < rows) && (secondRow >= 0 && secondRow < rows);
                var validCols = (firstCol >= 0 && firstCol < cols) && (secondCol >= 0 && secondCol < cols);

                if (validRows && validCols)
                {
                    var firstValue = matrix[firstRow, firstCol];
                    var secondValue = matrix[secondRow, secondCol];

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (row == firstRow && col == firstCol)
                            {
                                matrix[row, col] = secondValue;
                            }
                            else if (row == secondRow && col == secondCol)
                            {
                                matrix[row, col] = firstValue;
                            }
                        }
                    }

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row,col]+" ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}