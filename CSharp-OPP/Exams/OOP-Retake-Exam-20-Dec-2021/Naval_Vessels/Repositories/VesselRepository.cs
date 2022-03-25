﻿using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => this.vessels;

        public void Add(IVessel model)
        {
            this.vessels.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return this.vessels.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return this.vessels.FirstOrDefault(v => v.Name == name);
        }
    }
}
