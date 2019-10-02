using System;
using System.Collections.Generic;

namespace CustomList
{
    public class Program
    {
        public static void Main()
        {
            var customList = new CustomList<int>();

            customList.Add(1);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            customList.Add(7);
            //customList.Add(8);
            //customList.Add(9);

            //var a = customList.RemoveAt(1);
            //var b = customList.RemoveAt(4);
            //var c = customList.RemoveAt(5);
            //var d = customList.RemoveAt(0);
            //var e = customList.RemoveAt(1);
            //var f = customList.RemoveAt(1);

            //customList.Insert(5, 15);
            //Console.WriteLine(customList.Contains(8));

            //var list = new List<int>() { 1, 2, 3 };

            //var foundElement = list.Find(x=>x+1==2);
            //Console.WriteLine(foundElement);

            //customList.Swap(7, 1);

            var found= customList.Find(x => x + 2 == 10);
            customList.Reverse();
            Console.WriteLine(found);
        }
    }
}
