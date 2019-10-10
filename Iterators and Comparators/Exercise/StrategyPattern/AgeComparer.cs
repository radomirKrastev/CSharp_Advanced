using System.Collections.Generic;

namespace StrategyPattern
{
    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age().CompareTo(second.Age());
        }
    }
}
