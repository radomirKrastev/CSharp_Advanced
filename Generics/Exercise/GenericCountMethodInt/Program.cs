using System;

namespace GenericCountMethodInt
{
    public class Program
    {
        public static void Main()
        {
            var linesCount = double.Parse(Console.ReadLine());
            var doubles = new Box<double>();

            for (double i = 0; i < linesCount; i++)
            {
                var item = double.Parse(Console.ReadLine());
                doubles.Add(item);
            }

            var comparer =double.Parse(Console.ReadLine());
            Console.WriteLine(doubles.Count(comparer));
        }
    }
}
