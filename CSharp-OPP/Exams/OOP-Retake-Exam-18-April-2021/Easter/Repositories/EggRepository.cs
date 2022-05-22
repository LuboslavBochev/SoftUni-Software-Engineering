using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.eggs.AsReadOnly();

        public void Add(IEgg model)
        {
            this.eggs.Add(model);
        }

        public IEgg FindByName(string name)
        {
            return this.eggs.FirstOrDefault(e => e.Name == name);
        }

        public bool Remove(IEgg model)
        {
            if (this.eggs.Contains(model))
            {
                this.eggs.Remove(model);
                return true;
            }
            else return false;
        }
    }
}
