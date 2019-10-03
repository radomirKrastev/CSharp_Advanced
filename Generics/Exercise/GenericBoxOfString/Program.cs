using System;

namespace GenericBoxOfString
{
    public class Program
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var data = Console.ReadLine();
                var item = new Box<string>(data);
                item.ToString();
            }
        }
    }
}
