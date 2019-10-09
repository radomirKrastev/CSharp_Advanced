using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> list;

        public Stack()
        {
            this.list = new List<T>();
        }

        public void Push(List<T> elements)
        {
            this.list.AddRange(elements);
        }

        public T Pop()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("No elements!");
            }

            var element = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.list.Count-1; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
