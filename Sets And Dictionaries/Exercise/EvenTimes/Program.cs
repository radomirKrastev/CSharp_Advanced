using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    public class Program
    {
        public static void Main()
        {
            var inputCount = int.Parse(Console.ReadLine());
            var numbersCount = new Dictionary<int, int>();

            for (int i = 0; i < inputCount; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }

                numbersCount[number]++;
            }

            foreach (var number in numbersCount.Where(x=>x.Value%2==0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}
