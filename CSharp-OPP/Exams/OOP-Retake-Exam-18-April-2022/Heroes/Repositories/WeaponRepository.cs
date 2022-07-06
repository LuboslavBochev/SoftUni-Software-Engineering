using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void Add(IWeapon model) => this.weapons.Add(model);

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(w => w.Name == name);

        public bool Remove(IWeapon model) => this.weapons.Remove(model);
    }
}
