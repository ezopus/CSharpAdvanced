using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x => x.Name == ingredient.Name))
            {
                if(Ingredients.Count < Capacity 
                   && ingredient.Alcohol + Ingredients.Sum(x => x.Alcohol) <= MaxAlcoholLevel)
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredientToRemove = Ingredients.FirstOrDefault(x => x.Name == name);
            return Ingredients.Remove(ingredientToRemove);
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).First();
        }

        public int CurrentAlcoholLevel
        {
            get => Ingredients.Sum(x => x.Alcohol);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
