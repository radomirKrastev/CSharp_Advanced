using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Company
    {
        private string name;
        private string department;
        private double salary;

        public string Name => this.name;
        public string Department => this.department;
        public double Salary => this.salary;

        public Company(string name, string department, double salary)
        {
            this.name = name;
            this.department = department;
            this.salary = salary;
        }
    }
}
