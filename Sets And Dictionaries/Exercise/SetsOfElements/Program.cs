using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    public class Program
    {
        public static void Main()
        {
            var setsLength = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var firstSetLength = setsLength[0];
            var secondSetLength = setsLength[1];
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < firstSetLength; i++)
            {
                var number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                var number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            var uniqueRepeatingNumbers = new List<int>();

            foreach (var firstNumber in firstSet)
            {
                foreach (var secondNumber in secondSet)
                {
                    if (firstNumber == secondNumber)
                    {
                        uniqueRepeatingNumbers.Add(secondNumber);
                    }
                }
            }

            if (uniqueRepeatingNumbers.Count() > 0)
            {
                Console.WriteLine(string.Join(" ", uniqueRepeatingNumbers));
            }
        }
    }
}
