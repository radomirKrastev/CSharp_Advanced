using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class Program
    {
        public static void Main()
        {
            var nameSortedPeople = new SortedSet<Person>(new NameComparer());
            var ageSortedPeople = new SortedSet<Person>(new AgeComparer());
            var countOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPeople; i++)
            {
                var input = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);

                nameSortedPeople.Add(person);
                ageSortedPeople.Add(person);
            }

            foreach (var person in nameSortedPeople)
            {
                Console.WriteLine(person.Name()+" "+person.Age());
            }

            foreach (var person in ageSortedPeople)
            {
                Console.WriteLine(person.Name() + " " + person.Age());
            }
        }
    }
}
