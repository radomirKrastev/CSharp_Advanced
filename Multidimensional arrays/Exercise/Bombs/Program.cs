using System;
using System.Linq;

namespace Bombs
{
    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var field = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = currentLine[col];
                }
            }

            var coordinates = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var bomb in coordinates)
            {
                var bombRow = int.Parse(bomb[0].ToString());
                var bombCol = int.Parse(bomb[2].ToString());

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (row == bombRow && col == bombCol)
                        {
                            var bombPower = field[bombRow, bombCol];

                            if (bombPower > 0)
                            {
                                //check-> up
                                if (CheckPosition(row - 1, col, rows, cols, field))
                                {
                                    field[row - 1, col] -= bombPower;
                                }
                                //check-> up-left-diagonal
                                if (CheckPosition(row - 1, col - 1, rows, cols, field))
                                {
                                    field[row - 1, col - 1] -= bombPower;
                                }
                                //check-> up-right-diagonal
                                if (CheckPosition(row - 1, col + 1, rows, cols, field))
                                {
                                    field[row - 1, col + 1] -= bombPower;
                                }
                                //check-> down
                                if (CheckPosition(row + 1, col, rows, cols, field))
                                {
                                    field[row + 1, col] -= bombPower;
                                }
                                //check-> down-left-diagonal
                                if (CheckPosition(row + 1, col - 1, rows, cols, field))
                                {
                                    field[row + 1, col - 1] -= bombPower;
                                }
                                //check-> down-right-diagonal
                                if (CheckPosition(row + 1, col + 1, rows, cols, field))
                                {
                                    field[row + 1, col + 1] -= bombPower;
                                }
                                //check->left
                                if (CheckPosition(row, col - 1, rows, cols, field))
                                {
                                    field[row, col - 1] -= bombPower;
                                }
                                //check->right
                                if (CheckPosition(row, col + 1, rows, cols, field))
                                {
                                    field[row, col + 1] -= bombPower;
                                }

                                field[bombRow, bombCol] = 0;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            var aliveCellsCount = 0;
            var aliveCellsSum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] > 0)
                    {
                        aliveCellsCount++;
                        aliveCellsSum += field[row, col];
                    }
                }
            }

            Console.WriteLine("Alive cells: "+aliveCellsCount);
            Console.WriteLine("Sum: "+aliveCellsSum);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(field[row,col]+" ");
                }

                Console.WriteLine();
            }

        }

        private static bool CheckPosition(int row, int col, int rows, int cols, int[,]field)
        {
            var isPositionInTheFieldAndAlive = (row >= 0 && col >= 0) && (row < rows && col < cols) && field[row,col]>0;
            return isPositionInTheFieldAndAlive;
        }
    }
}
