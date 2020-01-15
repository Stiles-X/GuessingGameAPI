using System;
using System.Collections.Generic;
using System.Text;
using APIProject.Exceptions;
using APIProject.Interfaces;

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
        private static bool TryAskInt()
        {
            return TryAskInt(out _);
        }
        public static void AskMax(IAPI API)
        {
            bool done = false;
            do
            {
                Console.Write("Enter Max Number: ");
                try
                {
                    if (TryAskInt(out int max))
                    {
                        API.SetMax(max);
                        done = true;
                    }
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
        }
        public static void AskMin(IAPI API)
        {
            bool done = false;
            do
            {
                Console.Write("Enter Min Number: ");
                try
                {
                    if (TryAskInt(out int min))
                    {
                        API.SetMin(min);
                        done = true;
                    }
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
        }
        public static void AskCorrect(IAPI API)
        {
            bool done = false;
            do
            {
                Console.Write("Enter 'Correct' Number: ");
                try
                {
                    if (TryAskInt(out int correct))
                    {
                        API.SetCorrect(correct);
                        done = true;
                    }
                }
                catch (PropertyNotSetException)
                {
                    Console.WriteLine("Max or Min hasn't been set yet.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Value must be max >= value >= min");
                }
            } while (!done);
        }
        public static void AskAllowedGuesses(IAPI API)
        {
            bool done = false;
            do
            {
                Console.Write("Enter Number of Guesses: ");
                try
                {
                    if (TryAskInt(out int allowedGuesses))
                    {
                        API.SetMin(allowedGuesses);
                        done = true;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number of guesses can only be whole numbers");
                }
            } while (!done);
        }
    }
}
