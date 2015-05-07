using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Amalykh.Nsudotnet.LinesCounter
{
    class FileLineCounter
    {
        CommentaryTracer tracer = new CommentaryTracer();
        const int BUFFER_SIZE = 8 * 1024;
        byte[] buffer = new byte[BUFFER_SIZE];
        public FileLineCounter()
        {
            tracer.AddComment(new Commentary(@"/*", @"*/"));
            tracer.AddComment(new Commentary(@"//", "\n"));
        }

        public int ProcessFile(string filename)
        {
            int readLen = 0;
            int linesCount = 0;
            char cur = (char)(0), prev;
            bool emptyLine = true;

            tracer.Reset();

            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                while ((readLen = fs.Read(buffer, 0, BUFFER_SIZE)) != 0)
                {
                    for (int i = 0; i < readLen; i++)
                    {
                        int value = buffer[i];

                        prev = cur;
                        cur = (char)value;

                        tracer.ProcessComment(prev.ToString() + cur.ToString());

                        if (!emptyLine && value == (int)'\n' && !tracer.IsAtComment())
                        {
                            linesCount++;
                            emptyLine = true;
                        }

                        if (!char.IsSeparator(cur) && cur != '\r' && cur != '\n' && cur != '/' && !tracer.IsAtComment())
                            emptyLine = false;
                    }
                }
            }

            if (!emptyLine)
                linesCount++;

            return linesCount;
        }
    }
}
