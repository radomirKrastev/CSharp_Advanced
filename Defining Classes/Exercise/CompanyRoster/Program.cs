using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class Program
    {
        public static void Main()
        {
            var employeesCount = int.Parse(Console.ReadLine());
            var employeesList = new List<Employee>();

            for (int i = 0; i < employeesCount; i++)
            {
                var employeeInformation = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = employeeInformation[0];
                var salary = double.Parse(employeeInformation[1]);
                var position = employeeInformation[2];
                var department = employeeInformation[3];

                if(employeeInformation.Length == 4)
                {
                    employeesList.Add(new Employee(name, salary, position, department));
                }
                else if (employeeInformation.Length == 6)
                {
                    var email = employeeInformation[4];
                    var age = int.Parse(employeeInformation[5]);

                    employeesList.Add(new Employee(name, salary, position, department, email, age));
                }
                else if(employeeInformation.Length == 5)
                {
                    if(int.TryParse(employeeInformation[4], out int age))
                    {
                        employeesList.Add(new Employee(name, salary, position, department, age));
                    }
                    else
                    {
                        employeesList.Add(new Employee(name, salary, position, department, employeeInformation[4]));
                    }
                }
            }

            var departments = employeesList.GroupBy(x => x.Department);
            var highestAverageSalary = 0d;
            var highestPayingDepartment = string.Empty;
            foreach (var department in departments)
            {
                var departmentEmployees = 0;
                var averageSalary = 0d;
                foreach (var salary in department.Select(x=>x.Salary))
                {
                    averageSalary += salary;
                    departmentEmployees++;
                }

                averageSalary /= departmentEmployees;

                if (highestAverageSalary < averageSalary)
                {
                    highestAverageSalary = averageSalary;
                    highestPayingDepartment = department.Key;
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestPayingDepartment}");
            foreach (var employee in employeesList.Where(x => x.Department == highestPayingDepartment)
                .OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
