using System;

namespace GenericBoxOfInt
{
    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var data = int.Parse(Console.ReadLine());
                var item = new Box<int>(data);
                item.ToString();
            }
        }
    }
}
