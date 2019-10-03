using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodInt
{
    public class Box<T> where T : IComparable
    {
        private List<T> elements = new List<T>();

        public List<T> Elements => this.elements;

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public int Compare(T element)
        {
            var filteredList = this.Elements.Where(x => x.CompareTo(element) > 0).ToList();
            return filteredList.Count();
        }
    }
}
