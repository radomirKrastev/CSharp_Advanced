using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    public class Program
    {
        public static void Main()
        {
            var clothesValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rackInitialCapacity = int.Parse(Console.ReadLine());
            var clothes = new Stack<int>(clothesValues);
            var racksUsed = 1;
            var rackCurrentCapacity = rackInitialCapacity;

            while (clothes.Any())
            {
                var cloth = clothes.Pop();

                if (rackCurrentCapacity >=cloth)
                {
                    rackCurrentCapacity -= cloth;
                }
                else
                {
                    rackCurrentCapacity = rackInitialCapacity;
                    racksUsed++;
                    clothes.Push(cloth);
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
