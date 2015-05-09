using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Amalykh.Nsudotnet.PerlinNoise
{
    class PerlinNoiseBitmapGenerator
    {
        private int _size;

        public PerlinNoiseBitmapGenerator(int imageSize)
        {
            _size = imageSize;
        }

        public Bitmap GetBitmap()
        {
            const int gridsCount = 3;
            int n = 3;
            const int nMultiplier = 2;
            double curContrib = 0.5;
            const double contribDivisor = 1.7;

            Bitmap bmp = new Bitmap(_size, _size);

            List<Grid> grids = new List<Grid>();
            List<double> coefs = new List<double>();
            
            for (int i = 0; i < gridsCount; i++)
            {
                grids.Add(new Grid(_size, n));
                n *= nMultiplier;

                coefs.Add(curContrib);
                curContrib /= contribDivisor;
            }

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    ColorRGB color = new ColorRGB(0, 0, 0);
                    for (int k = 0; k < grids.Count; k++)
                        color += coefs[k] * grids[k].GetColor(i, j);

                    Color res = Color.FromArgb((int)color.R, (int)color.G, (int)color.B);

                    bmp.SetPixel(j, i, res);
                }
            }

            return bmp;
        }
    }
}
