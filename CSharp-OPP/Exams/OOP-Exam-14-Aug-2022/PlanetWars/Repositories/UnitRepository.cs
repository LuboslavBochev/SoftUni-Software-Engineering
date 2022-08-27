using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            this.militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.militaryUnits.AsReadOnly();

        public void AddItem(IMilitaryUnit model) => this.militaryUnits.Add(model);

        public IMilitaryUnit FindByName(string name) => this.militaryUnits.FirstOrDefault(m => m.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IMilitaryUnit militaryUnit = this.militaryUnits.FirstOrDefault(m => m.GetType().Name == name);
            return this.militaryUnits.Remove(militaryUnit);
        }
    }
}
