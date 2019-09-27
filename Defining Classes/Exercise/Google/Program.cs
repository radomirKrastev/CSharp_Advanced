using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Google
{
    public class Program
    {
        public static void Main()
        {
            var personalInformation = Console.ReadLine();
            var people = new List<Person>();

            while (personalInformation != "End")
            {   
                var tokens = personalInformation.Split(new string[] {" " }, StringSplitOptions.RemoveEmptyEntries);
                var obj = tokens[1];
                var name = tokens[0];

                if (!people.Select(x => x.Name).Contains(name))
                {
                    people.Add(new Person(name));
                }

                if (obj == "company")
                {
                    var companyName = tokens[2];
                    var department = tokens[3];
                    var salary = double.Parse(tokens[4]);

                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Company = new Company(companyName, department, salary);
                }
                else if (obj == "pokemon")
                {
                    var pokemonName = tokens[2];
                    var pokemonType = tokens[3];

                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.PokemonCollection.Add(new Pokemon(pokemonName, pokemonType));
                }
                else if (obj == "parents")
                {
                    var parentName = tokens[2];
                    var parentBirthday = DateTime.Parse(tokens[3]);

                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Parents.Add(new Parent(parentName,parentBirthday));
                }
                else if (obj == "children")
                {
                    var childName = tokens[2];
                    var childBirthday = DateTime.Parse(tokens[3]);

                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Children.Add(new Child(childName, childBirthday));
                }
                else if (obj == "car")
                {
                    var model = tokens[2];
                    var speed = double.Parse(tokens[3]);

                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Car = new Car(model, speed);
                }

                personalInformation = Console.ReadLine();
            }

            var personName = Console.ReadLine();
            var person = people.First(x=>x.Name==personName);

            Console.WriteLine("Company:");
            if (person.Company!=null )
            {
                Console.WriteLine("{0} {1} {2:F2}",person.Company.Name,person.Company.Department,person.Company.Salary);
            }
            Console.WriteLine("Car:");
            if (person.Car != null)
            {
                Console.WriteLine("{0} {1}", person.Car.Model, person.Car.Speed);
            }
            Console.WriteLine("Pokemon:");
            if (person.PokemonCollection.Any())
            {
                foreach (var pokemon in person.PokemonCollection)
                {
                    Console.WriteLine("{0} {1}", pokemon.Name, pokemon.Type);
                }
            }
            Console.WriteLine("Parents:");
            if (person.Parents.Any())
            {
                foreach (var parent in person.Parents)
                {
                    Console.WriteLine("{0} {1}", parent.Name, String.Format("{0:dd'/'MM'/'yyyy}", parent.Birthday, CultureInfo.InvariantCulture));
                }
            }
            Console.WriteLine("Children:");
            if (person.Children.Any())
            {
                foreach (var child in person.Children)
                {
                    Console.WriteLine("{0} {1}", child.Name, String.Format("{0:dd'/'MM'/'yyyy}", child.Birthday, CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
