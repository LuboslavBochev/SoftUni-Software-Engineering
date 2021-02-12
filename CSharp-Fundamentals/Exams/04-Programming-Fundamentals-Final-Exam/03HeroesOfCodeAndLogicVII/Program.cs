using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Final_Fund_Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            int heroesNum = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int i = 0; i < heroesNum; i++)
            {
                string[] fillHeroes = Console.ReadLine().Split(" ");

                string heroName = fillHeroes[0];
                int hp = int.Parse(fillHeroes[1]);
                int mana = int.Parse(fillHeroes[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes.Add(heroName, new List<int>() { hp, mana });
                }
            }

            string commands = string.Empty;

            while (true)
            {

                commands = Console.ReadLine();

                if (commands == "End") break;

                string[] tokens = commands.Split(" - ");

                string heroName = tokens[1];

                if (tokens[0] == "CastSpell")
                {
                    int mana = int.Parse(tokens[2]);

                    if (heroes[heroName][1] >= mana)
                    {
                        heroes[heroName][1] -= mana;

                        Console.WriteLine($"{heroName} has successfully cast {tokens[3]} and now has {heroes[heroName][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {tokens[3]}!");
                    }
                }

                else if (tokens[0] == "TakeDamage")
                {

                    int damageAmount = int.Parse(tokens[2]);

                    heroes[heroName][0] -= damageAmount;

                    if (heroes[heroName][0] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damageAmount} HP by {tokens[3]} and now has {heroes[heroName][0]} HP left!");
                    }

                    else
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {tokens[3]}!");
                    }
                }

                else if (tokens[0] == "Recharge")
                {
                    int manaCharge = int.Parse(tokens[2]);

                    if (heroes[heroName][1] + manaCharge > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName][1]} MP!");
                        heroes[heroName][1] = 200;
                    }
                    else
                    {
                        heroes[heroName][1] += manaCharge;
                        Console.WriteLine($"{heroName} recharged for {manaCharge} MP!");
                    }
                }

                else // heal
                {
                    int hpCharge = int.Parse(tokens[2]);

                    if (heroes[heroName][0] + hpCharge > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroes[heroName][0]} HP!");
                        heroes[heroName][0] = 100;
                    }
                    else
                    {
                        heroes[heroName][0] += hpCharge;
                        Console.WriteLine($"{heroName} healed for {hpCharge} HP!");
                    }
                }
            }

            foreach (var item in heroes.OrderByDescending(hp => hp.Value[0]).ThenBy(name => name.Key))
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"    HP: {item.Value[0]}");
                Console.WriteLine($"    MP: {item.Value[1]}");
            }
        }
    }
}