using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        public static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var carsList = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInformation = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                var model = carInformation[0];
                var engine = new Engine(int.Parse(carInformation[1]), int.Parse(carInformation[2]));
                var cargo = new Cargo(int.Parse(carInformation[3]), carInformation[4]);
                var tires = new Tire[4];

                var indexCounter = 0;
                for (int j = 5; j < carInformation.Length-1; j+=2)
                {
                    tires[indexCounter++] = new Tire(double.Parse(carInformation[j]), int.Parse(carInformation[j + 1]));
                }

                carsList.Add(new Car(model, engine, cargo, tires));
            }

            var command = Console.ReadLine();
            Func<Tire[], double> getLowestPressureTire = x => x.Select(y=>y.Pressure).OrderBy(y=>y).First();
            Func<Tire[], bool> pressureLowEnough = y=> getLowestPressureTire(y) < 1;

            if (command == "fragile")
            {
                foreach (var car in carsList.Where(x => x.Cargo.Type == "fragile").Where(x => pressureLowEnough(x.Tires)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if(command== "flamable")
            {
                foreach (var car in carsList.Where(x=>x.Cargo.Type=="flamable").Where(x=>x.Engine.Power>250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
