using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; private set; } 
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }
            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removed = Animals.RemoveAll(a => a.Species == species);
            return removed;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> dietAnimals = new List<Animal>();
            foreach (var animal in Animals)
            {
                if (animal.Diet == diet)
                {
                    dietAnimals.Add(animal);
                }
            }
            return dietAnimals;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Where(a => a.Length >= minimumLength && a.Length <= maximumLength).Count();

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
