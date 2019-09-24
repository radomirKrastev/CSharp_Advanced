using System;
using System.Linq;
using System.Collections.Generic;

namespace SongsQueue
{
    public class Program
    {
        public static void Main()
        {
            var songs = new Queue<string>(Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));

            while (songs.Any())
            {
                var command = Console.ReadLine().Split(new string[] { "Add " }, StringSplitOptions.RemoveEmptyEntries);

                if(command[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    var song = command[0];
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                
            }

            Console.WriteLine($"No more songs!");
        }
    }
}
