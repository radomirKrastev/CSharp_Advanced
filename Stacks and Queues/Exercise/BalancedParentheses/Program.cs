using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    public class Program
    {
        public static void Main()
        {
            var parentheses = Console.ReadLine();
            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            else if (parentheses[0] == ')' || parentheses[0] == '}' || parentheses[0] == ']')
            {
                Console.WriteLine("NO");
                return;
            }
            else if (parentheses[parentheses.Length - 1] == '('
                || parentheses[parentheses.Length - 1] == '{'
                || parentheses[parentheses.Length - 1] == '[')
            {
                Console.WriteLine("NO");
                return;
            }
            else
            {
                var openingBrackets = new Stack<char>();
                for (int i = 0; i < parentheses.Length; i++)
                {
                    if (parentheses[i] == '(' || parentheses[i] == '{' || parentheses[i] == '[')
                    {
                        openingBrackets.Push(parentheses[i]);
                    }
                    else
                    {
                        var openingBracket = openingBrackets.Pop();

                        if (parentheses[i] == ')')
                        {
                            if (openingBracket != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else if (parentheses[i] == '}')
                        {
                            if (openingBracket != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else
                        {
                            if (openingBracket != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                    }
                }

                Console.WriteLine("YES");
            }    
        }
    }
}
