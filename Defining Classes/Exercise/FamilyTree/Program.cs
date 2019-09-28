using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

namespace FamilyTree
{
    public class Program
    {
        static Func<List<Person>, DateTime, bool> birthDateExist = (x, z) => x.Select(y => y.Birthday).Contains(z);
        static Func<List<Person>, string, bool> doesNameExist = (x, z) => x.Select(y => y.Name).Contains(z);

        public static void Main()
        {
            var input = Console.ReadLine();
            var command = Console.ReadLine();
            var relations = new List<string>();
            var familyMembers = new List<Person>();

            while (command != "End")
            {
                if (command.Contains(" - "))
                {
                    relations.Add(command);
                }
                else
                {
                    var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    var name = tokens[0] + " " + tokens[1];
                    var birthday = DateTime.Parse(tokens[2]);
                    familyMembers.Add(new Person(name, birthday));
                }

                command = Console.ReadLine();
            }

            foreach (var relation in relations)
            {
                var tokens = relation.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var parent = new Person();
                var child = new Person();

                if (DateTime.TryParse(tokens[0], out DateTime parentBirthday))
                {
                    parent = familyMembers.First(x => x.Birthday == parentBirthday);

                    if (DateTime.TryParse(tokens[1], out DateTime childBirthday))
                    {
                        child = familyMembers.First(x => x.Birthday == childBirthday);
                    }
                    else
                    {
                        var childName = tokens[1];
                        child = familyMembers.First(x => x.Name == childName);
                    }                   
                }
                else
                {
                    var parentName = tokens[0];
                    parent = familyMembers.First(x => x.Name == parentName);

                    if (DateTime.TryParse(tokens[1], out DateTime childBirthday))
                    {
                        child = familyMembers.First(x => x.Birthday == childBirthday);
                    }
                    else
                    {
                        var childName = tokens[1];
                        child = familyMembers.First(x => x.Name == childName);
                    }
                }

                child.Parents.Add(parent);
                parent.Children.Add(child);
            }

            var person = new Person();
            if (DateTime.TryParse(input, out DateTime searchedBirthday))
            {
                person = familyMembers.First(x => x.Birthday == searchedBirthday);
            }
            else
            {
                person=familyMembers.First(x => x.Name == input);
            }

            Console.WriteLine("{0} {1}", person.Name, String.Format("{0:dd'/'MM'/'yyyy}", person.Birthday));
            Console.WriteLine("Parents:");
            foreach (var parent in person.Parents)
            {
                Console.WriteLine("{0} {1}", parent.Name, String.Format("{0:dd'/'MM'/'yyyy}", parent.Birthday));
            }
            Console.WriteLine("Children:");
            foreach (var child in person.Children)
            {
                Console.WriteLine("{0} {1}", child.Name, String.Format("{0:dd'/'MM'/'yyyy}", child.Birthday));
            }
        }
    }
}    
