using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }
        public int ButtonCapacity { get; private set; }
        public List<Drink> Drinks { get; private set; }

        public int GetCount
        {
            get => Drinks.Count;
        }

        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name) 
            => Drinks.Remove(Drinks.Find(d => d.Name == name));

        public Drink GetLongest()
            => Drinks.MaxBy(v => v.Volume);

        public Drink GetCheapest()
            => Drinks.MinBy(c => c.Price);

        public string BuyDrink(string name)
            => Drinks.Find(d => d.Name == name).ToString();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");
            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
