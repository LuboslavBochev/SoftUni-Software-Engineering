using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<int, int>> targetedCities = new Dictionary<string, Dictionary<int, int>>();

            string inputCities = string.Empty;

            while (true)
            {
                inputCities = Console.ReadLine();

                if (inputCities == "Sail") break;

                string[] splittedInput = inputCities.Split("||");

                string cityName = splittedInput[0];
                int population = int.Parse(splittedInput[1]);
                int gold = int.Parse(splittedInput[2]);

                if (targetedCities.ContainsKey(cityName))
                {
                    int oldPopulation = 0;
                    int oldGold = 0;

                    foreach (var item in targetedCities)
                    {
                        if (item.Key == cityName)
                        {
                            foreach (var values in item.Value)
                            {
                                oldGold = values.Value;
                                gold += oldGold;

                                oldPopulation = values.Key;
                                population += oldPopulation;
                            }
                            break;
                        }
                    }
                    targetedCities.Remove(cityName);
                }

                targetedCities.Add(cityName, new Dictionary<int, int>());
                targetedCities[cityName].Add(population, gold);
            }

            string plunder = string.Empty;

            while (true)
            {

                plunder = Console.ReadLine();

                if (plunder == "End") break;

                string[] tokens = plunder.Split("=>");

                if (tokens[0] == "Plunder")
                {
                    string cityName = tokens[1];
                    int killedPeople = int.Parse(tokens[2]);
                    int stolenGold = int.Parse(tokens[3]);

                    foreach (var item in targetedCities)
                    {
                        if (item.Key == cityName)
                        {
                            foreach (var values in item.Value)
                            {
                                Console.WriteLine($"{cityName} plundered! {stolenGold} gold stolen, {killedPeople} citizens killed.");

                                killedPeople = values.Key - killedPeople;
                                stolenGold = values.Value - stolenGold;

                                if (killedPeople <= 0 || stolenGold <= 0)
                                {
                                    targetedCities.Remove(cityName);
                                    Console.WriteLine($"{cityName} has been wiped off the map!");
                                    break;
                                }
                                else
                                {
                                    targetedCities.Remove(cityName);

                                    targetedCities.Add(cityName, new Dictionary<int, int>());
                                    targetedCities[cityName].Add(killedPeople, stolenGold);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                else // Prosper
                {
                    string cityName = tokens[1];
                    int gold = int.Parse(tokens[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    foreach (var item in targetedCities)
                    {
                        if (item.Key == cityName)
                        {
                            foreach (var value in item.Value)
                            {
                                targetedCities[cityName][value.Key] += gold;
                                Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {value.Value + gold} gold.");
                                break;
                            }
                            break;
                        }
                    }
                }
            }

            if (targetedCities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targetedCities.Count} wealthy settlements to go to:");

                Dictionary<string, int> sortedCities = new Dictionary<string, int>();

                foreach (var item in targetedCities)
                {
                    foreach (var values in item.Value)
                    {
                        sortedCities.Add($"{item.Key} -> Population: {values.Key} citizens,", values.Value);
                    }
                }

                foreach (var item in sortedCities.OrderByDescending(gold => gold.Value).ThenBy(name => name.Key))
                {
                    Console.WriteLine($"{item.Key} Gold: {item.Value} kg");
                }
            }
            else Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }
}