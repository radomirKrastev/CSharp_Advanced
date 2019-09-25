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
        private Engine engine;
        private Tire[] tires;
        
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

        public Engine Engine
        {
            get => this.engine;
            set { this.engine = value; }
        }

        public Tire[] Tires
        {
            get => this.tires;
            set { this.tires = value; }
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        //public Car(string make,
        //    string model,
        //    int year)
        //    : this()
        //{
        //    this.Make = make;
        //    this.Model = model;
        //    this.Year = year;
        //}

        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires= tires;
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

            //result.AppendLine($"Engine capacity: {this.engine.Capacity}");
            //result.AppendLine($"Engine power: {this.engine.Power}");
            //result.Append($"Tires: ");
            //foreach (var tire in this.tires)
            //{
            //    result.Append("("+tire.Year + ", " + tire.Pressure+") ");
            //}

            //Console.WriteLine(string.Join(" ", this.tires[1]));
            return result.ToString();
        }
    }
}
