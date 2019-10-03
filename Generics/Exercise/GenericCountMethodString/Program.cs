using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodString
{
    public class Program 
    {        
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());
            var strings = new Box<string>();

            for (int i = 0; i < linesCount; i++)
            {
                strings.Add(Console.ReadLine());
            }

            var comparer = Console.ReadLine();
            Console.WriteLine(strings.Compare(comparer));
        }
    }
}
