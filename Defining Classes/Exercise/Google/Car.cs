using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Car
    {
        private string model;
        private double speed;

        public string Model => this.model;
        public double Speed => this.speed;

        public Car(string model, double speed)
        {
            this.model = model;
            this.speed = speed;
        }
    }
}
