using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        public static void Main()
        {
            var countOfPeople = int.Parse(Console.ReadLine());
            var peopleSorted = new SortedSet<Person>();
            var people = new HashSet<Person>();

            for (int i = 0; i < countOfPeople; i++)
            {
                var input = Console.ReadLine().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                people.Add(new Person(name, age));
                peopleSorted.Add(new Person(name, age));
            }

            Console.WriteLine(peopleSorted.Count);
            Console.WriteLine(people.Count);
        }
    }
}
