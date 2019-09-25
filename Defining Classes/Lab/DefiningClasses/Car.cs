using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make,
            string model,
            int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        public void Drive(double distance)
        {
            if(this.fuelQuantity - distance/100*this.fuelConsumption>0)
            {
                this.fuelQuantity -= distance/100*this.fuelConsumption;
            }
            else
            {
                //this is just for the sake of the problem. Otherwise the car "does not know what is console!"
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }            
        }

        public string WhoAmI()
        {
            var result = new StringBuilder();
            result.AppendLine($"Make: {this.make}");
            result.AppendLine($"Model: {this.model}");
            result.AppendLine($"Year: {this.year}");
            result.Append($"Fuel: {this.fuelQuantity:F2}L");

            return result.ToString();
        }
    }
}
