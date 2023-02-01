using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> list;

        public DelicacyRepository()
        {
            this.list = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models => this.list.AsReadOnly();

        public void AddModel(IDelicacy model) => this.list.Add(model);
    }
}
