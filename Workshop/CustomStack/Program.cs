using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class Program
    {
        public static void Main()
        {
            var customStack = new CustomStack<int>();

            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            customStack.Push(4);
            customStack.Push(5);
            customStack.Push(6);
            customStack.Push(7);
            customStack.Push(8);


            //var stack = new Stack<int>();
            //var peak = stack.Peek();
            //Console.WriteLine(peak);
            var peak = customStack.Peak();
            Console.WriteLine(peak);
            Console.WriteLine();
            customStack.Foreach(x => Console.Write(x+" "));
        }
    }
}
