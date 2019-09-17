using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSymbols
{
    public class Program
    {
        public static void Main()
        {
            var symbolCount = new Dictionary<char, int>();
            var text = Console.ReadLine();

            foreach (var ch in text)
            {
                if (!symbolCount.ContainsKey(ch))
                {
                    symbolCount.Add(ch, 0);
                }

                symbolCount[ch]++;
            }

            foreach (var symbol in symbolCount.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
