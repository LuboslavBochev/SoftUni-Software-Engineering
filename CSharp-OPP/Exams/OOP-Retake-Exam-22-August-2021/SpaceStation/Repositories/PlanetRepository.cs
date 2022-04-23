﻿using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models =>this.planets;

        public void Add(IPlanet model) => planets.Add(model);


        public IPlanet FindByName(string name) => planets.FirstOrDefault(x =>x.Name == name);


        public bool Remove(IPlanet model) => planets.Remove(model);
        
    }
}
