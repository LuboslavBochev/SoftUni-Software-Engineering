using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            IMilitaryUnit militaryUnit = planet.Army.Where(a => a.GetType().Name == unitTypeName).FirstOrDefault();

            if (militaryUnit != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            switch (unitTypeName)
            {
                case "AnonymousImpactUnit":
                    militaryUnit = new AnonymousImpactUnit();
                    break;
                case "SpaceForces":
                    militaryUnit = new SpaceForces();
                    break;
                case "StormTroopers":
                    militaryUnit = new StormTroopers();
                    break;

                default:
                    throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            IWeapon weapon = planet.Weapons.Where(w => w.GetType().Name == weaponTypeName).FirstOrDefault();

            if (weapon != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;

                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;

                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;

                default:
                    throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = this.planets.FindByName(name);

            if (planet != null) return string.Format(OutputMessages.ExistingPlanet, name);

            this.planets.AddItem(new Planet(name, budget));

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in this.planets.Models.OrderByDescending(p => p.MilitaryPower).OrderBy(p => p.Name))
            {
                result.AppendLine(planet.PlanetInfo());
            }
            return result.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attackerPlanet = this.planets.FindByName(planetOne);
            IPlanet defenderPlanet = this.planets.FindByName(planetTwo);

            bool attackerPlanetHasNuclear = attackerPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
            bool defenderPlanetHasNuclear = defenderPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");

            double halfAttackerBudget = attackerPlanet.Budget / 2;
            double halfDefenderBudget = defenderPlanet.Budget / 2;

            if (attackerPlanet.MilitaryPower == defenderPlanet.MilitaryPower || attackerPlanetHasNuclear || defenderPlanetHasNuclear)
            {
                if (attackerPlanetHasNuclear && defenderPlanetHasNuclear) // both own nuclear
                {
                    attackerPlanet.Spend(halfAttackerBudget);
                    defenderPlanet.Spend(halfDefenderBudget);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (!attackerPlanetHasNuclear && !defenderPlanetHasNuclear) // both do not own
                {
                    attackerPlanet.Spend(halfAttackerBudget);
                    defenderPlanet.Spend(halfDefenderBudget);
                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else // have nuclear
                {
                    if (attackerPlanetHasNuclear)
                    {
                        attackerPlanet.Spend(halfAttackerBudget);
                        attackerPlanet.Profit(halfDefenderBudget);
                        attackerPlanet.Profit(defenderPlanet.Army.Sum(a => a.Cost) + defenderPlanet.Weapons.Sum(w => w.Price));
                        this.planets.RemoveItem(defenderPlanet.Name);
                        return $"{attackerPlanet.Name} destructed {defenderPlanet.Name}!";
                    }
                    else // def have
                    {
                        defenderPlanet.Spend(halfDefenderBudget);
                        defenderPlanet.Profit(halfAttackerBudget);
                        defenderPlanet.Profit(attackerPlanet.Army.Sum(a => a.Cost) + attackerPlanet.Weapons.Sum(w => w.Price));
                        this.planets.RemoveItem(attackerPlanet.Name);
                        return $"{defenderPlanet.Name} destructed {attackerPlanet.Name}!";
                    }
                }
            }
            else if (attackerPlanet.MilitaryPower > defenderPlanet.MilitaryPower) //attacker wins
            {
                attackerPlanet.Spend(halfAttackerBudget);
                attackerPlanet.Profit(halfDefenderBudget);
                attackerPlanet.Profit(defenderPlanet.Army.Sum(a => a.Cost) + defenderPlanet.Weapons.Sum(w => w.Price));
                this.planets.RemoveItem(defenderPlanet.Name);
                return $"{attackerPlanet.Name} destructed {defenderPlanet.Name}!";
            }
            else // def wins
            {
                defenderPlanet.Spend(halfDefenderBudget);
                defenderPlanet.Profit(halfAttackerBudget);
                defenderPlanet.Profit(attackerPlanet.Army.Sum(a => a.Cost) + attackerPlanet.Weapons.Sum(w => w.Price));
                this.planets.RemoveItem(attackerPlanet.Name);
                return $"{defenderPlanet.Name} destructed {attackerPlanet.Name}!";
            }
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == null) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            int militaryUnitsCount = planet.Army.Count;

            if (militaryUnitsCount == 0) throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
