using System;
using System.Collections.Generic;
using System.Text;
using APIProject.Exceptions;
using APIProject.Interfaces;
using APIProject.Extensions.OutOfGuesses;
using APIProject.Extensions.HelperFunctions;

namespace ConsoleUI.GameHelper
{
    public class GameAsk
    {
        private static bool TryAskInt(out int value)
        {
            bool canParse = int.TryParse(Console.ReadLine(), out value);
            if (!canParse)
            {
                Console.WriteLine("Enter a valid character");
            }
            return canParse;
        }
        //Max
        public static void AskMax(IAPI API)
        {
            do
            {
                Console.Write("Enter Max Number: ");
                try
                {
                    if (TryAskInt(out int max))
                    {
                        API.SetMax(max);
                        break;
                    }
                }
                catch (ForbiddenException)
                {
                    Console.WriteLine("You have already set Max, and LockMode is 'on'");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Max value must be more than Min or Correct");
                }
            } while (true);
        }
        //Min
        public static void AskMin(IAPI API)
        {
            do
            {
                Console.Write("Enter Min Number: ");
                try
                {
                    if (TryAskInt(out int min))
                    {
                        API.SetMin(min);
                        break;
                    }
                }
                catch (ForbiddenException)
                {
                    Console.WriteLine("You have already set Min, and LockMode is 'on'");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Min value must be less than Max or Correct");
                }
            } while (true);
        }
        //Correct
        public static void AskCorrect(IAPI API)
        {
            do
            {
                Console.Write("Enter 'Correct' Number: ");
                try
                {
                    if (TryAskInt(out int correct))
                    {
                        API.SetCorrect(correct);
                        break;
                    }
                }
                catch (PropertyNotSetException)
                {
                    Console.WriteLine("Max or Min hasn't been set yet.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Value must be less than max and more than min");
                }
            } while (true);
        }
        //AllowedGuesses
        public static void AskAllowedGuesses(IAPI API)
        {
            do
            {
                Console.Write("Enter Number of Guesses: ");
                try
                {
                    if (TryAskInt(out int allowedGuesses))
                    {
                        API.SetAllowedGuesses(allowedGuesses);
                        break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number of guesses can only be whole numbers");
                }
            } while (true);
        }
        //Guess
        public static bool Guess(IAPI API)
        {
            bool isGameWon;
            do
            {
                Console.Write($"{API.GetLeftGuesses()} Gs left. Guess between {API.GetMax()} and {API.GetMin()}: ");
                try
                {
                    if (TryAskInt(out int guess))
                    {
                        isGameWon = API.Guess(guess);
                        break;
                    }
                }
                catch (PropertyNotSetException)
                {
                    Console.WriteLine("'Correct' or 'Allowed Guesses' has not been set");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Your guess was outside of Max and Min range");
                }
            } while (true);
            return isGameWon;
        }
    }
}
