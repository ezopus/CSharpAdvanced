
namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new Dictionary<string, Car>();
        }

        public Dictionary<string, Car> Cars;


        public int Count
        {
            get => Cars.Count;
        }
        public string AddCar(Car car)
        {
            if (Cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (Cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            Cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registration)
        {
            if (!Cars.ContainsKey(registration))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(registration);
                return $"Successfully removed {registration}";
            }
        }
        public Car GetCar(string registration)
        {
            return Cars[registration];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registration in registrationNumbers)
            {
                RemoveCar(registration);
            }
        }
    }
}