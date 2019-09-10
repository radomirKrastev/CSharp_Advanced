using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sequence = Console.ReadLine().Split().Select(int.Parse);
            var stack = new Stack<int>(sequence);

            if (input[1] >= stack.Count)
            {
                stack.Clear();
            }
            else
            {
                for (int i = 0; i < input[1]; i++)
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else if(stack.Any())
            {
                var smallestNumber = int.MaxValue;
                while (stack.Any())
                {
                    var currentNumber = stack.Pop();
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
