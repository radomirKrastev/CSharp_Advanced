using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    public class Program
    {
        public static void Main()
        {
            var guests = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine();
            Func<string, string, bool> guestsPredicate;            

            while (command != "Party!")
            {
                var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var doubleOrRemove = tokens[0];
                var criteria = tokens[1];
                var parameters = tokens[2];

                guestsPredicate = GetFunc(criteria);
                var additionalGuests = new List<string>();

                if (doubleOrRemove == "Double")
                {
                    additionalGuests = guests.Where(x => guestsPredicate(x, parameters)).ToList();

                    foreach (var guest in additionalGuests)
                    {
                        var index = guests.IndexOf(guest);
                        if (index == guests.Count - 1)
                        {
                            guests.Add(guest);
                        }
                        else
                        {
                            guests.Insert(index + 1, guest);
                        }
                    }
                }
                else
                {   
                    additionalGuests = guests.Where(x=>guestsPredicate(x,parameters)==false).ToList();
                    guests = additionalGuests;
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine(guests.Any()? string.Join(", ", guests) + " are going to the party!"
                : "Nobody is going to the party!");
        }

        public static Func<string,string,bool> GetFunc(string criteria)
        {
            if (criteria == "StartsWith")
            {
                return (x,c) => x.StartsWith(c);
            }
            else if (criteria == "EndsWith")
            {
                return (x, c) => x.EndsWith(c);
            }
            else if (criteria == "Length")
            {
                return (x, c) => x.Length==int.Parse(c);
            }
            else
            {
                return null;
            }
        }
    }
}
