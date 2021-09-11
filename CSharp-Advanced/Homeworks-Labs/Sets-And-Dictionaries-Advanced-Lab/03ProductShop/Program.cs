using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");

                if (input[0] == "Revision") break;

                string shopName = input[0];
                string productName = input[1];
                double price = double.Parse(input[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }
                shops[shopName].Add(productName, price);
            }

            foreach (var shop in shops.OrderBy(name => name.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var products in shop.Value)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}