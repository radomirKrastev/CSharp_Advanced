using System;
using System.Linq;
using System.Collections.Generic;

namespace ProductShop
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var storesInfo = new SortedDictionary<string, List<Product>>();

            while (command[0] != "Revision")
            {
                var store = command[0];
                var product = command[1];
                var price = double.Parse(command[2]);

                if (!storesInfo.ContainsKey(store))
                {
                    storesInfo.Add(store, new List<Product>());
                }

                storesInfo[store].Add(new Product(product, price));

                command = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var store in storesInfo)
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }                
            }
        }
    }
}
