using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.PerlinNoise
{
    class NoiseGenerator
    {
        Random rnd;

        public NoiseGenerator()
        {
            rnd = new Random();
        }

        public double GetSomeNoise()
        {
            return rnd.Next(50, 255);
        }
    }
}
