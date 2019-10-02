using System;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<int>();
            box.Add(5);
            box.Add(6);
            box.Add(7);

            Console.WriteLine();
            var count = box.Count;

            box.Remove();
            box.Remove();

            count = box.Count;

            Console.WriteLine();

            box.Remove();
            box.Remove();
        }
    }
}
