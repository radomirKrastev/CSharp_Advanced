using System;
using System.Linq;
using System.Collections.Generic;

namespace CupsAndBottles
{
    public class Program
    {
        public static void Main()
        {
            var cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bottlesOfWater = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(bottlesOfWater);
            var wastedWater = 0;

            while (cups.Any())
            {
                if (bottles.Any())
                {
                    var currentCup = cups.Peek();
                    var currentBottle = bottles.Pop();

                    if (currentBottle >= currentCup)
                    {
                        cups.Dequeue();
                        wastedWater += currentBottle - currentCup;
                    }
                    else
                    {
                        currentCup -= currentBottle;

                        while (currentCup > 0)
                        {
                            if (!bottles.Any())
                            {
                                Console.WriteLine($"Cups: {string.Join(" ", cups.ToList())}");
                                Console.WriteLine($"Wasted litters of water: {wastedWater}");
                                return;
                            }
                            else
                            {
                                currentCup -= bottles.Pop();
                                if (currentCup <= 0)
                                {
                                    wastedWater += Math.Abs(currentCup);
                                    cups.Dequeue();
                                    break;
                                }
                            }                            
                        }                        
                    }
                }
                else
                {
                    if (!bottles.Any())
                    {
                        Console.WriteLine($"Cups: {string.Join(" ", cups.ToList())}");
                        Console.WriteLine($"Wasted litters of water: {wastedWater}");
                        return;
                    }
                }                
            }

            Console.WriteLine($"Bottles: {string.Join(" ", bottles.ToList())}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
