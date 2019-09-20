using System;
using System.Linq;
using System.Collections.Generic;

namespace SortEvenNumbers
{
    public class Program
    {
        public static void Main()
        {
            var numbers= Console.ReadLine()
               .Split(", ")
               .Select(int.Parse)
               .Where(x => x % 2 == 0)
               .ToList();

            Func<List<int>, List<int>> sortAndPrint = SortAndPrint;
            sortAndPrint(numbers);
        }

        public static List<int> SortAndPrint(List<int> list)
        {
            list.Sort();
            Console.WriteLine(string.Join(", ",list));
            return list;
        }
    }
}
