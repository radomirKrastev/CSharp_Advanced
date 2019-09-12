using System;

namespace SymbolInMatrix
{
    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var rows = size;
            var cols = size;
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var chars = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            var symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(matrix[row, col]== symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
