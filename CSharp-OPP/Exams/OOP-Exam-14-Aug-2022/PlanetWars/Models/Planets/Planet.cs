using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;

        private string name;
        private double budget;
        private double militaryPower;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double totalAmount = this.units.Models.Sum(u => u.EnduranceLevel) + this.weapons.Models.Sum(w => w.DestructionLevel);

                if (this.units.FindByName("AnonymousImpactUnit") != null)
                {
                    totalAmount *= 1.3;
                }
                if (this.weapons.FindByName("NuclearWeapon") != null)
                {
                    totalAmount *= 1.45;
                }
                return Math.Round(totalAmount, 3);
            }
            private set
            {
                this.militaryPower = value; 
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Planet: {this.Name}");
            str.AppendLine($"--Budget: {this.Budget} billion QUID");
            str.Append("--Forces: ");
            if(this.units.Models.Count == 0)
            {
                str.AppendLine("No units");
            }
            else str.AppendLine($"{string.Join(", ", this.units.Models)}");
            str.Append("--Combat equipment: ");
            if(this.weapons.Models.Count == 0)
            {
                str.AppendLine("No weapons");
            }
            else str.AppendLine($"{string.Join(", ", this.weapons.Models)}");
            str.AppendLine($"--Military Power: {this.MilitaryPower}");

            return str.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            double decreasedAmount = this.Budget - amount;

            if (decreasedAmount <= 0) throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var units in this.units.Models)
            {
                units.IncreaseEndurance();
            }
        }
    }
}
