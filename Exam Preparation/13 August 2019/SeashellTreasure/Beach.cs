
using System.Text;

namespace SeashellTreasure
{
    public class Beach
    {
        public Beach(int rows)
        {
            this.Matrix = new char[rows][];
        }

        public char[][] Matrix { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (var row in this.Matrix)
            {
                output.AppendLine(string.Join(" ",row));
            }

            return output.ToString().TrimEnd();
        }
    }
}
