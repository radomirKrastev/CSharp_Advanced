using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    public class Employee
    {
        private string name;
        private string position;
        private string department;
        private double salary;
        private string email = "n/a";
        private int age = -1;

        public string Name
        {
            get=>this.name;
            set=> this.name = value;
        }

        public string Position
        {
            get => this.position;
            set => this.position = value;
        }

        public string Department
        {
            get => this.department;
            set => this.department = value;
        }

        public double Salary
        {
            get => this.salary;
            set => this.salary = value;
        }

        public string Email
        {
            get => this.email;
            set => this.email = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public Employee(string name, double salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
        }

        public Employee(string name, double salary, string position, string department, int age)
            : this(name, salary, position, department, "n/a", age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Age = age;
        }

        public Employee(string name, double salary, string position, string department, string email)
            :this(name,salary,position,department,email,-1)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
        }

        public Employee(string name, double salary, string position,string department,string email,int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }
    }
}
