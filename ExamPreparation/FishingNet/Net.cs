using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; private set; }
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get => Fish.Count;
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " ")
            {
                return "Invalid fish.";
            }

            if (fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Capacity <= Fish.Count)
            {
                return "Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            return Fish.Remove(Fish.FirstOrDefault(f => f.Weight == weight));
        }

        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(f => f.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(f => f.Weight).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
