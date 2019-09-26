using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            var tireInformation = Console.ReadLine();
            var tiresList = new List<Tire[]>();

            while(tireInformation!="No more tires")
            {
                var tokens = tireInformation.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                var tires = new Tire[4];
                var counter = 0;

                for (int i = 0; i < tokens.Length-1; i+=2)
                {
                    var year = int.Parse(tokens[i]);
                    var pressure = double.Parse(tokens[i+1]);

                    tires[counter++] = new Tire(year, pressure);
                }

                tiresList.Add(tires);
                tireInformation = Console.ReadLine();
            }

            var engineInformation = Console.ReadLine();
            var enginesList = new List<Engine>();

            while(engineInformation!="Engines done")
            {
                var tokens = engineInformation.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var horsePower = int.Parse(tokens[0]);
                var cubicCapacity = double.Parse(tokens[1]);

                var engine = new Engine(horsePower,cubicCapacity);
                enginesList.Add(engine);
                engineInformation = Console.ReadLine();
            }

            var carInformation = Console.ReadLine();
            var carsList = new List<Car>();

            while(carInformation!="Show special")
            {
                var tokens = carInformation.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var make = tokens[0];
                var model = tokens[1];
                var year = int.Parse(tokens[2]);
                var fuelQuantity = double.Parse(tokens[3]);
                var fuelConsumption = double.Parse(tokens[4]);
                var engineIndex = int.Parse(tokens[5]);
                var tiresIndex = int.Parse(tokens[6]);

                carsList.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, enginesList[engineIndex], tiresList[tiresIndex]));
                carInformation = Console.ReadLine();
            }

            Func<Tire[], bool> pressureSumFunc;
            pressureSumFunc = x => x.Select(y => y.Pressure).Sum() > 9 && x.Select(y => y.Pressure).Sum() < 10;

            foreach (var car in carsList
                .Where(x=>x.Year>=2017)
                .Where(x => x.Engine.HorsePower > 330)
                .Where(x => pressureSumFunc(x.Tires)))
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
