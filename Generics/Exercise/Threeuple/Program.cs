using System;

namespace Threeuple
{
    public class Program
    {
        public static void Main()
        {
            var personInformation = Console.ReadLine().Split();
            var name = personInformation[0] + " " + personInformation[1];
            var adress = personInformation[2];
            var town = personInformation[3];
            var firstTuple = new Tuple<string, string,string>(name, adress,town);

            var personalBeerInformation = Console.ReadLine().Split();
            var secondName = personalBeerInformation[0];
            var state = personalBeerInformation[2];
            var beerTolerance = int.Parse(personalBeerInformation[1]);
            var secondTuple = new Tuple<string, int,bool>(secondName, beerTolerance,state=="drunk"?true:false);

            var bankInformation = Console.ReadLine().Split();
            var accountName = bankInformation[0];
            var balance = double.Parse(bankInformation[1]);
            string bankName = bankInformation[2];
            var thirdTuple = new Tuple<string, double,string>(accountName, balance,bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
