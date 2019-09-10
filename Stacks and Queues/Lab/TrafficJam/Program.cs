using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrafficJam
{
    public class Program
    {
        public static void Main()
        {
            var crossroadLimit = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var command = Console.ReadLine();
            var carsPassed = new StringBuilder();
            var counter = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    if (crossroadLimit <= queue.Count)
                    {
                        for (int i = 0; i < crossroadLimit; i++)
                        {
                            counter++;
                            carsPassed.AppendLine(queue.Dequeue() + " passed!");
                        }
                    }
                    else
                    {
                        while (queue.Any())
                        {
                            counter++;
                            carsPassed.AppendLine(queue.Dequeue() + " passed!");
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.Write(carsPassed);
            Console.Write(counter+" cars passed the crossroads.");
        }
    }
}
