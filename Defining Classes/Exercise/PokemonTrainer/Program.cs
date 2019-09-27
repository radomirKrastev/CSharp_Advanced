using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var trainers = new List<Trainer>();
            while (command != "Tournament")
            {
                var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var trainerName = tokens[0];
                var pokemonName = tokens[1];
                var pokemonElement = tokens[2];
                var pokemonHealth= int.Parse(tokens[3]);

                if (trainers.Select(x => x.Name).Contains(trainerName))
                {
                    Trainer currentTrainer = trainers.First(x => x.Name == trainerName);
                    currentTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                else
                {
                    Trainer currentTrainer = new Trainer(trainerName);
                    currentTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(currentTrainer);
                }

                command = Console.ReadLine();
            }

            var element = Console.ReadLine();

            while (element != "End")
            {
                foreach (var trainer in trainers)
                {
                    Func<List<Pokemon>, bool> elementIsContained = x => x.Select(y => y.Element).Contains(element);
                    if (elementIsContained(trainer.Pokemons))
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons.RemoveAll(x => x.Health <= 10);
                    }
                }

                element = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
