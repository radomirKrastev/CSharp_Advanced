using System;

namespace PascalTriangle
{
    public class Program
    {
        public static void Main()
        {
            var size = long.Parse(Console.ReadLine());
            var pascalTriangle = new long[size][];

            pascalTriangle[0] = new long[1] { 1 };

            for (long row = 1; row < size; row++)
            {
                var prev = pascalTriangle[row - 1];
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][pascalTriangle[row].Length-1] = 1;

                for (long i = 1; i < pascalTriangle[row].Length-1; i++)
                {
                    pascalTriangle[row][i] = prev[i - 1] + prev[i];
                }
            }

            foreach (var line in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ",line));
            }
        }
    }
}
