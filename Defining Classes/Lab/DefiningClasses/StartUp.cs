using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car second = new Car(make,model,year);
            Car third = new Car(make,model,year,fuelQuantity,fuelConsumption);

            //Car car = new Car();
            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 100;
            //car.FuelConsumption = 19;
            //car.Drive(5);
            //Console.WriteLine(car.WhoAmI());
        }
    }
}
