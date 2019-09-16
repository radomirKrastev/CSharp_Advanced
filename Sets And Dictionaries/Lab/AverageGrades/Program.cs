using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageGrades
{
    public class Program
    {
        public static void Main()
        {
            var gradesCount = int.Parse(Console.ReadLine());
            var studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < gradesCount; i++)
            {
                var nameGrade = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = nameGrade[0];
                var grade = double.Parse(nameGrade[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new List<double>());
                }

                studentsGrades[name].Add(grade);
            }

            foreach (var student in studentsGrades)
            {
                var name = student.Key;
                var grades = student.Value;
                var average = grades.Average();

                Console.Write($"{name} -> ");
                foreach (var grade in grades)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {average:F2})");    
            }
        }
    }
}
