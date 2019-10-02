using System;

namespace GenericArrayCreator
{
    public class Program
    {
        public static void Main()
        {
            var strings = new ArrayCreator<string>();

            string[] stringsArr = new ArrayCreator<string>().Create(5, "Gosho");

            Console.WriteLine(string.Join(" ",stringsArr));
        }
    }
}
