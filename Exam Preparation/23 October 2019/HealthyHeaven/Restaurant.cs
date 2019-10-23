using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public Salad GetHealthiestSalad()
        {
            var salad = this.data.OrderBy(x => x.TotalCalories).First();

            return salad;
        }

        public bool Buy (string name)
        {
            var salad = this.data.Where(x => x.Name == name).FirstOrDefault();
            
            if (salad == null)
            {
                return false;
            }

            this.data.Remove(salad);
            return true;
        }

        public string GenerateMenu()
        {
            var output = new StringBuilder();

            output.AppendLine($"{this.Name} have {this.data.Count} salads:");
            this.data.ForEach(x => output.AppendLine($"{x}"));

            return output.ToString().TrimEnd();
        }
    }
}
