using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftuniParty
{
    public class Program
    {
        public static void Main()
        {
            var partyGuest = Console.ReadLine();
            var vipGuests = new HashSet<string>();
            var regularGuests = new HashSet<string>();

            while (partyGuest != "PARTY")
            {
                if (partyGuest.Count() == 8)
                {
                    if (Char.IsDigit(partyGuest[0]))
                    {
                        vipGuests.Add(partyGuest);
                    }
                    else
                    {
                        regularGuests.Add(partyGuest);
                    }
                }               

                partyGuest = Console.ReadLine();
            }

            var guestComing = Console.ReadLine();

            while (guestComing != "END")
            {
                vipGuests.Remove(guestComing);
                regularGuests.Remove(guestComing);
                guestComing = Console.ReadLine();
            }

            var guestsAbsent = vipGuests.Count()+regularGuests.Count();
            Console.WriteLine(guestsAbsent);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
