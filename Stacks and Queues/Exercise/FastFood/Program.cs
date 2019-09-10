using System;
using System.Linq;
using System.Collections.Generic;

namespace FastFood
{
    public class Program
    {
        public static void Main()
        {
            var quantityPrepared = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine(orders.Max());
            var queue = new Queue<int>(orders);
            bool ordersComplete = false;

            while (queue.Any())
            {
                var currentOrder = queue.Dequeue();
                if (quantityPrepared >= currentOrder)
                {
                    quantityPrepared -= currentOrder;
                    ordersComplete = true;
                }
                else
                {
                    string result = "Orders left: "+ currentOrder.ToString()+" ";

                    if (queue.Any())
                    {
                        result+=string.Join(" ",queue.ToArray()).ToString();
                    }

                    Console.WriteLine(result);
                    ordersComplete = false;
                    break;
                }
            }

            if (ordersComplete)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
