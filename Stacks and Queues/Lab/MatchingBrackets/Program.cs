using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var openBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBrackets.Push(i);
                }
                else if(input[i] == ')')
                {
                    var start = openBrackets.Pop();
                    var length = i - start +1;
                    var expression = input.Substring(start, length);
                    Console.WriteLine(expression);
                }
            }          
        }
    }
}
