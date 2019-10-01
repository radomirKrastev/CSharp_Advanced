using System;

namespace CustomDoubleLinkedList
{
    public class Program
    {
        public static void Main()
        {
            var list = new CustomDoublyLinkedList<int>();

            //list.AddHead(2);
            //list.AddHead(3);
            //list.AddTail(5);
            //list.AddTail(6);
            //list.AddTail(7);
            //list.AddHead(10);

            var i= list.RemoveHead();
            //var j= list.RemoveHead();

            Console.WriteLine();
        }
    }
}
