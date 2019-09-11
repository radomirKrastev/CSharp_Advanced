using System;
using System.Linq;
using System.Collections.Generic;

namespace TruckTour
{
    public class Program
    {
        public static void Main()
        {
            var petrolStopsCount = int.Parse(Console.ReadLine());
            var petrolStopsData = new List<string>();

            for (int i = 0; i < petrolStopsCount; i++)
            {
                petrolStopsData.Add(Console.ReadLine());
            }

            for (int i = 0; i < petrolStopsCount; i++)
            {
                var circle = new Queue<string>();
                var counter = i;

                while (circle.Count() < petrolStopsCount)
                {
                    if (counter > petrolStopsData.Count - 1)
                    {
                        counter = 0;
                    }

                    circle.Enqueue(petrolStopsData[counter]);
                    counter++;
                }

                var petrolStopIsFound = true;
                var fuel = 0;
                var distance = 0;

                while (circle.Any())
                {
                    var data = circle.Dequeue().Split();
                    fuel += int.Parse(data[0]);
                    distance = int.Parse(data[1]);

                    if (fuel < distance)
                    {
                        petrolStopIsFound = false;
                        break;
                    }

                    fuel -= distance;
                }

                GC.Collect();
                if (petrolStopIsFound)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
