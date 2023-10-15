using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        public Cargo(double weight, string type)
        {
            CargoWeight = weight;
            CargoType = type;
        }

        public double CargoWeight { get; set; }
        public string CargoType { get; set; }
    }

}
