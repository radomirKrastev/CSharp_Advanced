using System;
using System.Linq;
using System.Collections.Generic;

namespace SnakeMoves
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
            var matrix = new char[rows, cols];
            var input = Console.ReadLine();
            var snake = new Queue<char>();

            foreach (var ch in input)
            {
                snake.Enqueue(ch);
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = snake.Dequeue();
                    snake.Enqueue(matrix[row, col]);
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);                      
                }

                Console.WriteLine();
            }
        }
    }
}
