using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static void Main()
        {
            var namesCount = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < namesCount; i++)
            {
                var personData = Console.ReadLine()
                    .Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person { Name = personData[0], Age = int.Parse(personData[1]) });
            }

            var condition = Console.ReadLine();
            var border = int.Parse(Console.ReadLine());
            var printRule = Console.ReadLine();

            Func<Person, bool> filterPredicate;
            if (condition == "younger")
            {
                filterPredicate = p => p.Age <= border;
            }
            else
            {
                filterPredicate = p => p.Age >= border;
            }

            Action<Person> print;
            if (printRule == "age")
            {
                print = p => Console.WriteLine(p.Age);
            }
            else if (printRule == "name")
            {
                print = p => Console.WriteLine(p.Name);
            }
            else
            {
                print = p => Console.WriteLine(p.Name + " - " + p.Age);
            }

            people
                .Where(filterPredicate)
                .ToList()
                .ForEach(print);
        }
    }
}
