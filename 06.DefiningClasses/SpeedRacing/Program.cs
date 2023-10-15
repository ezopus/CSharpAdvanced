using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car
                {
                    Model = inputCar[0],
                    FuelAmount = double.Parse(inputCar[1]),
                    FuelConsumptionPerKilometer = double.Parse(inputCar[2])
                };
                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currentCar = input[1];
                double distance = double.Parse(input[2]);
                Car driveCar = cars.Find(x => x.Model == currentCar);
                driveCar.Drive(distance);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
