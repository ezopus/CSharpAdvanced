using System;

namespace SpeedRacing
{
    public class Car
    {
        public Car()
        {
            TravelledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }
        
        public void Drive(double distance)
        {
            if (FuelConsumptionPerKilometer * distance <= FuelAmount)
            {
                FuelAmount -= distance * FuelConsumptionPerKilometer;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
