using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public List<Pokemon> CheckHealth()
        {
            List<Pokemon> alivePokemons = new List<Pokemon>();
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Health > 0)
                {
                    alivePokemons.Add(pokemon);
                }
            }
            return alivePokemons;
        }
    }
}
