using System.Collections.Generic;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }
        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            gladiators.RemoveAll(x => x.Name == name);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return this.gladiators.OrderByDescending(x => x.StatPower).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return this.gladiators.OrderByDescending(x => x.WeaponPower).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return this.gladiators.OrderByDescending(x => x.TotalPower).FirstOrDefault();
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
