using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    public class Program
    {
        public static void Main()
        {
            var waves = int.Parse(Console.ReadLine());

            var plates = new List<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var trojans = new Stack<int>();

            for (int wave = 1; wave <= waves; wave++)
            {
                var trojanWave = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (wave % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                foreach (var trojanWarrior in trojanWave)
                {
                    trojans.Push(trojanWarrior);
                }

                while (trojans.Any() && plates.Any())
                {
                    var trojan = trojans.Pop();

                    if (trojan > plates[0])
                    {
                        var destroyedPlate = plates[0];
                        trojan -= destroyedPlate;
                        plates.RemoveAt(0);
                        trojans.Push(trojan);
                    }
                    else if (trojan == plates[0])
                    {
                        trojan = 0;
                        plates.RemoveAt(0);
                    }
                    else if (trojan < plates[0])
                    {
                        plates[0] -= trojan;
                        trojan = 0;
                    }
                }

                if (!plates.Any())
                {
                    Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                    Console.WriteLine($"Warriors left: {string.Join(", ", trojans)}");
                    return;
                }
            }

            if (!trojans.Any())
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
