using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine();


            while (command != "end")
            {
                Func<string,List<int>, List<int>> calculation = Calculation;
                numbers = calculation(command, numbers);
                command = Console.ReadLine();
            }
        }

        public static List<int> Calculation(string command, List<int> numbers)
        {
            if (command == "add")
            {
                numbers= numbers.Select(x => x + 1).ToList();
            }
            else if (command == "subtract")
            {
                numbers = numbers.Select(x => x - 1).ToList();
            }
            else if (command == "multiply")
            {
                numbers = numbers.Select(x => x * 2).ToList();
            }
            else if (command == "print")
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

            return numbers;
        }
    }
}
