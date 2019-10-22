using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine("Item:");
            output.AppendLine($"  * Strength: {this.Strength}");
            output.AppendLine($"  * Ability: {this.Ability}");
            output.AppendLine($"  * Intelligence: {this.Intelligence}");

            return output.ToString().TrimEnd();
        }
    }
}
