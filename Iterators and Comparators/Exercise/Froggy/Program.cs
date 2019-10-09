using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        public static void Main()
        {
            var lake = new Lake(Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
