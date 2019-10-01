using System;

namespace CustomDoubleLinkedList
{
    public class Program
    {
        public static void Main()
        {
            var list = new CustomDoublyLinkedList<int>();

            list.AddHead(2);
            list.AddHead(3);
            list.AddTail(5);

            Console.WriteLine();
        }
    }
}
