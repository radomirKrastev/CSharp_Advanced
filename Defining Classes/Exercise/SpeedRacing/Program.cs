using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        public static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInformation = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var model = carInformation[0];
                var fuelAmount = double.Parse(carInformation[1]);
                var fuelConsumption = double.Parse(carInformation[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[1];
                var distance = double.Parse(tokens[2]);

                var carModel = cars.Find(x=>x.Model==model);
                var result = carModel.Drive(distance);
                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }
        }
    }
}
