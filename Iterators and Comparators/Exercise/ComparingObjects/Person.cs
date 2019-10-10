using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public string name;
        public int age;
        public string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            var nameResult = this.name.CompareTo(other.name);

            if (nameResult == 0)
            {
                var ageResult = this.age.CompareTo(other.age);

                if (ageResult == 0)
                {
                    return this.town.CompareTo(other.town);
                }

                return ageResult;
            }

            return nameResult;
        }
    }
}
