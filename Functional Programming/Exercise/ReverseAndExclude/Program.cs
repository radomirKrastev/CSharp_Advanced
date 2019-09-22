using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseAndExclude
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            var key = int.Parse(Console.ReadLine());
            Func<int, bool> excludeAndReverse;
            excludeAndReverse = x => x % key != 0;
            Console.WriteLine(string.Join(" ",numbers.Where(excludeAndReverse)));
        }
    }
}
