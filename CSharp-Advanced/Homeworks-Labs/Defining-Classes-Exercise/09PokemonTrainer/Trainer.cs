using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{ 
    public class Trainer
    {
        public Trainer(string trainerName, List<Pokemon> pokemons)
        {
            this.Name = trainerName;
            this.Pokemons = pokemons;
        }
        public string Name { get; set; }

        public int NumberBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
