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
            list.AddTail(6);
            list.AddTail(7);
            list.AddHead(10);

            //var i = list.RemoveHead();
            //var j = list.RemoveHead();
            //var k = list.RemoveTail();
            //var l = list.RemoveTail();
            //var h = list.RemoveTail();
            //var g = list.RemoveTail();

            //Console.WriteLine(l);
            //Console.WriteLine(list.Head.Value);
            Console.WriteLine();
            list.ForEach(n => Console.WriteLine(n));
            var arr = list.ToArray();
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
