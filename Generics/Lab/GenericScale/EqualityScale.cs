namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T leftElement;
        private T rightElement;

        public EqualityScale(T leftElement,T rightElement)
        {
            this.leftElement = leftElement;
            this.rightElement = rightElement;
        }

        public bool AreEqual()
        {
            var result = leftElement.Equals(rightElement);
            return result;
        }
    }
}
