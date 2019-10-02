using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomList
{
    public class CustomList<T>
    {
        private T[] elements;
        private const int initialCapacity = 2;

        public CustomList()
        {
            this.elements = new T[initialCapacity];
        }

        public int Count { get; private set; }


        public T this [int index]
        {
            get
            {
                ValidateIndexIsOutOfRange(index);

                return this.elements[index];
            }
            set
            {
                ValidateIndexIsOutOfRange(index);

                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.elements.Length)
            {
                Resize();
            }

            this.elements[this.Count++] = element;
        }

        public T RemoveAt(int index)
        {
            ValidateIndexIsOutOfRange(index);

            var value = elements[index];
            elements[index] = default(T);
            Shift(index);
            if (--this.Count * 4 <= this.elements.Length)
            {
                Shrink();
            }

            return value;
        }

        public void Insert(int index, T element)
        {
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == 0 && index == 0)
            {
                this.elements[this.Count++] = element;
                return;
            }

            Add(this.elements[this.Count - 1]);

            for (int i = this.Count-2; i >index ; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
        }

        public bool Contains(T element)
        {
            var containsElement = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    containsElement = true;
                    break;
                }
            }

            return containsElement;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndexIsOutOfRange(firstIndex);
            ValidateIndexIsOutOfRange(secondIndex);

            var firstElement = this.elements[firstIndex];
            var secondElement = this.elements[secondIndex];

            this.elements[secondIndex] = firstElement;
            this.elements[firstIndex] = secondElement;
        }

        public T Find(Predicate<T> predicate)
        {
            var element = default(T);

            for (int i = 0; i < this.Count; i++)
            {
                if (predicate(this.elements[i]))
                {
                    element = this.elements[i];
                }
            }

            return element;
        }

        private void Shrink()
        {
            T[] newArray = new T[this.elements.Length / 4];
            Array.Copy(this.elements, newArray, newArray.Length);
            this.elements = newArray;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.elements.Length-1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
        }

        private void Resize()
        {
            T[] newArray = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newArray, elements.Length);
            this.elements= newArray;
        }

        private void ValidateIndexIsOutOfRange(int index)
        {
            if (index >= this.Count || index<0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
