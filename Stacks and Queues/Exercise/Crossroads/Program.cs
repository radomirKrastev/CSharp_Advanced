using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    public class Program
    {
        public static void Main()
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWindowDuration = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();
            var crossroadQueue = new Queue<string>();
            var carsThatPassed = 0;

            while (command != "END")
            {
                if (command == "green")
                {
                    var greenLightLeft = greenLightDuration;
                    var passingDuration = greenLightDuration+freeWindowDuration; 

                    while (crossroadQueue.Any())
                    {
                        var carPassing = crossroadQueue.Dequeue();
                        var carPassingTime = carPassing.Length;
                        
                        if (greenLightLeft>0)
                        {
                            if (carPassingTime <= passingDuration)
                            {
                                carsThatPassed++;
                                passingDuration -= carPassingTime;
                                greenLightLeft -= carPassingTime;
                                crossroadQueue.Enqueue(carPassing);
                            }
                            else
                            {
                                var difference = carPassingTime - passingDuration;
                                var hitPart = carPassing[carPassing.Length - difference];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine(carPassing + " was hit at " + hitPart + ".");
                                return;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    crossroadQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine(carsThatPassed+ " total cars passed the crossroads.");
        }
    }
}
