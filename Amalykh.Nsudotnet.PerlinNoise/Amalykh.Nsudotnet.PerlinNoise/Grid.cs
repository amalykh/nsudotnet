using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.PerlinNoise
{
    class Grid
    {
        private ColorRGB[,] _c;
        private int n;
        private int _imageSize;

        public Grid(int imageSize, int n)
        {
            _c = new ColorRGB[n + 3, n + 3];
            _imageSize = imageSize;
            this.n = n;

            NoiseGenerator generator = new NoiseGenerator();
            for (int i = 0; i < n + 3; i++)
            {
                for (int j = 0; j < n + 3; j++)
                {
                    _c[i, j] = new ColorRGB(generator.GetSomeNoise(), generator.GetSomeNoise(), generator.GetSomeNoise());
                }
            }
        }

        public ColorRGB GetColor(int row, int column)
        {

            const double eps = 1e-9;

            double cRow = (row + 0.0) / _imageSize * n - eps;
            double cColumn = (column + 0.0) / _imageSize * n - eps;

            if (cRow < 0) cRow = eps;
            if (cColumn < 0) cColumn = eps;

            double y = cRow - Math.Truncate(cRow);
            double x = cColumn - Math.Truncate(cColumn);

            double[][] pR = new double[4][];
            double[][] pG = new double[4][];
            double[][] pB = new double[4][];

            for (int i = 0; i < 4; i++)
            {
                pR[i] = new double[4];
                pG[i] = new double[4];
                pB[i] = new double[4];
            }

            int currentRow = (int)Math.Truncate(cRow);
            int currentColumn = (int)Math.Truncate(cColumn);

            for (int i = -1; i <= 2; i++)
            {
                for (int j = -1; j <= 2; j++)
                {

                    pR[j + 1][i + 1] = _c[i + currentRow + 1, j + currentColumn + 1].R;
                    pG[j + 1][i + 1] = _c[i + currentRow + 1, j + currentColumn + 1].G;
                    pB[j + 1][i + 1] = _c[i + currentRow + 1, j + currentColumn + 1].B;
                }
            }

            BicubicInterpolator interpolator = new BicubicInterpolator();
            return new ColorRGB(interpolator.BicubicInterpolate(pR, x, y),
                interpolator.BicubicInterpolate(pG, x, y),
                interpolator.BicubicInterpolate(pB, x, y));

        }
    }
}
