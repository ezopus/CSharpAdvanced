using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    internal class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine}");
            if (Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {Weight}");
            }
            if (Color == null)
            {
                Color = "n/a";
            }
            sb.AppendLine($"  Color: {Color}");
            return sb.ToString().TrimEnd();
        }
    }
}
