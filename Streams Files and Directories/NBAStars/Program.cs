namespace NBAStars
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class Program
    {
        public static void Main()
        {
            string sourceFilePath = Console.ReadLine();
            int maximumYearsPlayed = int.Parse(Console.ReadLine());
            double minimumRequiredRating = double.Parse(Console.ReadLine());
            string destinationFilePath = Console.ReadLine();

            string fileDataString = File.ReadAllText(sourceFilePath);
            List<Player> playersList = JsonConvert.DeserializeObject<List<Player>>(fileDataString);

            int currentYear = DateTime.Now.Year;

            Func<int, double, bool> qualifyValidator = (playerSince, rating) =>
            currentYear - playerSince < maximumYearsPlayed
            && rating > minimumRequiredRating;

            List<Player> futureStars = playersList
                .Where((x) => qualifyValidator(x.PlayerSince, x.Rating))
                .ToList();

            List<string> output = GetOutput(futureStars);

            GenerateCSV(destinationFilePath, output);
        }

        private static void GenerateCSV(string destinationFilePath, List<string> output)
        {
            if (destinationFilePath.EndsWith(".csv"))
            {
                File.AppendAllLines(@destinationFilePath, output);
            }
            else
            {
                File.AppendAllLines(@destinationFilePath + @"FutureStarsReport.csv", output);
            }
        }

        private static List<string> GetOutput(List<Player> futureStars)
        {
            List<string> output = new List<string> { "Name,Rating" };

            foreach (Player futureStar in futureStars.OrderByDescending(x => x.Rating).ThenBy(x => x.Name))
            {
                output.Add($"{futureStar.Name}, {futureStar.Rating}");
            }

            return output;
        }
    }
}
