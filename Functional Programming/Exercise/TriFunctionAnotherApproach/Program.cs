using System;
using System.Linq;
using System.Collections.Generic;

namespace TriFunctionAnotherApproach
{
    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            Func<string, char[]> getCharArr = x => x.ToCharArray();
            Func<char, int> getCharValue= y => (int)y;
            Func<string, bool> isValueValid = x=>getCharArr(x).Select(getCharValue).Sum() >= number;

            Console.WriteLine(Console.ReadLine().Split().FirstOrDefault(isValueValid));
        }
    }
}
