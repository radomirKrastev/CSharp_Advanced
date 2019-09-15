using System;
using System.Linq;
using System.Collections.Generic;

namespace RadioactiveMutantVampireBunnie
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
            var bunniesLair = new string[rows, cols];

            var currentRow = 0;
            var currentCol = 0;

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    bunniesLair[row, col] = currentLine[col].ToString();
                    if (bunniesLair[row, col] == "P")
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            var commands = Console.ReadLine();
            var moves = new Queue<char>(commands);

            foreach (var move in commands)
            {
                moves.Enqueue(move);
            }

            var playerWon = false;
            var playerDied = false;

            while (playerWon == false && playerDied == false)
            {
                var destination = moves.Dequeue();
                playerWon = MovePlayer(currentRow, currentCol, rows, cols, playerWon, destination);

                bunniesLair[currentRow, currentCol] = ".";
                if (!playerWon)
                {
                    switch (destination)
                    {
                        case 'L':
                            currentCol -= 1;
                            break;
                        case 'R':
                            currentCol += 1;
                            break;
                        case 'U':
                            currentRow -= 1;
                            break;
                        case 'D':
                            currentRow += 1;
                            break;
                    }

                    if (bunniesLair[currentRow, currentCol] != "B")
                    {
                        bunniesLair[currentRow, currentCol] = "P";
                    }
                    else
                    {
                        playerDied = true;
                    }
                }


                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (bunniesLair[row, col] == "B")
                        {
                            playerDied = MultiplyBunnies(row, col, rows, cols, playerDied, bunniesLair);
                        }
                    }
                }

                TurnTempBunniesToPerm(rows, cols, bunniesLair);

                if (playerWon)
                {
                    PrintLair(rows, cols, bunniesLair);
                    Console.WriteLine($"won: {currentRow} {currentCol}");
                    return;
                }
                if (playerDied)
                {
                    PrintLair(rows, cols, bunniesLair);
                    Console.WriteLine($"dead: {currentRow} {currentCol}");
                    return;
                }
            }
        }

        private static void TurnTempBunniesToPerm(int rows, int cols, string[,] lair)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lair[row, col] == "T")
                    {
                        lair[row, col] = "B";
                    }
                }
            }
        }

        private static void PrintLair(int rows, int cols, string[,] lair)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool MultiplyBunnies(int row, int col, int rows, int cols, bool playerDied, string[,] bunniesLair)
        {
            //check left
            if (IsCellInLair(row, col - 1, rows, cols))
            {
                if (bunniesLair[row, col - 1] == "P")
                {
                    bunniesLair[row, col - 1] = "T";
                    playerDied = true;
                }
                else if(bunniesLair[row, col - 1] != "B")
                {
                    bunniesLair[row, col - 1] = "T";
                }                
            }
            //check right
            if (IsCellInLair(row, col + 1, rows, cols))
            {
                if (bunniesLair[row, col + 1] == "P")
                {
                    bunniesLair[row, col + 1] = "T";
                    playerDied = true;
                }
                else if (bunniesLair[row, col + 1] != "B")
                {
                    bunniesLair[row, col + 1] = "T";
                }
            }
            //check up
            if (IsCellInLair(row - 1, col, rows, cols))
            {
                if (bunniesLair[row - 1, col] == "P")
                {
                    bunniesLair[row - 1, col] = "T";
                    playerDied = true;
                }
                else if (bunniesLair[row-1, col] != "B")
                {
                    bunniesLair[row-1, col] = "T";
                }
            }
            //check down
            if (IsCellInLair(row + 1, col, rows, cols))
            {
                if (bunniesLair[row + 1, col] == "P")
                {
                    bunniesLair[row + 1, col] = "T";
                    playerDied = true;
                }
                else if (bunniesLair[row+1, col] != "B")
                {
                    bunniesLair[row+1, col] = "T";
                }
            }

            return playerDied;
        }

        private static bool MovePlayer(int row, int col, int rows, int cols, bool playerWon, char destination)
        {
            switch (destination)
            {
                case 'L':
                    if (!IsCellInLair(row, col - 1, rows, cols))
                    {
                        playerWon = true;
                    }
                    break;
                case 'R':
                    if (!IsCellInLair(row, col + 1, rows, cols))
                    {
                        playerWon = true;
                    }
                    break;
                case 'U':
                    if (!IsCellInLair(row - 1, col, rows, cols))
                    {
                        playerWon = true;
                    }
                    break;
                case 'D':
                    if (!IsCellInLair(row + 1, col, rows, cols))
                    {
                        playerWon = true;
                    }
                    break;
            }

            return playerWon;
        }

        private static bool IsCellInLair(int row, int col, int rows, int cols)
        {
            var positionOutside = (row >= 0 && col >= 0) && (row < rows && col < cols);
            return positionOutside;
        }
    }
}