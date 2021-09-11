using System;
using System.Collections.Generic;

namespace Stacks_And_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> nestedDict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!nestedDict.ContainsKey(continent))
                {
                    nestedDict.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!nestedDict[continent].ContainsKey(country))
                {
                    nestedDict[continent].Add(country, new List<string>());
                }
                nestedDict[continent][country].Add(city);
            }

            foreach (var continent in nestedDict)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"    {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}