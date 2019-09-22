using System;
using System.Linq;
using System.Collections.Generic;

namespace FindEvenOrOdds
{
    public class Program
    {
        public static void Main()
        {
            var border = Console.ReadLine().Split();

            var start = int.Parse(border[0]);
            var end = int.Parse(border[1]);
            var numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            var condition = Console.ReadLine();
            Func<int, bool> filter = x => condition == "odd" ? x % 2 != 0 : x % 2 == 0;
            Console.WriteLine(string.Join(" ",numbers.Where(filter)));
        }
    }
}
