using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PokemonTrainer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();
            string command;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                string pokemon = input[1];
                string element = input[2];
                int health = int.Parse(input[3]);
                Pokemon currentPokemon = new Pokemon(pokemon, element, health);
                if (!trainers.ContainsKey(name))
                {
                    Trainer currentTrainer = new Trainer(name);
                    trainers.Add(name, currentTrainer);
                }
                trainers[name].Pokemons.Add(currentPokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                ElementMove(trainers, command);
                // switch (command)
                // {
                //     case "Fire":
                //         ElementMove(trainers, command);
                //         break;
                //     case "Water":
                //         break;
                //     case "Electricity":
                //         break;
                // }
            }

            foreach (var trainer in trainers.Values.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        public static void ElementMove(Dictionary<string, Trainer> trainers, string element)
        {
            foreach (var trainer in trainers)
            {

                if (trainer.Value.Pokemons.Any(x => x.Element == element))
                {
                    trainer.Value.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Value.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                }
            }

            foreach (var trainer in trainers)
            {
                trainer.Value.Pokemons = trainer.Value.CheckHealth();
            }
        }
    }
}

/*
Peter Charizard Fire 100
George Squirtle Water 38
Peter Pikachu Electricity 10
Tournament
Fire
Electricity
End

Sam Blastoise Water 18
Narry Pikachu Electricity 22
John Kadabra Psychic 90
Tournament
Fire
Electricity
Fire
End
 */