using System;

namespace DateModify
{
    public class Program
    {
        public static void Main()
        {
            var dateOne = Console.ReadLine();
            var dateTwo = Console.ReadLine();

            var dayModifier = new DateModifier();
            var daysDifference = dayModifier.GetDaysDifference(dateOne, dateTwo);
            Console.WriteLine(daysDifference);
        }
    }
}
