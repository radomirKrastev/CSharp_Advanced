using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public string Name { get; set; }
        public int TotalCalories => GetTotalCalories();

        public int GetProductCount()
        {
            return this.products.Count;
        }

        public int GetTotalCalories()
        {
            var calories = 0;

            this.products.ForEach(x=> calories+=x.Calories);

            return calories;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {this.products.Count} products:");
            this.products.ForEach(x => output.AppendLine($"{x}"));

            return output.ToString().Trim();
        }
    }
}
