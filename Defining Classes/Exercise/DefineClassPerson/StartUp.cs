using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            var person = new Person();
            Console.WriteLine(person.Age + " " + person.Name);
            var secondPerson = new Person(5);
            Console.WriteLine(secondPerson.Age + " " + secondPerson.Name);
            var thirdPerson = new Person("Gosho", 500);
            Console.WriteLine(thirdPerson.Age + " " + thirdPerson.Name);
        }
    }
}
