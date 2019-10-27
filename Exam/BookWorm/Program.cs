using System;

namespace BookWorm
{
    public class Program
    {
        public static void Main()
        {
            var initialString = Console.ReadLine();
            var rows = int.Parse(Console.ReadLine());

            var player = new Player(initialString);

            var cols = rows;
            var matrix = InitializeMatrix(player, rows);

            var command = Console.ReadLine();

            while (command != "end")
            {
                player.Move(matrix,command);

                command = Console.ReadLine();
            }

            Console.WriteLine(player.Message);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                if (row != rows - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        private static char[,] InitializeMatrix(Player player,int size)
        {
            var matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'P')
                    {
                        player.Position[0] = row;
                        player.Position[1] = col;
                    }
                }
            }

            return matrix;
        }
    }
}
