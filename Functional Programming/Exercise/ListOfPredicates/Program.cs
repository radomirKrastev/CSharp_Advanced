using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    public class Program
    {
        public static void Main()
        {
            var border = int.Parse(Console.ReadLine());
            var numbers = new List<int>();

            for (int i = 1; i <= border; i++)
            {
                numbers.Add(i);
            }

            var dividers = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
            Func<HashSet<int>, List<int>, List<int>> filter = Filter;

            Console.WriteLine(string.Join(" ",numbers=filter(dividers,numbers)));
        }

        public static List<int> Filter (HashSet<int> dividers, List<int> numbers)
        {
            var filteredNumbers = new List<int>();
            
            foreach (var number in numbers)
            {
                var divisible = true;
                foreach (var divider in dividers)
                {
                    if(number % divider != 0)
                    {
                        divisible = false;
                        break;
                    }                    
                }

                if (divisible == true)
                {
                    filteredNumbers.Add(number);
                }
            }

            return filteredNumbers;
        }
    }
}
