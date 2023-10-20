using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; private set; }
        public int Count
        {
            get => Shoes.Count;
        }
        public string AddShoe(Shoe shoe)
        {
            if (StorageCapacity <= Shoes.Count)
            {
                return "No more space in the storage room.";
            }
            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }
        public int RemoveShoes(string material)
        {
            return Shoes.RemoveAll(sh => sh.Material == material);
        }
        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.FindAll(sh => sh.Type == type.ToLower());
        }
        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(sh => sh.Size == size);
        }
        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            List<Shoe> filtered = new List<Shoe>();

            foreach (var shoe in Shoes.Where(sh => sh.Type == type && sh.Size == size))
            {
                filtered.Add(shoe);
            }

            if (filtered.Count > 0)
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoe in filtered)
                {
                    sb.AppendLine(shoe.ToString());
                }

                return sb.ToString().TrimEnd();

            }

            return "No matches found!";
        }
    }
}
