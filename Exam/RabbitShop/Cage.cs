using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count();

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var rabbit = this.data.Where(x => x.Name == name).FirstOrDefault();

            if (rabbit != null)
            {
                this.data.Remove(rabbit);
                return true;
            }

            return false;
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbit = this.data.Where(x => x.Name == name).FirstOrDefault();

            if (rabbit != null)
            {
                rabbit.Available = false;
            }

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbits = new List<Rabbit>();

            foreach (var rabbit in this.data.Where(x=>x.Species==species))
            {
                rabbits.Add(rabbit);
                rabbit.Available = false;
            }

            return rabbits.ToArray();
        }

        public string Report()
        {
            var output = new StringBuilder();

            output.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.data.Where(x=>x.Available==true))
            {
                output.AppendLine($"{rabbit.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
