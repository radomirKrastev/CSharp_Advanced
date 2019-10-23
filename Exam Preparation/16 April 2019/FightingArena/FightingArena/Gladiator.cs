using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name { get; private set; }
        public Stat Stat { get; private set; }
        public Weapon Weapon { get; private set; }
        public int StatPower => GetStatPower();
        public int WeaponPower => GetWeaponPower();
        public int TotalPower => GetTotalPower();

        public int GetTotalPower()
        {
            return GetWeaponPower() + GetStatPower();
        }

        public int GetStatPower()
        {
            return this.Stat.Agility
                + this.Stat.Flexibility
                + this.Stat.Intelligence
                + this.Stat.Skills
                + this.Stat.Strength;
        }

        public int GetWeaponPower()
        {
            return this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"[{this.Name}] - [{GetTotalPower()}]");
            output.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            output.AppendLine($"  Stat Power: [{GetStatPower()}]");

            return output.ToString().TrimEnd();
        }
    }
}
