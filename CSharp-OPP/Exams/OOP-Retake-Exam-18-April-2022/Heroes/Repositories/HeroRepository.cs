using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes.AsReadOnly();

        public void Add(IHero model) => this.heroes.Add(model);

        public IHero FindByName(string name) => this.heroes.FirstOrDefault(h => h.Name == name);

        public bool Remove(IHero model) => this.heroes.Remove(model);
    }
}
