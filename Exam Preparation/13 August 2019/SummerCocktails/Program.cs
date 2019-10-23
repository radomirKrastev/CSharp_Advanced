using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerCocktails
{
    public class Program
    {
        public static void Main()
        {
            var ingredients = new Queue<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var ingredientsFreshness = new Stack<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var cocktails = new Dictionary<string, int>();

            while(ingredients.Any() && ingredientsFreshness.Any())
            {
                var ingredient = ingredients.Dequeue();

                if (ingredient == 0)
                {
                    continue;
                }

                var freshness = ingredientsFreshness.Pop();
                var product = ingredient * freshness;

                PrepareCocktail(product, cocktails, ingredients, ingredient);
            }

            if(GetTaskComplete(cocktails))
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var cocktail in cocktails.Where(x=>x.Value>0).OrderBy(x=>x.Key))
            {
                Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
            }
        }

        private static void PrepareCocktail(int product, Dictionary<string,int> cocktails, Queue<int> ingredients, int ingredient)
        {
            if (product == (int)Cocktails.Mimosa)
            {
                var cocktail = Cocktails.Mimosa.ToString();

                if (!cocktails.ContainsKey(cocktail))
                {
                    cocktails.Add(cocktail, 0);
                }

                cocktails[cocktail]++;
            }
            else if (product == (int)Cocktails.Daiquiri)
            {
                var cocktail = Cocktails.Daiquiri.ToString();

                if (!cocktails.ContainsKey(cocktail))
                {
                    cocktails.Add(cocktail, 0);
                }

                cocktails[cocktail]++;
            }
            else if (product == (int)Cocktails.Sunshine)
            {
                var cocktail = Cocktails.Sunshine.ToString();

                if (!cocktails.ContainsKey(cocktail))
                {
                    cocktails.Add(cocktail, 0);
                }

                cocktails[cocktail]++;
            }
            else if (product == (int)Cocktails.Mojito)
            {
                var cocktail = Cocktails.Mojito.ToString();

                if (!cocktails.ContainsKey(cocktail))
                {
                    cocktails.Add(cocktail, 0);
                }

                cocktails[cocktail]++;
            }
            else
            {
                ingredient += 5;
                ingredients.Enqueue(ingredient);
            }
        }

        private static bool GetTaskComplete(Dictionary<string,int> cocktails)
        {
            return cocktails.Count == 4;
        }
    }
}
