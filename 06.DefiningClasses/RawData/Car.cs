using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(
            string model,
            int power,
            int speed,
            double weight,
            string type,
            double tyre1pressure,
            int tyre1age,
            double tyre2Pressure,
            int tyre2age,
            double tyre3Pressure,
            int tyre3age,
            double tyre4Pressure,
            int tyre4age
            )
        {
            Model = model;
            Engine = new Engine(power, speed);
            Cargo = new Cargo(weight, type);
            Tires = new Tires[4];
            Tires[0] = new Tires(tyre1pressure, tyre1age);
            Tires[1] = new Tires(tyre2Pressure, tyre2age);
            Tires[2] = new Tires(tyre3Pressure, tyre3age);
            Tires[3] = new Tires(tyre4Pressure, tyre4age);
        }
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tires[] Tires { get; set; }

    }
}
