using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var familyCount = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < familyCount; i++)
            {
                var memberInformation = Console.ReadLine().Split(new string [] {" "},StringSplitOptions.RemoveEmptyEntries);
                var name = memberInformation[0];
                var age = int.Parse(memberInformation[1]);

                var member = new Person(name,age);
                family.AddMember(member);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember.Name+" "+oldestMember.Age);
        }
    }
}
