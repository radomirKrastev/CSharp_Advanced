using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private double displacement = -1;
        private string efficiency = "n/a";

        public string Model
        {
            get => this.model;
            set { this.model = value; }
        }

        public int Power
        {
            get => this.power;
            set { this.power = value; }
        }

        public double Displacement
        {
            get => this.displacement;
            set { this.displacement = value; }
        }

        public string Efficiency
        {
            get => this.efficiency;
            set { this.efficiency = value; }
        }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model,int power, double displacement):this(model,power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency):this(model,power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, double displacement, string efficiency):this(model,power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
    }
}
