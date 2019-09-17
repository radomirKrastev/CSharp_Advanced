using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkingLot
{
    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine()
                .Split(new string[] { " ", "," },StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var parking = new HashSet<string>();

            while (command[0] != "END")
            {
                var direction = command[0];
                var carNumber = command[1];

                switch (direction)
                {
                    case "IN":
                        parking.Add(carNumber);
                        break;
                    case "OUT":
                            parking.Remove(carNumber);
                        break;
                }

                command= Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            if (parking.Count > 0)
            {
                foreach (var carNumber in parking)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }            
        }
    }
}
