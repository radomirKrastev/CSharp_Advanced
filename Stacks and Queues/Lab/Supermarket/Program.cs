using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var supermarketQueue = new Queue<string>();

            while (command != "End")
            {
                if (command == "Paid")
                {
                    while (supermarketQueue.Any())
                    {
                        Console.WriteLine(supermarketQueue.Dequeue());
                    }
                }
                else
                {
                    supermarketQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(supermarketQueue.Count+" people remaining.");
        }
    }
}
