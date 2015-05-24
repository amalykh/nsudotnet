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
            const string incorrectArgumentsCount = "Incorrect arguments count";
            const string incorrectFirstArgument = "First argument must be size of the image";

            if (args.Length < 2)
            {
                Console.WriteLine(incorrectArgumentsCount);
                return;
            }

            int size;
            if (!int.TryParse(args[0], out size))
            {
                Console.WriteLine(incorrectFirstArgument);
                return;
            }

            string filename = args[1];

            PerlinNoiseBitmapGenerator bitmapGenerator = new PerlinNoiseBitmapGenerator(size);
            bitmapGenerator.GetBitmap().Save(filename);
        }
    }
}
