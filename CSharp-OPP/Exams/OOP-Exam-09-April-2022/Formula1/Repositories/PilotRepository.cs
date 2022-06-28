using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots = new List<IPilot>();

        public IReadOnlyCollection<IPilot> Models => this.pilots.AsReadOnly();

        public void Add(IPilot model) => this.pilots.Add(model);

        public IPilot FindByName(string name) => this.pilots.FirstOrDefault(p => p.FullName == name);

        public bool Remove(IPilot model) => this.pilots.Remove(model);
    }
}
