using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int numPlants = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> rarityRaitingPlant = new Dictionary<string, List<int>>();

            for (int i = 0; i < numPlants; i++)
            {
                string[] info = Console.ReadLine().Split("<->");

                string plantName = info[0];
                int rarity = int.Parse(info[1]);

                if (!rarityRaitingPlant.ContainsKey(plantName))
                {
                    rarityRaitingPlant.Add(plantName, new List<int>() { 0 });
                }
                rarityRaitingPlant[plantName][0] = rarity;
            }

            string commands = string.Empty;

            while (true)
            {
                commands = Console.ReadLine();

                if (commands == "Exhibition") break;

                string[] tokens = commands.Split(new string[] { " ", "-", ":" }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string plantName = tokens[1];

                if (command == "Rate")
                {
                    if (rarityRaitingPlant.ContainsKey(plantName))
                    {
                        int rating = int.Parse(tokens[2]);

                        rarityRaitingPlant[plantName].Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else if (command == "Update")
                {
                    if (rarityRaitingPlant.ContainsKey(plantName))
                    {
                        int rarity = int.Parse(tokens[2]);

                        rarityRaitingPlant[plantName][0] = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else
                {
                    if (rarityRaitingPlant.ContainsKey(plantName))
                    {
                        int rarity = rarityRaitingPlant[plantName][0];

                        rarityRaitingPlant[plantName].Clear();
                        rarityRaitingPlant[plantName].Add(rarity);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }
            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in rarityRaitingPlant.OrderByDescending(rarity => rarity.Value[0]).ThenByDescending(av => av.Value.Average()))
            {
                if (item.Value.Count == 1)
                {
                    Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: 0.00");
                }
                else Console.WriteLine($"- {item.Key}; Rarity: {item.Value[0]}; Rating: {item.Value.Skip(1).Average():f2}");
            }
        }
    }
}