using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Amalykh.Nsudotnet.PerlinNoise
{
    class Program
    {
        static void Main(string[] args)
        {
            const string E_ARG_CNT = "Incorrect arguments count";
            const string E_FRST_NOI = "First argument must be size of the image";

            if (args.Length < 2)
            {
                Console.WriteLine(E_ARG_CNT);
                return;
            }

            int size;
            try
            {
                size = int.Parse(args[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(E_FRST_NOI);
                return;
            }

            string filename = args[1];

            PerlinNoiseBitmapGenerator bitmapGenerator = new PerlinNoiseBitmapGenerator(size);
            bitmapGenerator.GetBitmap().Save(filename);
        }
    }
}
