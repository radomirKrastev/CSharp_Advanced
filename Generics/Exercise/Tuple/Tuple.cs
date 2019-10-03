using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T,K>
    {
        private T item1;
        private K item2;

        public Tuple(T itemOne,K itemTwo)
        {
            this.item1 = itemOne;
            this.item2 = itemTwo;
        }

        public override string ToString()
        {
           return $"{this.item1} -> {this.item2}";
        }
    }
}
