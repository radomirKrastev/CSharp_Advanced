﻿using System;

namespace CustomList
{
    public class Program
    {
        public static void Main()
        {
            var customList = new CustomList<int>();

            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            customList.Add(7);
            customList.Add(8);
            customList.Add(9);

            var a = customList.RemoveAt(1);
            var b = customList.RemoveAt(4);
            var c = customList.RemoveAt(5);
            var d = customList.RemoveAt(0);
            var e = customList.RemoveAt(1);
            var f = customList.RemoveAt(1);


            Console.WriteLine();
        }
    }
}
