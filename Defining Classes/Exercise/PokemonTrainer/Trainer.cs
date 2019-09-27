using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badgesCount = 0;
        private List<Pokemon> pokemons = new List<Pokemon>();

        public string Name => this.name;

        public int BadgesCount
        {
            get => this.badgesCount;
            set
            {
                this.badgesCount=value;
            }
        }

        public List<Pokemon> Pokemons
        {
            get => this.pokemons;
            set
            {
                this.Pokemons = value;
            }
        }

        public Trainer(string name)
        {
            this.name = name;
        }
    }
}
