using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            var numbersCount = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }

                numbersCount[number]++;
            }

            foreach (var number in numbersCount)
            {
                Console.WriteLine(number.Key+" - "+number.Value+" times");
            }
        }
    }
}
