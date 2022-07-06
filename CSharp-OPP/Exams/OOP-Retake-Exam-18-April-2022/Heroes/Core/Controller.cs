using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;
        private IMap map;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
            this.map = new Map();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heroes.FindByName(heroName);

            if (hero == null) throw new InvalidOperationException($"Hero {heroName} does not exist.");

            IWeapon weapon = this.weapons.FindByName(weaponName);

            if (weapon == null) throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            if (hero.Weapon != null) throw new InvalidOperationException($"Hero {heroName} is well-armed.");

            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {hero.Weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = this.heroes.FindByName(name);

            if(hero != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            switch (type)
            {
                case "Knight":
                    hero = new Knight(name, health, armour);
                    this.heroes.Add(hero);
                    return $"Successfully added Sir {name} to the collection.";

                case "Barbarian":
                    hero = new Barbarian(name, health, armour);
                    this.heroes.Add(hero);
                    return $"Successfully added Barbarian {name} to the collection.";

                default:
                    throw new InvalidOperationException("Invalid hero type.");
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = this.weapons.FindByName(name);

            if(weapon != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            switch (type)
            {
                case "Mace":
                    weapon = new Mace(name, durability);
                    this.weapons.Add(weapon);
                    return $"A {type.ToLower()} {name} is added to the collection.";

                case "Claymore":
                    weapon = new Claymore(name, durability);
                    this.weapons.Add(weapon);
                    return $"A {type.ToLower()} {name} is added to the collection.";

                default:
                    throw new InvalidOperationException("Invalid weapon type.");
            }
        }

        public string HeroReport()
        {
            StringBuilder str = new StringBuilder();

            foreach (var hero in this.heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                string haveWeapon = hero.Weapon != null ? hero.Weapon.Name : "Unarmed";

                str.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                str.AppendLine($"--Health: {hero.Health}");
                str.AppendLine($"--Armour: {hero.Armour}");
                str.AppendLine($"--Weapon: {haveWeapon}");
            }
            return str.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            List<IHero> heroesToAdd = this.heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            return this.map.Fight(heroesToAdd);
        }
    }
}
