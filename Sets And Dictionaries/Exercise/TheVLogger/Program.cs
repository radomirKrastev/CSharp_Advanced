using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    public class Vlogger
    {
        public Vlogger()
        {
            Subs = new HashSet<string>();
            Follows = new HashSet<string>();
        }

        public HashSet<string> Subs { get; set; }
        public HashSet<string> Follows { get; set; }        
    }

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var theVLogger = new Dictionary<string, Vlogger>();

            while (input != "Statistics")
            {
                var command = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = command[1];
                var currentVlogger = command[0];

                switch (action)
                {
                    case "joined":
                        if (!theVLogger.ContainsKey(currentVlogger))
                        {
                            theVLogger.Add(currentVlogger, new Vlogger());
                        }
                        break;
                    case "followed":
                        var followedVlogger = command[2];
                        if(theVLogger.ContainsKey(currentVlogger)&& theVLogger.ContainsKey(followedVlogger))
                        {
                            if (currentVlogger != followedVlogger)
                            {
                                theVLogger[followedVlogger].Subs.Add(currentVlogger);
                                theVLogger[currentVlogger].Follows.Add(followedVlogger);
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {theVLogger.Count} vloggers in its logs.");
            
            var counter = 1;
            foreach (var vlogger in theVLogger.OrderByDescending(x => x.Value.Subs.Count()).ThenBy(x => x.Value.Follows.Count()))
            {
                var username = vlogger.Key;
                var subsCount = vlogger.Value.Subs.Count();
                var followsCount = vlogger.Value.Follows.Count();

                if (counter == 1)
                {
                    Console.WriteLine($"{counter++}. {username} : {subsCount} followers, {followsCount} following");

                    foreach (var sub in vlogger.Value.Subs.OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {sub}");
                    }
                }
                else
                {
                    Console.WriteLine($"{counter++}. {username} : {subsCount} followers, {followsCount} following");
                }
            }            
        }
    }
}
