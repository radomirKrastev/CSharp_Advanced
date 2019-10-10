using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>();

            var command = Console.ReadLine();

            while (command != "END")
            {
                var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
                command = Console.ReadLine();
            }

            var number = int.Parse(Console.ReadLine());
            var keyPerson = people[number - 1];
            var equalPeople = 0;
            var differentPeople = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(keyPerson) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    differentPeople++;
                }
            }

            if (equalPeople-1 == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {differentPeople} {people.Count}");
            }
        }
    }
}
