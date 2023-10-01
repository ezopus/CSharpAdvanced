using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string command;
            int counter = 0;

            List<Tire[]> allTires = new();
            List<Engine> engines = new();
            List<Car> cars = new();

            //read all tires
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] tires = new Tire[4];
                for (int i = 0; i < input.Length - 1; i++)
                {
                    Tire tire = new Tire(int.Parse(input[i]), double.Parse(input[i + 1]));
                    tires[counter++] = tire;
                    i++;
                }
                allTires.Add(tires);
                counter = 0;
            }

            //read all engines
            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(int.Parse(input[0]), double.Parse(input[1]));
                engines.Add(engine);
            }

            //read all cars
            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = input[0];
                string model = input[1];
                int year = int.Parse(input[2]);
                double fuelQuantity = double.Parse(input[3]);
                double fuelConsumption = double.Parse(input[4]);
                int engineIndex = int.Parse(input[5]);
                int tiresIndex = int.Parse(input[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], allTires[tiresIndex]);
                cars.Add(car);
            }

            //drive and find special cars
            foreach (var car in cars.Where(x => x.Year >= 2017 
                                                && x.Engine.HorsePower > 330 
                                                && x.Tires.Sum(p => p.Pressure) >= 9 
                                                && x.Tires.Sum(p => p.Pressure) <= 10))
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }


        }
    }
}


/*
2 2.6 3 1.6 2 3.6 3 1.6
1 3.3 2 1.6 5 2.4 1 3.2
No more tires
331 2.2
145 2.0
Engines done
Audi A5 2017 200 12 0 0
BMW X5 2007 175 18 1 1
Show special
*/