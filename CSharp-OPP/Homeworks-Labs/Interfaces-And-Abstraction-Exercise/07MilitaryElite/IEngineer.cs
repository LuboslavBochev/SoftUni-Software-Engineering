using System.Collections.Generic;

namespace InterfacesAbstration
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }

        public void AddRepair(IRepair repair);
    }
}
