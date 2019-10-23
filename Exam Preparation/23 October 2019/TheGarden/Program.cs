using System;
using System.Linq;

namespace TheGarden
{
    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var garden = new char[rows][];

        }
    }

    private static void SetGarden(char[][] garden)
    {
        for (int row = 0; row < garden.GetLength(0); row++)
        {
            var line = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
        }
    }
}
