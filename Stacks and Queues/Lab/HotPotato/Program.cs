using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    public class Program
    {
        public static void Main()
        {
            var children = Console.ReadLine().Split().ToList();
            var hotNumber = int.Parse(Console.ReadLine());
            var removedChildren = new Queue<string>();
            var counter = 0;

            while (children.Count != 1)
            {                
                for (int i = 1; i <= hotNumber; i++)
                {
                    var child = children[counter];
                    if (i == hotNumber)
                    {
                        removedChildren.Enqueue(child);
                        children.RemoveAt(counter--);
                    }

                    if (counter >= children.Count - 1)
                    {
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }                   
                }
            }

            while (removedChildren.Any())
            {
                Console.WriteLine("Removed "+removedChildren.Dequeue());
            }

            Console.WriteLine("Last is "+children[0]);
        }
    }
}
