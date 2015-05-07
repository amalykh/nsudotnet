using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Amalykh.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = args[0];

            FileLineCounter linesCounter = new FileLineCounter();

            Stack<string> dirs = new Stack<string>();

            String dir = Environment.CurrentDirectory;

            if (!System.IO.Directory.Exists(dir))
            {
                Console.WriteLine("Incorrect directory");
                return;
            }

            int linesCount = 0;

            dirs.Push(dir);

            while (dirs.Count > 0)
            {
                dir = dirs.Pop();
                string[] subDirs;

                try
                {
                    subDirs = System.IO.Directory.GetDirectories(dir);
                    foreach (string s in subDirs)
                        dirs.Push(s);
                }
                catch (UnauthorizedAccessException e)
                {
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(dir, pattern);
                }
                catch (UnauthorizedAccessException e)
                {
                    continue;
                }

                foreach (string file in files)
                {
                    linesCount += linesCounter.ProcessFile((new System.IO.FileInfo(file)).FullName);
                }

            }

            Console.WriteLine(linesCount);
        }
    }
}
