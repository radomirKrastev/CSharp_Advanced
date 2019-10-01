using System;
using System.Collections.Generic;
using System.Text;

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
            if (--this.Count * 4 == this.elements.Length)
            {
                Shrink();
            }

            return value;
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
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
