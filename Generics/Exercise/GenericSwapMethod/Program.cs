using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethod
{
    public class Program
    {
        public static void Swap<T>(List<T> data, int indexOne, int indexTwo)
        {
            var firstValue = data[indexOne];
            var secondValue = data[indexTwo];
            data[indexOne] = secondValue;
            data[indexTwo] = firstValue;
        }

        public static void Main()
        {
            var inputCount = int.Parse(Console.ReadLine());
            var strings = new List<string>();

            for (int i = 0; i < inputCount; i++)
            {
                strings.Add(Console.ReadLine());
            }

            var indices = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Swap(strings, indices[0], indices[1]);

            Console.WriteLine(strings[0].GetType()+" "+ string.Join(Environment.NewLine + strings[0].GetType()+" ",strings));
        }
    }
}
