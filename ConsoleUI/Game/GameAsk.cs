using System;
using System.Collections.Generic;
using System.Text;
using APIProject.Exceptions;

namespace ConsoleUI.GameHelper
{
    public class GameAsk
    {
        private static bool TryAskInt(out int value)
        {
            bool done = int.TryParse(Console.ReadLine(), out value);
            if (!done)
            {
                Console.WriteLine("Enter a valid character");
            }
            return done;
        }
        public static int AskMax()
        {
            bool done = false;
            int max = 0;
            do
            {
                Console.WriteLine("Enter Max Number: ");
                try
                {
                    done = TryAskInt(out max);
                }
                catch (ForbiddenException)
                {
                    Console.WriteLine("You have already set Max, and LockMode is 'on'");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Your attempted Max value is less than selected Min, or 'Correct'");
                }
            } while (!done);
            return max;
        }
        public static int AskMin()
        {
            bool done = false;
            int min = 0;
            do
            {
                Console.WriteLine("Enter Min Number: ");
                try
                {
                    done = TryAskInt(out min);
                }
                catch (ForbiddenException)
                {
                    Console.WriteLine("You have already set min, and LockMode is 'on'");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("You attempted min value is more than selected Max, or 'Correct'");
                }
            } while (!done);
            return min;
        }
    }
}
