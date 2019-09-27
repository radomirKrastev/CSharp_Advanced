using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        public static void Main()
        {
            var enginesCount = int.Parse(Console.ReadLine());
            var enginesList = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                var engineSpecifications = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var model = engineSpecifications[0];
                var power = int.Parse(engineSpecifications[1]);
                if (engineSpecifications.Length == 2)
                {
                    enginesList.Add(new Engine(model, power));
                }
                else if (engineSpecifications.Length == 3)
                {
                    if(double.TryParse(engineSpecifications[2], out double displacement))
                    {
                        enginesList.Add(new Engine(model, power,displacement));
                    }
                    else
                    {
                        enginesList.Add(new Engine(model, power, engineSpecifications[2]));
                    }
                }
                else
                {
                    var displacement = double.Parse(engineSpecifications[2]);
                    var efficiency = engineSpecifications[3];

                    enginesList.Add(new Engine(model, power, displacement,efficiency));
                }
            }

            var carsCount = int.Parse(Console.ReadLine());
            var carsList = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                var carSpecifications = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var carModel = carSpecifications[0];
                var engineModel = carSpecifications[1];
                var currentCarEngine = enginesList.First(x => x.Model == engineModel);

                if (carSpecifications.Length == 2)
                {
                    carsList.Add(new Car(carModel, currentCarEngine));
                }
                else if (carSpecifications.Length == 3)
                {
                    if (double.TryParse(carSpecifications[2], out double weight))
                    {
                        carsList.Add(new Car(carModel, currentCarEngine, weight));
                    }
                    else
                    {
                        carsList.Add(new Car(carModel, currentCarEngine, carSpecifications[2]));
                    }
                }
                else if (carSpecifications.Length == 4)
                {
                    var weight = double.Parse(carSpecifications[2]);
                    var color = carSpecifications[3];

                    carsList.Add(new Car(carModel, currentCarEngine, weight, color));
                }
            }

            foreach (var car in carsList)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine("    Displacement: {0}",car.Engine.Displacement == -1 ? "n/a" : $"{car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine("  Weight: {0}",car.Weight==-1 ? "n/a" : $"{car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
