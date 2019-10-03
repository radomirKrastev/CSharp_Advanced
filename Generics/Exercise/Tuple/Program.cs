using System;

namespace Tuple
{
    public class Program
    {
        public static void Main()
        {
            var personInformation = Console.ReadLine().Split();
            var name = personInformation[0] + " " + personInformation[1];
            var adress = personInformation[2];
            var firstTuple = new Tuple<string, string>(name, adress);

            var personalBeerInformation = Console.ReadLine().Split();
            var secondName = personalBeerInformation[0];
            var beerTolerance = int.Parse(personalBeerInformation[1]);
            var secondTuple = new Tuple<string, int>(secondName, beerTolerance);

            var numberInformation = Console.ReadLine().Split();
            int integerNumber = int.Parse(numberInformation[0]);
            double doubleNumber = double.Parse(numberInformation[1]);
            var thirdTuple = new Tuple<int, double>(integerNumber, doubleNumber);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
