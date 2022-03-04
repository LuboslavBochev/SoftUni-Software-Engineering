using System;
using System.Collections.Generic;
using System.Linq;

namespace Raid
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> raid = new List<BaseHero>();

            int numberHeroes = int.Parse(Console.ReadLine());

            BaseHero hero = null;

            int counter = 0;

            while (counter != numberHeroes)
            {
                try
                {
                    string name = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    if (heroType == nameof(Druid))
                    {
                        hero = new Druid(name);
                    }
                    else if (heroType == nameof(Warrior))
                    {
                        hero = new Warrior(name);
                    }
                    else if (heroType == nameof(Rogue))
                    {
                        hero = new Rogue(name);
                    }
                    else if (heroType == nameof(Paladin))
                    {
                        hero = new Paladin(name);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero!");
                    }
                    raid.Add(hero);

                    counter++;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            long bossPower = long.Parse(Console.ReadLine());
            long raidPower = raid.Sum(hero => hero.Power);

            raid.ForEach(hero => Console.WriteLine(hero.CastAbility()));

            if (raidPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else Console.WriteLine("Defeat...");
        }
    }
}
