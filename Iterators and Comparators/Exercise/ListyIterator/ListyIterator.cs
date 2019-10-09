using System;
using System.Collections;
using System.Collections.Generic;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int index = 0;

        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
        }

        public bool Move()
        {
            if (this.index + 1 < this.collection.Count)
            {
                this.index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.collection.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (this.collection.Count > 0)
            {
                Console.WriteLine(this.collection[index]);
                return;
            }

            throw new InvalidOperationException("Invalid Operation!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
