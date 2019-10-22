using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    public class Program
    {
        public static void Main()
        {
            var hallCapacity = int.Parse(Console.ReadLine());

            var halls = new Queue<char>();

            var hallsAndReservations = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            hallsAndReservations.Reverse();

            var hallGuests = new List<int>();

            foreach (var item in hallsAndReservations)
            {
                if (int.TryParse(item, out int guests))
                {
                    if (!halls.Any())
                    {
                        continue;
                    }

                    if (hallGuests.Sum() + guests > hallCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hallGuests)}");
                        hallGuests.Clear();
                    }

                    if (halls.Any())
                    {
                        hallGuests.Add(guests);
                    }
                }
                else if (char.TryParse(item, out char result))
                {
                    halls.Enqueue(result);
                }
            }
        }
    }
}
