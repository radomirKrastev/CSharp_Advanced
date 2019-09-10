using System;
using System.Linq;
using System.Collections.Generic;

namespace StackSum
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var stack = new Stack<int>(input);
            var command = Console.ReadLine().Split();
            while (command.Count() > 1)
            {
                if (command.Count() == 3)
                {
                    var numberOne = int.Parse(command[1]);
                    var numberTwo = int.Parse(command[2]);
                    stack.Push(numberOne);
                    stack.Push(numberTwo);
                }
                else
                {
                    var count = int.Parse(command[1]);

                    if (count == stack.Count)
                    {
                        stack.Clear();
                    }
                    else if(count<stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }                    
                }

                command = Console.ReadLine().Split();
            }

            int sum = 0;
            while (stack.Count > 0)
            {
                sum+=stack.Pop();
            }

            Console.WriteLine("Sum: "+sum);
        }
    }
}
