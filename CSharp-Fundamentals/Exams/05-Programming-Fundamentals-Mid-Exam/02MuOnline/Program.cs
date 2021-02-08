using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> commands = Console.ReadLine().Split("|").ToList();

            int initialHealth = 100;
            int initialBitCoins = 0;

            int bestRoom = 0;

            bool youRDead = false;

            for (int i = 0; i < commands.Count; i++)
            {

                string[] token = commands[i].Split(" ");

                if (token[0] == "potion")
                {
                    int toHeal = int.Parse(token[1]);

                    if (toHeal + initialHealth > 100)
                    {
                        int dif = 100 - initialHealth;

                        initialHealth = 100;

                        Console.WriteLine($"You healed for {dif} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }

                    else
                    {
                        initialHealth += toHeal;

                        Console.WriteLine($"You healed for {toHeal} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }

                }

                else if (token[0] == "chest")
                {

                    int bitCoins = int.Parse(token[1]);

                    initialBitCoins += bitCoins;

                    Console.WriteLine($"You found {bitCoins} bitcoins.");
                }

                else
                {

                    int attackOfMonster = int.Parse(token[1]);
                    string monster = token[0];

                    initialHealth -= attackOfMonster;

                    if (initialHealth > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }

                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        bestRoom = i;
                        youRDead = true;

                        break;
                    }

                }
            }

            if (youRDead)
            {
                Console.WriteLine($"Best room: {bestRoom + 1}");
            }

            else
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {initialBitCoins}");
                Console.WriteLine($"Health: {initialHealth}");
            }
        }
    }
}