namespace NBAFutureStars
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
            var sourceFilePath = Console.ReadLine();
            var maximumYearsPlayed = int.Parse(Console.ReadLine());
            var minimumRequiredRating = double.Parse(Console.ReadLine());
            var destinationFilePath = Console.ReadLine();

            var fileDataString = File.ReadAllText(sourceFilePath);
            var playersList = JsonConvert.DeserializeObject<List<Player>>(fileDataString);            

            var currentYear = DateTime.Now.Year;

            Func<int, double, bool> qualifyValidator = (x, y) =>
            currentYear - x < maximumYearsPlayed 
            && y > minimumRequiredRating;

            var futureStars = playersList
                .Where((x) => qualifyValidator(x.PlayerSince, x.Rating))
                .ToList();

            var output = GetOutput(futureStars);

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
            var output = new List<string> { "Name,Rating" };

            foreach (var futureStar in futureStars.OrderByDescending(x => x.Rating).ThenBy(x => x.Name))
            {
                output.Add($"{futureStar.Name}, {futureStar.Rating}");
            }

            return output;
        }
    }
}
