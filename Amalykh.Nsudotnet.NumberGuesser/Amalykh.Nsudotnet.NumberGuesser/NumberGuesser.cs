using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalykh.Nsudotnet.NumberGuesser
{
    class NumberGuesser
    {
        const int randomMin = 0;
        const int randomMax = 100;
        const int attemptsToCheerUp = 4;
        const string exitCondition = "q";
        const string timeSpanFormat = @"hh\:mm\:ss";

        static List<int> GuessNumber(int targetNumber, string username)
        {
            List<int> res = new List<int>();

            CheerUpper cheerer = new CheerUpper(username);
            int enteredNumber = -1;

            while (enteredNumber != targetNumber)
            {

                if (res.Count > 0 && res.Count % 4 == 0)
                    Console.WriteLine(cheerer.GetCheerUpString());
                
                Console.WriteLine("Enter your guess");

                string curGuess = Console.ReadLine();

                if (curGuess == exitCondition)
                {
                    Console.WriteLine("Sorry, but about to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (!int.TryParse(curGuess, out enteredNumber))
                {
                    Console.WriteLine("Try to enter number next time");
                    continue;
                }

                if (enteredNumber != targetNumber)
                {
                    if (enteredNumber > targetNumber)
                        Console.WriteLine("Your number is greater, then target");
                    else
                        Console.WriteLine("Your number is less, then target");
                    res.Add(enteredNumber);
                }
            }

            return res;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Enter your username and press enter");
            string username = Console.ReadLine();

            Random random = new Random();
            int targetNumber = random.Next(randomMin, randomMax + 1);

            DateTime startTime = DateTime.Now;

            List<int> attempts = GuessNumber(targetNumber, username);

            DateTime endTime = DateTime.Now;

            Console.WriteLine("Finally you've done it!");
            Console.WriteLine("Attempts count: {0}", attempts.Count + 1);
            Console.WriteLine("History of your attempts:");
            for (int i = 0; i < attempts.Count; i++)
                Console.WriteLine("{0} {1}", attempts[i], ((attempts[i] > targetNumber) ? (">") : ("<")));

            Console.WriteLine("And it took: {0}", (endTime - startTime).ToString(timeSpanFormat));
        }
    }
}
