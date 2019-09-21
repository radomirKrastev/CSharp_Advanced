using System;
using System.Linq;

namespace KnightsOfHonor
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new string[] { " ", "  " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>$"Sir {x}")
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
