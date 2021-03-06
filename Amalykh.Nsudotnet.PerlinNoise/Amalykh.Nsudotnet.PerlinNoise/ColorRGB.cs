﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.PerlinNoise
{
    class ColorRGB
    {
        private double _r, _g, _b;
        public ColorRGB(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public ColorRGB()
        {
        }

        public double R
        {
            get { return _r; }
            set { _r = Math.Max(0.0, Math.Min(255.0, value)); }
        }
        public double G
        {
            get { return _g; }
            set {  _g = Math.Max(0.0, Math.Min(255.0, value)); }
        }
        public double B
        {
            get { return _b; }
            set { _b = Math.Max(0.0, Math.Min(255.0, value)); }
        }

        public static ColorRGB operator *(ColorRGB a, double k)
        {
            return new ColorRGB(a.R * k, a.G * k, a.B * k);
        }

        public static ColorRGB operator *(double k, ColorRGB a)
        {
            return a * k;
        }

        public static ColorRGB operator +(ColorRGB a, ColorRGB b)
        {
            return new ColorRGB(a.R + b.R, a.G + b.G, a.B + b.B);
        }

    }
}
