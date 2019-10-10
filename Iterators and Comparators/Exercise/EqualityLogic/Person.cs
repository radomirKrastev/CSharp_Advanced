using System;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            var nameResult = this.name.CompareTo(other.name);

            if (nameResult == 0)
            {
                return this.age.CompareTo(other.age);
            }

            return nameResult;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (!(obj is Person))
            {
                return false;
            }

            var other = obj as Person;

            if (this.name != other.name || this.age != other.age)
            {
                return false;
            }

            return true;
        }

        //override object.GetHashCode
        public override int GetHashCode()
        {
            int hashName = this.name == null ? 0 : this.name.GetHashCode();
            int hashAge = this.age.GetHashCode();

            return hashName ^ hashAge;
        }
    }
}
