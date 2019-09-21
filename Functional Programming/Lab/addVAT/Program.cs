using System;
using System.Linq;

namespace addVAT
{
    public class Program
    {
        public static void Main()
        {
            var prices = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Action<double[]> pricesAction = AddVatPrintResult;
            pricesAction(prices);
        }

        public static void AddVatPrintResult(double[] prices)
        {
            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] *= 1.2;
            }

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
