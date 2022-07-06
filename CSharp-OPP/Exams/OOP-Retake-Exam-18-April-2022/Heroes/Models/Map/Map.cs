using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(p => p.GetType().Name == nameof(Knight)).ToList();
            List<IHero> barbarians = players.Where(p => p.GetType().Name == nameof(Barbarian)).ToList();

            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (var hero in knights)
                {
                    if(hero.IsAlive)
                    {
                        foreach (var barbarian in barbarians)
                        {
                            if(barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(hero.Weapon.DoDamage());
                            }
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if(barbarian.IsAlive)
                    {
                        foreach (var knight in knights)
                        {
                            if(knight.IsAlive)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());
                            }
                        }
                    }
                }
            }

            bool isKnightsLoss = knights.All(k => !k.IsAlive) ? true : false;

            if(isKnightsLoss)
            {
                return $"The barbarians took {barbarians.Count(b => !b.IsAlive)} casualties but won the battle.";
            }
            else
            {
                return $"The knights took {knights.Count(k => !k.IsAlive)} casualties but won the battle.";
            }
        }
    }
}
