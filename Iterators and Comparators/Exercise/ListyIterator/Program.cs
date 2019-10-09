using System;
using System.Linq;
using System.Collections.Generic;

namespace ListyIterator
{
    public class Program 
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var listyOperator = new ListyIterator<string>(new List<string>());

            while (command != "END")
            {
                var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Create")
                {
                    if (tokens.Length>1)
                    {
                        var listTokens = tokens.ToList();
                        listTokens.RemoveAt(0);
                        listyOperator = new ListyIterator<string>(new List<string>(listTokens));
                    }
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listyOperator.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyOperator.HasNext());                    
                }
                else if (command == "Print")
                {
                    listyOperator.Print();
                }

                command = Console.ReadLine();
            }
        }
    }
}
