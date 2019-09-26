using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption; //per km
        private double distanceTraveled=0;

        public string Model
        {
            get => this.model;
            private set { this.model = value; }
        }

        public double FuelAmount
        {
            get => this.fuelAmount;
            private set { this.fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            private set { this.fuelConsumption = value; }
        }

        public double DistanceTraveled
        {
            get => this.distanceTraveled;
            private set { this.distanceTraveled = value; }
        }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount= fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public string Drive(double distance)
        {
            var result = string.Empty;
            if (this.fuelAmount >= distance * this.fuelConsumption)
            {
                this.distanceTraveled += distance;
                this.fuelAmount -= distance * this.fuelConsumption;
            }
            else
            {
                result = "Insufficient fuel for the drive";
            }

            return result;
        }
    }
}
