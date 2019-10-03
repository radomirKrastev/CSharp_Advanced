
namespace Threeuple
{
    public class Tuple<T, K, X>
    {
        private T item1;
        private K item2;
        private X item3;

        public Tuple(T itemOne, K itemTwo, X itemThree)
        {
            this.item1 = itemOne;
            this.item2 = itemTwo;
            this.item3 = itemThree;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }
    }
}
