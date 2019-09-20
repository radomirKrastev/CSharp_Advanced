using System;
using System.Linq;
using System.Collections.Generic;

namespace SumNumbers
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
               .Split(", ")
               .Select(int.Parse)
               .ToList();

            Action<List<int>> print = PrintCountAndSum;
            print(numbers);
            
        }

        public static void PrintCountAndSum(List<int> list)
        {
            Console.WriteLine(list.Count());
            Console.WriteLine(list.Sum());
        }
    }
}
