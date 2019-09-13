using System;
using System.Linq;

namespace BombTheBasement
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
            var basement = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    basement[row, col] = 0;
                }
            }

            var targetData = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var impactRow = targetData[0];
            var impactCol = targetData[1];
            var radius = targetData[2];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var isPositionInRadius = Math.Pow(row - impactRow, 2) + Math.Pow(col - impactCol, 2) <= Math.Pow(radius, 2);

                    if (isPositionInRadius)
                    {
                        basement[row, col] = 1;
                    }
                }
            }

            MoveItemsDown(basement, rows, cols, 0, 0);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(basement[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void MoveItemsDown(int[,] basement, int rows, int cols, int currentRow, int currentCol)
        {
            if (currentRow == rows - 1)
            {
                return;
            }
            else
            {
                for (int col = currentCol; col < cols; col++)
                {
                    for (int row = currentRow; row < rows - 1; row++)
                    {
                        if (basement[row, col] == 0 && basement[row + 1, col] == 1)
                        {
                            basement[row + 1, col] = 0;
                            basement[row, col] = 1;
                        }

                        MoveItemsDown(basement, rows, cols, row + 1, col);

                        if (basement[row, col] == 0 && basement[row + 1, col] == 1)
                        {
                            basement[row + 1, col] = 0;
                            basement[row, col] = 1;
                        }
                    }                    
                }
            }
        }
    }
}
