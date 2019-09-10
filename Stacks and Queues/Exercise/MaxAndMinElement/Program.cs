using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxAndMinElement
{
    public class Program
    {
        public static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (command[0] == 1)
                {
                    stack.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (command[0] == 4)
                {
                    if (stack.Any())
                    {
                        var stackData = stack.ToArray().Reverse();
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
                        foreach (var number in stackData)
                        {
                            stack.Push(number);
                        }
                    }
                }
                else
                {
                    if (stack.Any())
                    {
                        var stackData = stack.ToArray().Reverse();
                        var largestNumber = int.MinValue;
                        while (stack.Any())
                        {
                            var currentNumber = stack.Pop();
                            if (largestNumber < currentNumber)
                            {
                                largestNumber = currentNumber;
                            }
                        }

                        Console.WriteLine(largestNumber);
                        foreach (var number in stackData)
                        {
                            stack.Push(number);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack.ToArray()));
        }
    }
}
