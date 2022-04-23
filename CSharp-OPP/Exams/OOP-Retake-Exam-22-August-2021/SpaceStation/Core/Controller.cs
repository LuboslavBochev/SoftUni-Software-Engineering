using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepo;
        private readonly IRepository<IPlanet> planetRepo;
        private readonly IMission mission;
        private int exploredPLanet;

        public Controller()
        {
            this.astronautRepo = new AstronautRepository();
            this.planetRepo = new PlanetRepository();
            this.mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            this.astronautRepo.Add(astronaut);

            var result = string.Format(OutputMessages.AstronautAdded, type, astronautName);

            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepo.Add(planet);

            var result = string.Format(OutputMessages.PlanetAdded, planetName);
            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            int deadCount = 0;
            var astronauts = astronautRepo
                .Models
                .Where(x => x.Oxygen >= 60)
                .ToList();
            if (!astronauts.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            exploredPLanet++;
            var planet = this.planetRepo.FindByName(planetName);

            this.mission.Explore(planet, astronauts);

            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    deadCount++;
                }
            }
            string result = string.Format(OutputMessages.PlanetExplored, planetName, deadCount);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ exploredPLanet} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronautRepo.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: { astronaut.Oxygen}"); 

                string itemsInfo = astronaut.Bag.Items.Any() ?
                    string.Join(", ", astronaut.Bag.Items) : "none";

                sb.AppendLine($"Bag items: { itemsInfo}"); 
                
            }
            return sb.ToString().TrimEnd(); ;
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepo.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronautRepo.Remove(astronaut);
            string result = string.Format(OutputMessages.AstronautRetired, astronautName);
            return result;
            
        }
    }
}
