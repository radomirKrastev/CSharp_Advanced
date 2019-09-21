using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class Program
    {
        public class Person
        {
            public string Name { get;set; }
            public int Age { get;set; }
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

            Func<List<Person>, int, string, List<Person>> filter = FilterByAge;
            Action<List<Person>, string> print = Print;
            filter(people, border, condition);
            print(people, printRule);
        }

        public static void Print (List<Person> data, string rule)
        {
            switch (rule)
            {
                case "age":
                    {
                        foreach (var person in data)
                        {
                            Console.WriteLine(person.Age);
                        }
                    }
                    break;
                case "name":
                    {
                        foreach (var person in data)
                        {
                            Console.WriteLine(person.Name);
                        }
                    }
                    break;
                case "name age":
                    {
                        foreach (var person in data)
                        {
                            Console.WriteLine(person.Name+" - "+person.Age);
                        }
                    }
                    break;
            }
        }

        public static List<Person> FilterByAge(List<Person> data, int border, string condition)
        {
            var filteredData = new List<Person>();
            switch (condition)
            {
                case "younger":
                    {
                        filteredData = data.Where(x => x.Age <= border).ToList();
                    }
                    break;
                case "older":
                    {
                        filteredData = data.Where(x => x.Age >= border).ToList();
                    }
                    break;
            }

            data = filteredData;
            return data;
        }
    }
}
