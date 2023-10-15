using System;
using System.Collections.Generic;

namespace CarSalesman
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] inputEngines = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine = new Engine(inputEngines[0], int.Parse(inputEngines[1]));
                if (inputEngines.Length > 2)
                {
                    if (int.TryParse(inputEngines[2], out int displacement))
                    {
                        currentEngine.Displacement = displacement;
                    }
                    else
                    {
                        currentEngine.Efficiency = inputEngines[2];
                    }
                }
                if (inputEngines.Length > 3)
                {
                    currentEngine.Efficiency = inputEngines[3];
                }
                engines.Add(currentEngine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputCars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine currentEngine = engines.Find(x => x.Model == inputCars[1]);
                Car currentCar = new Car(inputCars[0], currentEngine);
                if (inputCars.Length > 2)
                {

                    if (int.TryParse(inputCars[2], out int weight))
                    {
                        currentCar.Weight = weight;
                    }
                    else
                    {
                        currentCar.Color = inputCars[2];
                    }
                }
                if (inputCars.Length > 3)
                {
                    currentCar.Color = inputCars[3];
                }

                cars.Add(currentCar);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

/*
2
V8-101 220 50
V4-33 140 28 B
3
FordFocus V4-33 1300 Silver
FordMustang V8-101
VolkswagenGolf V4-33 Orange
*/
