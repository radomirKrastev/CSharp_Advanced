using System;
using System.Collections.Generic;

namespace HotPotatoOptimized
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var hotNumber = int.Parse(Console.ReadLine());
            var children = new Queue<string>(input);
            var counter = 1;

            while (children.Count > 1)
            {
                var child = children.Dequeue();

                if (counter % hotNumber == 0)
                {
                    Console.WriteLine("Removed " + child);
                }
                else
                {
                    children.Enqueue(child);
                }

                counter++;
            }

            Console.WriteLine("Last is " + children.Dequeue());
        }
    }
}
