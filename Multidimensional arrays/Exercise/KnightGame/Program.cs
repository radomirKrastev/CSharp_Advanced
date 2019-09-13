using System;

namespace KnightGame
{
    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var chess = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    chess[row, col] = currentLine[col];
                }
            }

            var mostAttacks = 0;
            var knightsRemoved = 0;
            var knightRow = 0;
            var knightCol = 0;

            while (true)
            {
                var currentKnightAttack = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {

                        if (chess[row, col] == 'K')
                        {
                            currentKnightAttack = ReturnAttacks(chess, rows, cols, row, col, 0);
                        }

                        if (currentKnightAttack > mostAttacks)
                        {
                            knightRow = row;
                            knightCol = col;
                            mostAttacks = currentKnightAttack;
                        }
                    }
                }

                if (mostAttacks!=0)
                {
                    chess[knightRow, knightCol] = '0';
                    knightsRemoved++;
                    mostAttacks = -1;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        public static int ReturnAttacks
            (char[,] chess, int rows, int cols, int currentRow, int currentCol, int attacks)
        {
            //check up-left
            if (IsInTheBoard(currentRow - 2, currentCol - 1, rows, cols) && chess[currentRow - 2, currentCol - 1] == 'K')
            {
                attacks++;
            }
            //check up-right
            if (IsInTheBoard(currentRow - 2, currentCol + 1, rows, cols) && chess[currentRow - 2, currentCol + 1] == 'K')
            {
                attacks++;
            }
            //check down-right
            if (IsInTheBoard(currentRow + 2, currentCol + 1, rows, cols) && chess[currentRow + 2, currentCol + 1] == 'K')
            {
                attacks++;
            }
            //check down-left
            if (IsInTheBoard(currentRow + 2, currentCol - 1, rows, cols) && chess[currentRow + 2, currentCol - 1] == 'K')
            {
                attacks++;
            }
            //check right-up
            if (IsInTheBoard(currentRow + 1, currentCol + 2, rows, cols) && chess[currentRow + 1, currentCol + 2] == 'K')
            {
                attacks++;
            }
            //check right-down
            if (IsInTheBoard(currentRow - 1, currentCol + 2, rows, cols) && chess[currentRow - 1, currentCol + 2] == 'K')
            {
                attacks++;
            }
            //check left-up
            if (IsInTheBoard(currentRow - 1, currentCol - 2, rows, cols) && chess[currentRow - 1, currentCol - 2] == 'K')
            {
                attacks++;
            }
            //check left-down
            if (IsInTheBoard(currentRow + 1, currentCol - 2, rows, cols) && chess[currentRow + 1, currentCol - 2] == 'K')
            {
                attacks++;
            }
            return attacks;
        }

        private static bool IsInTheBoard(int row, int col, int rows, int cols)
        {
            var isInside = (row >= 0 && col >= 0) && (row < rows && col < cols);
            return isInside;
        }
    }
}
