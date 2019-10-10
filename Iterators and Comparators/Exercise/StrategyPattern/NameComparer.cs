using System.Collections.Generic;
using System;

namespace StrategyPattern
{
    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            var nameLengthResult = first.Name().Length.CompareTo(second.Name().Length);
            if (nameLengthResult == 0)
            {

                return Char.ToLower(first.Name()[0]).CompareTo(Char.ToLower(second.Name()[0]));
            }

            return nameLengthResult;
        }
    }
}
