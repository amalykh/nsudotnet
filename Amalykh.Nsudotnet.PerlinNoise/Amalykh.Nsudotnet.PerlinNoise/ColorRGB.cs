using System;
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
            get { return Math.Max(0.0, Math.Min(_r, 255.0)); }
            set { _r = Math.Max(0.0, Math.Min(255.0, value)); }
        }
        public double G
        {
            get { return Math.Max(0.0, Math.Min(_g, 255.0)); }
            set {  _g = Math.Max(0.0, Math.Min(255.0, value)); }
        }
        public double B
        {
            get { return Math.Max(0.0, Math.Min(_b, 255.0)); }
            set { _b = Math.Max(0.0, Math.Min(255.0, value)); }
        }

        private int normalize(double d)
        {
            int t = (int)Math.Round(d);
            t = Math.Min(255, t);
            t = Math.Max(0, t);
            return t;
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
