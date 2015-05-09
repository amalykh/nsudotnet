using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.PerlinNoise
{
    class BicubicInterpolator : CubicInterpolator
    {

        public double BicubicInterpolate(double[][] p, double x, double y)
        {

            double[] a = new double[4];

            a[0] = CubicInterpolate(p[0], y);
            a[1] = CubicInterpolate(p[1], y);
            a[2] = CubicInterpolate(p[2], y);
            a[3] = CubicInterpolate(p[3], y);
            return CubicInterpolate(a, x);
        }

    }
}
