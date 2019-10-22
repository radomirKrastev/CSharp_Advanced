using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append($"Hero: {this.Name} – {this.Level}lvl");
            output.AppendLine();
            output.Append(this.Item.ToString());

            return output.ToString().TrimEnd();
        }
    }
}
