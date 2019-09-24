using System;
using System.Linq;
using System.Collections.Generic;

namespace PartyReservationFilterModule
{
    public class Program
    {
        public static void Main()
        {
            var guests = Console.ReadLine().Split().ToList();
            var command = Console.ReadLine();
            var filters = new HashSet<string>();

            while (command != "Print")
            {
                var tokens = command.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                var commandType = tokens[0];
                var criteria = tokens[1];
                var parameter = tokens[2];
                var setCommand = criteria + ';' + parameter;

                if (commandType == "Add filter")
                {
                    filters.Add(setCommand);
                }
                else if (commandType == "Remove filter")
                {
                    filters.Remove(setCommand);
                }

                command = Console.ReadLine();
            }

            Func<string, string, bool> filterPredicate;

            foreach (var filter in filters)
            {
                var criteria = filter.Split(";")[0];
                var parameter = filter.Split(";")[1];

                filterPredicate = GetFunc(criteria);
                var filteredGuests = guests.Where(x => filterPredicate(x, parameter)==false).ToList();
                guests = filteredGuests;
            }

            Console.WriteLine(string.Join(" ",guests));
        }

        public static Func<string, string, bool> GetFunc(string criteria)
        {
            if (criteria == "Starts with")
            {
                return (n, p) => n.StartsWith(p);
            }
            else if (criteria == "Ends with")
            {
                return (n, p) => n.EndsWith(p);
            }
            else if (criteria == "Length")
            {
                return (n, p) => n.Length==int.Parse(p);
            }
            else if (criteria == "Contains")
            {
                return (n, p) => n.Contains(p);
            }
            else
            {
                return null;
            }
        }
    }
}
