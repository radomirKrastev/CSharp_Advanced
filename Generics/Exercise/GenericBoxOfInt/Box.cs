using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInt
{
    public class Box<T>
    {
        private T element;

        public Box(T value)
        {
            this.element = value;
        }

        public void ToString()
        {
            Console.WriteLine($"{element.GetType()}: {element}");
        }
    }
}
