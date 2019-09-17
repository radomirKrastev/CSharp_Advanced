using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    public class Program
    {
        public static void Main()
        {
            var namesCount = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();

            for (int i = 0; i < namesCount; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
