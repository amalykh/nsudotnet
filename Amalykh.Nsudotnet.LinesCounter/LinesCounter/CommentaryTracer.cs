using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.LinesCounter
{
    class CommentaryTracer
    {
        private int _curComment = -1;
        private List<Commentary> commentaries;

        public void Reset() //sets no comment at current time
        {
            _curComment = -1;
        }

        public CommentaryTracer()
        {
            commentaries = new List<Commentary>();
        }

        public void AddComment(Commentary comment)
        {
            commentaries.Add(comment);
        }

        private void Process(string combination)
        {
            if (_curComment == -1)
            {
                for (int i = 0; i < commentaries.Count; i++)
                {
                    if (commentaries[i].Start == combination)
                    {
                        _curComment = i;
                        break;
                    }
                }
            }
            else
            {
                if (commentaries[_curComment].End == combination)
                    _curComment = -1;
            }
        }

        public void ProcessComment(string combination)
        {
            if (combination.Length > 2 || combination.Length < 1)
                throw new TooCompicatedCommentException();

            Process(combination);
            if (combination.Length == 2)
                Process(combination[1].ToString());
        }

        public bool IsAtComment()
        {
            return _curComment != -1;
        }
    }
}
