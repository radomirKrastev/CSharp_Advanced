using System;
using System.Linq;

namespace PredicateForNames
{
    public class Program
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            Console.ReadLine().Split().Where(x => x.Length <= length).ToList().ForEach(Console.WriteLine);
        }
    }
}
