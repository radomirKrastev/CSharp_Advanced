using System;
using System.Linq;
using System.Collections.Generic;

namespace TriFunction
{
    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(Console.ReadLine()
                .Split()
                .FirstOrDefault((x=>x.ToCharArray()
                .Select(y=>(int)y).Sum()>=number)));
        }
    }
}
