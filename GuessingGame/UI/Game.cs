using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;

namespace GuessingGame.UI
{
    using Core.Exceptions;
    enum PlayerMode
    {
        single,
        multi
    }
    class Game
    {
        private static bool GuessHarder(API api)
        {
            bool Correct;
            try
            {
                int answer = Misc.intput(
                $"{api.GetLeftGuesses()} guesses left. Choose between (including) {api.GetMin()} and {api.GetMax()}: "
                );
                Correct = api.Guess(answer);
            }
            catch (PropertyNotSetException)
            {
                Console.WriteLine("'Correct' or 'Allowed Guesses' has not been set");
                Correct = GuessHarder(api);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Your guess was outside of Max and Min range");
                Correct = GuessHarder(api);
            }
            return Correct;
        }
        private static void Guess(API api)
        {
            if (api.GetOutOfGuesses()) { Console.WriteLine("Sorry, you ran out of tries"); }
            else
            {
                bool Correct = GuessHarder(api);
                if (Correct) 
                { 
                    Console.WriteLine("Congratulations, you did it! Incredible job!");
                    Console.WriteLine($"From a game of {api.GetAllowedGuesses()} guesses, between {api.GetMax()} and {api.GetMin()}");
                    Console.WriteLine($"You won with {api.GetUsedGuesses()} guesses or {api.GetLeftGuesses()} guesses left");
                }
                else { Guess(api); }
            }
        }

        public static void SetMin(API api)
        {
            try
            {
                api.SetMin(Misc.intput("Enter Min Number: "));
            }
            catch (ForbiddenException)
            {
                Console.WriteLine("You have already set min, and LockMode is 'on'");
                SetMin(api);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You attempted min value is more than selected Max, or 'Correct'");
                SetMin(api);
            }
        }
        public static void SetMax(API api)
        {
            try
            {
                api.SetMax(Misc.intput("Enter Max Number: "));
            }
            catch (ForbiddenException)
            {
                Console.WriteLine("You have already set Max, and LockMode is 'on'");
                SetMax(api);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You attempted Max value is less than selected Min, or 'Correct'");
                SetMax(api);
            }
        }
        public static void SetAllowedGuesses(API api)
        {
            try
            {
                api.SetAllowedGuesses(Misc.intput("Enter Number of Guesses: "));
            } catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number of guesses can only be whole numbers");
                SetAllowedGuesses(api);
            }
            
        }
        public static void SetCorrect(API api)
        {
            try
            {
                api.SetCorrect(Misc.intput("Enter 'Correct' Number: "));
            }
            catch (PropertyNotSetException)
            {
                Console.WriteLine("Max or Min hasn't been set yet.");
                SetCorrect(api);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Value must be max >= value >= min");
                SetCorrect(api);
            }

        }
        public static void FlexPlayer(PlayerMode playerMode)
        {
            Misc.ClearAsciiLogoV();
            API api = new API();
            try
            {
                SetMax(api);
                SetMin(api);
                SetAllowedGuesses(api);
                if (playerMode == PlayerMode.single)
                {
                    Console.WriteLine("Choosing correct answer randomly...");
                    api.SetCorrectRandom();
                }
                else if (playerMode == PlayerMode.multi) { SetCorrect(api); }
                Guess(api);
                Console.ReadLine();
            } catch (Misc.QuitException) { }
            UI.Main(new string[0]);
        }
    }
}
