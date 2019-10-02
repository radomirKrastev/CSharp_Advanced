using System;

namespace GenericArrayCreator
{
    public class Program
    {
        public static void Main()
        {

            string[] strings = ArrayCreator.Create(5, "11");
            int[] arr = ArrayCreator.Create(10, 11);


            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
