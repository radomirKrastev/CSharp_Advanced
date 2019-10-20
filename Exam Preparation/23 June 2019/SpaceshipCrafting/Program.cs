using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    public class Program
    {
        public static void Main()
        {
            var liquids = new Queue<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            var items = new Stack<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            var glass = 0;
            var aluminium = 0;
            var lithium = 0;
            var carbonFiber = 0;

            while (liquids.Any() && items.Any())
            {
                var liquid = liquids.Dequeue();
                var item = items.Pop();

                if (liquid + item == 25)
                {
                    glass++;
                }
                else if(liquid+item == 50)
                {
                    aluminium++;
                }
                else if (liquid + item == 75)
                {
                    lithium++;
                }
                else if (liquid + item == 100)
                {
                    carbonFiber++;
                }
                else
                {
                    item += 3;
                    items.Push(item);
                }
            }

            var allMaterialsAquired = glass > 0 && aluminium > 0 && lithium > 0 && carbonFiber > 0;
            PrintResult(allMaterialsAquired);
            PrintLiquids(liquids);
            PrintItems(items);
            PrintAdvancedMaterialsCount(aluminium,carbonFiber,glass,lithium);
        }

        private static void PrintAdvancedMaterialsCount(int aluminium, int carbonFiber, int glass, int lithium)
        {
            Console.WriteLine($"Aluminium: {aluminium}");
            Console.WriteLine($"Carbon fiber: {carbonFiber}");
            Console.WriteLine($"Glass: {glass}");
            Console.WriteLine($"Lithium: {lithium}");
        }

        private static void PrintResult(bool allMaterialsAquired)
        {
            if (allMaterialsAquired)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
        }

        private static void PrintLiquids(Queue<int> liquids)
        {
            if (!liquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
        }

        private static void PrintItems(Stack<int> items)
        {
            if (!items.Any())
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
        }
    }
}
