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
            Func<string, List<string>, List<string>> guestsProcessing = DoubleOrRemove;

            while (command != "Party!")
            {
                guests= guestsProcessing(command, guests);
                command = Console.ReadLine();
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        public static List<string> DoubleOrRemove(string command, List<string> guests)
        {
            var token = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var doubleOrRemove = token[0];
            var criteria = token[1];
            var parameters = token[2];
            var processedGuestList = new List<string>();

            switch (doubleOrRemove)
            {
                case "Double":
                    {
                        if(criteria== "StartsWith")
                        {
                            foreach (var guest in guests)
                            {
                                processedGuestList.Add(guest);
                                if (guest.StartsWith(parameters))
                                {
                                    processedGuestList.Add(guest);
                                }
                            }
                        }
                        else if(criteria == "EndsWith")
                        {
                            foreach (var guest in guests)
                            {
                                processedGuestList.Add(guest);
                                if (guest.EndsWith(parameters))
                                {
                                    processedGuestList.Add(guest);
                                }
                            }
                        }
                        else
                        {
                            var length = int.Parse(parameters);
                            foreach (var guest in guests)
                            {
                                processedGuestList.Add(guest);
                                if (guest.Length==length)
                                {
                                    processedGuestList.Add(guest);
                                }
                            }
                        }
                    }
                    break;
                case "Remove":
                    {
                        if (criteria == "StartsWith")
                        {
                            processedGuestList.AddRange(guests.Where(s => s.StartsWith(parameters)==false));
                        }
                        else if (criteria == "EndsWith")
                        {
                            processedGuestList.AddRange(guests.Where(s => s.EndsWith(parameters)==false));
                        }
                        else
                        {
                            var length = int.Parse(parameters);
                            processedGuestList.AddRange(guests.Where(s => s.Length != length));
                        }
                    }
                    break;
            }

            return processedGuestList;
        }
    }
}
