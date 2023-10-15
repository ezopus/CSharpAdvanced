using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>();
        }
        private List<Car> cars;
        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = cars.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            return (cars.Remove(carToRemove));
        }

        public Car GetLatestCar()
        {
            return cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return cars.Find(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int Count
        {
            get
            {
                return cars.Count;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (Car car in cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}
