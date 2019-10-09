using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var stack = new Stack<int>();

            while (command != "END")
            {
                if (command.Split(" ")[0] == "Push")
                {
                    var elements = command.Substring(5)
                        .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                    stack.Push(elements);

                }
                else if (command == "Pop")
                {
                    stack.Pop();
                }

                command = Console.ReadLine();
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
