using System;
using System.Linq;

namespace Miner
{
    public class Program
    {
        public static void Main()
        {
            var mineSize = int.Parse(Console.ReadLine());
            var rows = mineSize;
            var cols = mineSize;
            var mine = new char[rows, cols];

            var commands = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var totalCoals = 0;
            var currentRow = 0;
            var currentCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    mine[row, col] = currentLine[col];
                    if (mine[row, col] == 'c')
                    {
                        totalCoals++;
                    }
                    if (mine[row, col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            var coalsAquired = 0;
            foreach (var command in commands)
            {
                if (command == "up")
                {
                    if (CheckNextPosition(currentRow - 1, currentCol, mineSize))
                    {
                        currentRow = currentRow - 1;
                        if (mine[currentRow, currentCol] == 'c')
                        {
                            coalsAquired = CollectCoal(currentRow, currentCol, mine, coalsAquired);
                        }
                    }
                }
                else if (command == "down")
                {
                    if (CheckNextPosition(currentRow + 1, currentCol, mineSize))
                    {
                        currentRow = currentRow + 1;
                        if (mine[currentRow, currentCol] == 'c')
                        {
                            coalsAquired = CollectCoal(currentRow, currentCol, mine, coalsAquired);
                        }
                    }
                }
                else if (command == "right")
                {
                    if (CheckNextPosition(currentRow, currentCol + 1, mineSize))
                    {
                        currentCol = currentCol + 1;
                        if (mine[currentRow, currentCol] == 'c')
                        {
                            coalsAquired = CollectCoal(currentRow, currentCol, mine, coalsAquired);
                        }
                    }
                }
                else if (command == "left")
                {
                    if (CheckNextPosition(currentRow, currentCol - 1, mineSize))
                    {
                        currentCol = currentCol - 1;
                        if (mine[currentRow, currentCol] == 'c')
                        {
                            coalsAquired = CollectCoal(currentRow, currentCol, mine, coalsAquired);
                        }
                    }
                }
                
                if (coalsAquired == totalCoals)
                {
                    Console.WriteLine($"You collected all coals! ({ currentRow}, { currentCol})");
                    return;
                }
                else if (mine[currentRow, currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
            }


            Console.WriteLine($"{totalCoals - coalsAquired} coals left. ({currentRow}, {currentCol})");
        }

        private static int CollectCoal(int row, int col, char[,] mine, int coalsAquired)
        {
            coalsAquired++;
            mine[row, col] = '*';
            return coalsAquired;
        }

        private static bool CheckNextPosition(int row, int col, int size)
        {
            var isNextMoveInMine = (row >= 0 && col >= 0) && (row < size && col < size);
            return isNextMoveInMine;
        }
    }
}