using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var pollParticipants = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var personInformation = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = personInformation[0];
                var age = int.Parse(personInformation[1]);

                pollParticipants.Add(new Person(name, age));
            }

            foreach (var person in pollParticipants.Where(x=>x.Age>30).OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
            //var familyCount = int.Parse(Console.ReadLine());
            //var family = new Family();

            //for (int i = 0; i < familyCount; i++)
            //{
            //    var memberInformation = Console.ReadLine().Split(new string [] {" "},StringSplitOptions.RemoveEmptyEntries);
            //    var name = memberInformation[0];
            //    var age = int.Parse(memberInformation[1]);

            //    var member = new Person(name,age);
            //    family.AddMember(member);
            //}

            //var oldestMember = family.GetOldestMember();
            //Console.WriteLine(oldestMember.Name+" "+oldestMember.Age);
        }
    }
}
