using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>();
        }
        private List<Pet> pets;
        public int Capacity { get; set; }
        public int Count => pets.Count;

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name) =>
            pets.Remove(pets.FirstOrDefault(p => p.Name == name));

        public Pet GetPet(string name, string owner) =>
            pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);

        public Pet GetOldestPet() =>
            pets.OrderByDescending(x => x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
