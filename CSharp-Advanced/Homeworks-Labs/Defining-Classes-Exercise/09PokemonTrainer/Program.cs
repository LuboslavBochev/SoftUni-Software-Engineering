using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string command = Console.ReadLine();
            int count = 0;

            while (command != "Tournament")
            {
                string[] details = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = details[0];
                string pokemonName = details[1];
                string pokemonElement = details[2];
                int pokemonHealth = int.Parse(details[3]);

                List<Pokemon> pokemons = new List<Pokemon>();
                pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                Trainer trainer = new Trainer(trainerName, pokemons);

                if (!CheckName(trainerName, trainers, pokemonName, pokemonHealth, pokemonElement))
                {
                    trainers.Add(trainer);
                }

                command = Console.ReadLine();
            }

            string skill = Console.ReadLine();
            while (skill != "End")
            {
                foreach (var currentTrainer in trainers)
                {
                    foreach (var pokemon in currentTrainer.Pokemons)
                    {
                        if (pokemon.Element == skill && pokemon.Health > 0)
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                        currentTrainer.NumberBadges++;
                    else
                    {
                        foreach (var pokemon in currentTrainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                    count = 0;
                }
                skill = Console.ReadLine();
            }
            foreach (var item in trainers)
            {
                item.Pokemons.RemoveAll(x => x.Health <= 0);
            }
            trainers.OrderByDescending(trainer => trainer.NumberBadges).ToList().ForEach(trainer => Console.WriteLine($"{trainer.Name} {trainer.NumberBadges} {trainer.Pokemons.Count}"));
        }
        static bool CheckName(string trainerName, List<Trainer> trainers, string pokemonName, int pokemonHealth, string pokemonElement)
        {
            foreach (var trainer in trainers)
            {
                if (trainerName == trainer.Name)
                {
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    return true;
                }
            }
            return false;
        }
    }
}
