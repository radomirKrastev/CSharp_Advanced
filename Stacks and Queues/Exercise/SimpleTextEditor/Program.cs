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
                    lastModification.Push(text);
                    text += command[1];
                }
                else if (command[0] == "2")
                {
                    lastModification.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(command[1]));
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
