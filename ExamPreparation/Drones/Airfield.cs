using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; private set; }
        public int Count
        {
            get => Drones.Count;
        }
        public string AddDrone(Drone drone)
        {
            if (drone.Name == " " || drone.Name == null || drone.Brand == " " || drone.Brand == null)
            {
                return "Invalid drone.";
            }

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (Capacity <= Drones.Count)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            return Drones.Remove(Drones.FirstOrDefault(dr => dr.Name == name));
        }
        public int RemoveDroneByBrand(string brand)
        {
            int removed = Drones.RemoveAll(dr => dr.Brand == brand);
            return removed;
        }
        public Drone FlyDrone(string name)
        {
            Drone flyDrone = Drones.FirstOrDefault(dr => dr.Name == name);
            if (flyDrone != null)
            {
                flyDrone.Available = false;
                return flyDrone;
            }

            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDrones = Drones.FindAll(dr => dr.Range >= range && dr.Available);
            foreach (var drone in flyDrones)
            {
                FlyDrone(drone.Name);
            }
            return flyDrones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones.Where(dr => dr.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
