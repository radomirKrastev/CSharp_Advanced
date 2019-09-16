using System;
using System.Linq;
using System.Collections.Generic;

namespace CitiesByCountryAndContinent
{
    public class Country
    {
        public Country(string name, string city)
        {
            Name = name;
            Cities = new List<string>();
            Cities.Add(city);
        }

        public string Name { get; set; }
        public List<string> Cities { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var inputs = int.Parse(Console.ReadLine());
            var continentsInfo = new Dictionary<string, List<Country>>();

            for (int i = 0; i < inputs; i++)
            {
                var data = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var continent = data[0];
                var countryName = data[1];
                var city = data[2];

                if (!continentsInfo.ContainsKey(continent))
                {
                    continentsInfo.Add(continent, new List<Country>());
                }

                var continentCountries = continentsInfo[continent];
                var country = continentCountries.Where(x => x.Name == countryName).ToArray();

                if (country.Count() > 0)
                {
                    country[0].Cities.Add(city);
                }
                else
                {
                    continentsInfo[continent].Add(new Country(countryName, city));
                }
            }

            foreach (var continent in continentsInfo)
            {
                Console.WriteLine(continent.Key+":");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($" {country.Name} -> {string.Join(", ",country.Cities)}");
                }
            }
        }
    }
}
