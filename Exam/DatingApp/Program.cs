using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    public class Program
    {
        public static void Main()
        {
            var males = new Stack<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var females = new Queue<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var matches = 0;

            while(males.Any() && females.Any())
            {
                var female = females.Peek();

                if (female <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                var male = males.Pop();

                if (male <= 0)
                {
                    continue;
                }

                if (female % 25 == 0 || male % 25 == 0)
                {
                    if(female % 25 == 0)
                    {
                        females.Dequeue();

                        if (females.Any())
                        {
                            females.Dequeue();
                        }                        
                    }

                    if (male % 25 == 0)
                    {
                        if (males.Any())
                        {
                            males.Pop();
                        }                        
                    }
                    else
                    {
                        males.Push(male);
                    }

                    continue;
                }

                if (female == male)
                {
                    females.Dequeue();
                    matches++;
                }
                else
                {
                    male -= 2;
                    males.Push(male);
                    females.Dequeue();
                }
            }

            Console.WriteLine($"Matches: {matches}");

            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ",males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
