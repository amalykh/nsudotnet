using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.NumberGuesser
{
    class CheerUpper
    {
        private string[] _cheers = { "{0} seems to have real problems with guessing", "Why not to try random, {0}?", "{0}, remember, there are at most 101 number to try" };
        private string _username;
        private Random _random;
        
        public CheerUpper(string username)
        {
            _username = username;
            _random = new Random();
        }

        public string GetCheerUpString()
        {
            return string.Format(_cheers[_random.Next(0, _cheers.Length)], _username);
        }
    }
}
