using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeSalad
{
    public class Program
    {
        public static void Main()
        {
            var vegetables = new Queue<string>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            var saladCalories = new Stack<int>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var finishedSaladsValues = new List<int>();

            var vegetableCalories = 0; 

            while (vegetables.Any() && saladCalories.Any())
            {
                var vegetable = vegetables.Dequeue();

                vegetableCalories+= GetCalories(vegetable);

                if (vegetableCalories >= saladCalories.Peek())
                {
                    vegetableCalories -= saladCalories.Peek();
                    finishedSaladsValues.Add(saladCalories.Pop());
                }
            }
            
            Console.WriteLine(string.Join(" ",finishedSaladsValues));
            
            if (vegetables.Any())
            {
                Console.Write(string.Join(" ",vegetables));
            }
            else
            {
                Console.Write(string.Join(" ",saladCalories));
            }
        }

        private static int GetCalories(string vegetable)
        {
            var vegetableCalories = 0;

            if (vegetable == Vegetables.tomato.ToString())
            {
                vegetableCalories = (int)Vegetables.tomato;
            }
            else if (vegetable == Vegetables.potato.ToString())
            {
                vegetableCalories = (int)Vegetables.potato;
            }
            else if (vegetable == Vegetables.carrot.ToString())
            {
                vegetableCalories = (int)Vegetables.carrot;
            }
            else if (vegetable == Vegetables.lettuce.ToString())
            {
                vegetableCalories = (int)Vegetables.lettuce;
            }

            return vegetableCalories;
        }
    }
}
