using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sequence = Console.ReadLine().Split().Select(int.Parse);
            var queue = new Queue<int>(sequence);

            if (input[1] >= queue.Count)
            {
                queue.Clear();
            }
            else
            {
                for (int i = 0; i < input[1]; i++)
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Any())
            {
                var smallestNumber = int.MaxValue;
                while (queue.Any())
                {
                    var currentNumber = queue.Dequeue();
                    if (smallestNumber > currentNumber)
                    {
                        smallestNumber = currentNumber;
                    }
                }

                Console.WriteLine(smallestNumber);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
