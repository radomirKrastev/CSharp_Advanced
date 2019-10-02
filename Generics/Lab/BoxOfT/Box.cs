using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;
        
        public int Count { get; private set; }

        public Box()
        {
            this.elements = new List<T>();
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.Count++;
        }

        public T Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Box is empty!");
            }

            var result = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);
            this.Count--;
            return result;
        }
    }
}
