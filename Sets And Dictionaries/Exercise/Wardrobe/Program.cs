using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    public class Program
    {
        public static void Main()
        {
            var inputCount = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < inputCount; i++)
            {
                var clothes = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var color = clothes[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                var clothesTypeCount = wardrobe[color];

                for (int j = 1; j < clothes.Length; j++)
                {
                    if (!clothesTypeCount.ContainsKey(clothes[j]))
                    {
                        clothesTypeCount.Add(clothes[j], 0);
                    }

                    clothesTypeCount[clothes[j]]++;
                }

                wardrobe[color] = clothesTypeCount;
            }

            var clothWanted = Console.ReadLine().Split();

            foreach (var cloth in wardrobe)
            {
                Console.WriteLine($"{cloth.Key} clothes:");

                foreach (var type in cloth.Value)
                {
                    if (cloth.Key != clothWanted[0] || type.Key != clothWanted[1])
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value}");
                    }
                    else
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value} (found!)");
                    }
                }
            }
        }
    }
}
