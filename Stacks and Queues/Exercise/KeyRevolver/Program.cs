using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    public class Program
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelCapacity = int.Parse(Console.ReadLine());
            var ammo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locksInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var intelligenceValue = int.Parse(Console.ReadLine());

            var locks = new Queue<int>(locksInfo);
            var bullets = new Stack<int>(ammo);
            var bulletsUsed = 0;

            while (locks.Any())
            {
                if (bullets.Any())
                {
                    if (bulletsUsed % barrelCapacity == 0 && bulletsUsed>0)
                    {
                        Console.WriteLine("Reloading!");
                    }

                    var bullet = bullets.Pop();

                    if (bullet <= locks.Peek())
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                        bulletsUsed++;
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                        bulletsUsed++;
                    }
                }
                else
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
                    return;
                }
            }

            if (bullets.Any())
            {
                if (bulletsUsed % barrelCapacity == 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            var bulletsLeft = ammo.Count() - bulletsUsed;
            var moneyEarned = intelligenceValue - (bulletsUsed * bulletPrice);
            Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
        }
    }
}
