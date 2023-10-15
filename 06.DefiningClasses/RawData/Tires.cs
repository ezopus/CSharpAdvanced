using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tires
    {
        public Tires(double tirePressure, int age)
        {
            TirePressure = tirePressure;
            TireAge = age;
        }
        public double TirePressure { get; set; }
        public int TireAge { get; set; }
    }
}
