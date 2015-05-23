using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.PerlinNoise
{
    class NoiseGenerator
    {
        private Random _rnd;

        public NoiseGenerator()
        {
            _rnd = new Random();
        }

        public double GetSomeNoise()
        {
            return _rnd.Next(50, 255);
        }
    }
}
