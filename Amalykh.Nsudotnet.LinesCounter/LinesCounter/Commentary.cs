using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.LinesCounter
{
    class Commentary
    {
        public string Start { set; get; }
        public string End { set; get; }
        public Commentary(string start, string end)
        {
            if (start.Length < 0 || start.Length > 2 || end.Length < 0 || end.Length > 2)
                throw new TooCompicatedCommentException();
            Start = start;
            End = end;
        }
    }
}
