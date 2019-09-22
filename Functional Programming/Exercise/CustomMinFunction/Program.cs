using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomMinFunction
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>,int> min = Min;
            Console.WriteLine(min(numbers));
        }

        public static int Min(List<int> numbers)
        {
            var minNumber = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }
    }   
}
