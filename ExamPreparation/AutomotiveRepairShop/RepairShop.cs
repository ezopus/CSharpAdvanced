using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }
        public int Capacity { get; private set; }
        public List<Vehicle> Vehicles { get; private set; }
        public void AddVehicle(Vehicle vehicle)
        {
            if (Capacity > Vehicles.Count)
            {
                Vehicles.Add(vehicle);
            }
        }
        public bool RemoveVehicle(string vin)
        {
            return Vehicles.Remove(Vehicles.FirstOrDefault(v => v.VIN == vin));
        }
        public int GetCount()
        {
            return Vehicles.Count;
        }
        public Vehicle GetLowestMileage()
        {
            return Vehicles.MinBy(x => x.Mileage);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
