using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Person
    {
        private string name;
        private Company company;
        private List<Pokemon> pokemonCollection = new List<Pokemon>();
        private List<Parent> parents = new List<Parent>();
        private List<Child> children = new List<Child>();
        private Car car;

        public string Name => this.name;

        public Company Company
        {
            get=> this.company;
            set { this.company = value; }
        }

        public List<Pokemon> PokemonCollection
        {
            get => this.pokemonCollection;
            set { this.pokemonCollection = value; }
        }

        public List<Parent> Parents
        {
            get => this.parents;
            set { this.parents = value; }
        }

        public List<Child> Children
        {
            get => this.children;
            set { this.children = value; }
        }

        public Car Car
        {
            get => this.car;
            set { this.car = value; }
        }

        public Person (string name)
        {
            this.name = name;
        }
    }
}
