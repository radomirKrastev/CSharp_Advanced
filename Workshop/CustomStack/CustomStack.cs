using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T>
    {
        private int initialCapacity = 4;

        private T[] elements;

        public CustomStack()
        {
            this.elements = new T[initialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                Resize();
            }

            this.elements[this.Count++] = element;
        }
        
        public T Pop()
        {
            ValidateIfListIsEmpty();

            var element = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;
            return element;
        }

        public T Peak()
        {
            ValidateIfListIsEmpty();

            var element = this.elements[this.Count - 1];
            return element;
        }

        public void Foreach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.elements[i]);
            }
        }

        private void Resize()
        {
            var newArray = new T[this.Count * 2];
            Array.Copy(this.elements, newArray, this.Count);
            this.elements = newArray;
        }

        private void ValidateIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}
