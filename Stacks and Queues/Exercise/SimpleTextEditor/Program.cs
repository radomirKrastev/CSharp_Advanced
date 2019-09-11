using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    public class Program
    {
        public static void Main()
        {
            var commandsCount = int.Parse(Console.ReadLine());
            var text = string.Empty;
            var lastModification = new Stack<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "1")
                {
                    lastModification.Push(text.ToString());
                    text += command[1];
                }
                else if (command[0] == "2")
                {
                    if (text.Length > 0)
                    {
                        lastModification.Push(text.ToString());
                        var symbolsToRemove = int.Parse(command[1]);
                        if (symbolsToRemove >= text.Length)
                        {
                            text = string.Empty;
                        }
                        else
                        {
                            text.Remove(text.Length - symbolsToRemove - 1, symbolsToRemove);
                        }
                    }
                }
                else if (command[0] == "3")
                {
                    var position = int.Parse(command[1]) - 1;

                    if (position >= 0 && position < text.Length)
                    {
                        Console.WriteLine(text[position]);
                    }
                }
                else
                {
                    text = lastModification.Pop();
                }
            }
        }
    }
}
