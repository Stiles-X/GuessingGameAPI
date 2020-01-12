using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;

namespace GuessingGame.UI
{
    using Core.Exceptions;
    enum PlayerMode
    {
        s,
        m
    }
    class Game
    {
        private static void Guess(API api)
        {
            if (api.GetOutOfGuesses()) { Console.WriteLine("Sorry, you ran out of tries"); }
            else
            {
            int answer = Misc.intput(
                $"{api.GetLeftGuesses()} guesses left. Choose between (including) {api.GetMin()} and {api.GetMax()}: "
                );
            
            bool Correct = api.Guess(answer);
            if (Correct) { Console.WriteLine("Congratulations, you did it! Incredible job!"); }
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
        public static void FlexPlayer(PlayerMode playerMode)
        {
            Misc.ClearAsciiLogoV();
            API api = new API();
            try
            {
                SetMin(api);
                SetMax(api);
                SetAllowedGuesses(api);
                if (playerMode == PlayerMode.s)
                {
                    Console.WriteLine("Choosing correct answer randomly...");
                    api.SetCorrectRandom();
                }
                else if (playerMode == PlayerMode.m)
                {
                    api.SetCorrect(Misc.intput("Enter 'Correct' Number: "));
                }
                Guess(api);
                Console.ReadLine();
            } catch (Misc.QuitException) { }
            UI.Main(new string[0]);
        }
    }
}
