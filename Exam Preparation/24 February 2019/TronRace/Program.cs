using System;

namespace TronRace
{
    public class Program
    {
        public static void Main()
        {
            var dimension = int.Parse(Console.ReadLine());
            var rows = dimension;
            var cols = dimension;

            var firstPlayer = new Player('f');
            var secondPlayer = new Player('s');
            var matrix = InitializeMatrix(rows, cols, firstPlayer, secondPlayer);

            while (firstPlayer.IsAlive && secondPlayer.IsAlive)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var firstPlayerCommand = commands[0];
                var secondPlayerCommand = commands[1];

                firstPlayer.Move(matrix, firstPlayerCommand);

                if (firstPlayer.IsAlive == false)
                {
                    break;
                }

                secondPlayer.Move(matrix, secondPlayerCommand);

                if (secondPlayer.IsAlive == false)
                {
                    break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                if (row < rows - 1)
                {
                    Console.WriteLine();
                }                
            }
        }

        private static char[,] InitializeMatrix(int rows, int cols, Player firstPlayer, Player secondPlayer)
        {
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'f')
                    {
                        firstPlayer.Position[0] = row;
                        firstPlayer.Position[1] = col;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        secondPlayer.Position[0] = row;
                        secondPlayer.Position[1] = col;
                    }
                }
            }

            return matrix;
        }
    }
}
