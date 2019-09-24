using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                matrix[row] = line;
            }

            for (int row = 0; row < rows-1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row]= matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1]=matrix[row+1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            var command = Console.ReadLine().Split(" ");            

            while (command[0] != "End")
            {
                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);
                var value = int.Parse(command[3]);
                
                if ((row >= 0 && col >= 0) && (row < rows && col < matrix[row].Length))
                {
                    if (command[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        matrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine().Split(" ");
            }

            foreach (var subArray in matrix)
            {
                Console.WriteLine(string.Join(" ", subArray));
            }
        }
    }
}
