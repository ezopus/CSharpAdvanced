using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] inputCar = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Car newCar = new Car(
                    inputCar[0],
                    int.Parse(inputCar[1]),
                    int.Parse(inputCar[2]),
                    double.Parse(inputCar[3]),
                    inputCar[4],
                    double.Parse(inputCar[5]),
                    int.Parse(inputCar[6]),
                    double.Parse(inputCar[7]),
                    int.Parse(inputCar[8]),
                    double.Parse(inputCar[9]),
                    int.Parse(inputCar[10]),
                    double.Parse(inputCar[11]),
                    int.Parse(inputCar[12])
                    );

                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.TirePressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (Car car in cars.Where(x => x.Cargo.CargoType == "flammable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}

