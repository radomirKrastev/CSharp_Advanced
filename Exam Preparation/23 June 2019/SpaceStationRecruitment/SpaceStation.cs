using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;
        
        public SpaceStation(string name, int capacity)
        {
            this.Capacity = capacity;
            this.Name = name;
            this.data = new List<Astronaut>();
        }

        public int Capacity { get; private set; }
        public string Name { get; private set; }
        public int Count => this.data.Count();

        public void Add(Astronaut astronaut)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (this.data.Any(x => x.Name == name))
            {
                this.data.RemoveAll(x => x.Name == name);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            var output = new StringBuilder();
            output.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                output.AppendLine($"{astronaut}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
