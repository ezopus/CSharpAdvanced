using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
        private string make;
        public string Make
        {
            get { return make; }
            set { make = value; }

        }

        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private double fuelQuantity;
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        private double fuelConsumption;
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        private Tire[] tire;

        public Tire[] Tires
        {
            get { return tire; }
            set { tire = value; }
        }

        public void Drive(double distance)
        {
            if (fuelConsumption * (distance/100) < fuelQuantity)
            {
                fuelQuantity -= fuelConsumption * (distance/100);
            }
            // else
            // {
            //     Console.WriteLine($"Not enough fuel to perform this trip!");
            // }
        }

        public string WhoAmI()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Make: {this.Make}");
            output.AppendLine($"Model: {this.Model}");
            output.AppendLine($"Year: {this.Year}");
            output.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            output.AppendLine($"FuelQuantity: {this.FuelQuantity}");

            return output.ToString().Trim();
        }
    }
}
