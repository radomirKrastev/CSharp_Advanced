using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>(input.Reverse());
            var sum = int.Parse(stack.Pop());

            while (stack.Any())
            {
                var nextSymbol = stack.Pop();
                if (nextSymbol == "+")
                {
                    sum += int.Parse(stack.Pop());
                }
                else if (nextSymbol == "-")
                {
                    sum -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
