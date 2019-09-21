using System;
using System.Linq;

namespace ActionPoint
{
    public class Program
    {
        public static void Main()
        {
            var strings = Console.ReadLine().Split();
            Action<string> print;
            print = s => Console.WriteLine(s);
            strings.ToList().ForEach(print);
        }
    }
}
