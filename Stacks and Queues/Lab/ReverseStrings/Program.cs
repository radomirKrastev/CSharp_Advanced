using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<string>();

            foreach (var ch in input)
            {
                stack.Push(ch.ToString());
            }
            
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
