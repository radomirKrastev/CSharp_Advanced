using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public T[] Create<T> (int length, T element)
        {
            var elements = new T[length];

            for (int i = 0; i < length; i++)
            {
                elements[i] = element;
            }

            return elements;
        }
    }
}
