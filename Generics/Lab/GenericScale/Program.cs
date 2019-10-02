using System;

namespace GenericScale
{
    public class Program
    {
        public static void Main()
        {
            var leftItem = 5;
            var rightItem = 5;

            var scale = new EqualityScale<int>(leftItem, rightItem);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
