using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    public class Program
    {
        public static void Main()
        {
            var inputsCount = int.Parse(Console.ReadLine());
            var uniqueUsernames = new HashSet<string>();

            for (int i = 0; i < inputsCount; i++)
            {
                var username = Console.ReadLine();

                uniqueUsernames.Add(username);
            }

            foreach (var username in uniqueUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
