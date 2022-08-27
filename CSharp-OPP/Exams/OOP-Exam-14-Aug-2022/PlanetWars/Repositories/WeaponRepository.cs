using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void AddItem(IWeapon model) => this.weapons.Add(model);

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IWeapon weaponToDel = this.weapons.Find(w => w.GetType().Name == name);
            return this.weapons.Remove(weaponToDel);
        }
    }
}
