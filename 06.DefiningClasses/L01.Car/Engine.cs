﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        private int horsePower;
        public int HorsePower
        {
            get => horsePower;
            set => horsePower = value;
        }

        private double cubicCapacity;
        public double CubicCapacity
        {
            get => cubicCapacity;
            set => cubicCapacity = value;
        }

    }
}
