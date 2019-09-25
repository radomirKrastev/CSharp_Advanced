using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 100;
            car.FuelConsumption = 19;
            car.Drive(5);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
