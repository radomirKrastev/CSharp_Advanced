using System;

namespace GenericBoxOfString
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
