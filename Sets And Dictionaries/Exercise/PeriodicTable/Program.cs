using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    public class Program
    {
        public static void Main()
        {
            var chemicalsCount = int.Parse(Console.ReadLine());
            var chemicals = new SortedSet<string>();

            for (int i = 0; i < chemicalsCount; i++)
            {
                var elements = Console.ReadLine().Split();

                foreach (var element in elements)
                {
                    chemicals.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
