using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations;

        public void Add(IDecoration model) => this.decorations.Add(model);

        public IDecoration FindByType(string type) => this.decorations.FirstOrDefault();

        public bool Remove(IDecoration model) => this.decorations.Remove(model);
    }
}
