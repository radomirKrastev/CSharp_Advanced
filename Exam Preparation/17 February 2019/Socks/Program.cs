using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    public class Program
    {
        public static void Main()
        {
            var leftSocks = new Stack<int>(Console.ReadLine()
                .Split(new string[] { " "},StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse));

            var rightSocks = new Queue<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions
                .RemoveEmptyEntries)
                .Select(int.Parse));

            var pairs = new List<int>();

            while (leftSocks.Any())
            {
                var leftSock = leftSocks.Pop();
                var rightSock = rightSocks.Peek();

                if (leftSock > rightSock)
                {
                    pairs.Add(leftSock + rightSock);
                    rightSocks.Dequeue();
                }
                else if (rightSock > leftSock)
                {
                    continue;
                }
                else
                {
                    rightSocks.Dequeue();
                    leftSocks.Push(++leftSock);
                }
            }

            Console.WriteLine (pairs.OrderByDescending(x => x).First());
            Console.WriteLine(string.Join(" ",pairs));
        }
    }
}
