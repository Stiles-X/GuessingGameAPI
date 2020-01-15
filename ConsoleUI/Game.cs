using System;
using System.Collections.Generic;
using System.Text;
using API;
using API.Interfaces;
using API.Extensions.HelperFunctions;
using API.Extensions.OutOfGuesses;
using API.Exceptions;
using System.Threading;
using GuessingGame.UI;

namespace ConsoleUI
{
    enum PlayerMode
    {
        single,
        multi
    }
    class Game
    {
        private static bool Guess(IAPI IAPI)
        {
            bool Correct = false;
            if (IAPI.IsOutOfGuesses()) { Console.WriteLine("Sorry, you ran out of tries");}
            else
            {
                try
                {
                    int answer = Misc.intput($"{IAPI.GetLeftGuesses()} Gs left. " +
                        $"Guess between {IAPI.GetMax()} and {IAPI.GetMin()}: ");
                    Correct = IAPI.Guess(answer);
                    if (Correct)
                    {
                        Console.WriteLine("Congratulations, you did it!Incredible job!"
                            + $"\n{Stats(IAPI)}");
                    }
                    else { Guess(IAPI); }
                }
                catch (PropertyNotSetException)
                {
                    Console.WriteLine("'Correct' or 'Allowed Guesses' has not been set");
                    Guess(IAPI);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Your guess was outside of Max and Min range");
                    Guess(IAPI);
                }
            }
            Thread.Sleep(1000);
            return Correct;
        }
        private static string Stats(IAPI IAPI) =>
            $"From a game of {IAPI.GetAllowedGuesses()} guesses, between {IAPI.GetMax()} and {IAPI.GetMin()},\n"+
            $"You won with {IAPI.GetUsedGuesses()} guesses or {IAPI.GetLeftGuesses()} guesses left";
        private static void SetMin(IAPI IAPI)
        {
            try
            {
                IAPI.SetMin(Misc.intput("Enter Min Number: "));
            }
            catch (ForbiddenException)
            {
                Console.WriteLine("You have already set min, and LockMode is 'on'");
                SetMin(IAPI);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You attempted min value is more than selected Max, or 'Correct'");
                SetMin(IAPI);
            }
        }
        private static void SetMax(IAPI IAPI)
        {
            try
            {
                IAPI.SetMax(Misc.intput("Enter Max Number: "));
            }
            catch (ForbiddenException)
            {
                Console.WriteLine("You have already set Max, and LockMode is 'on'");
                SetMax(IAPI);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("You attempted Max value is less than selected Min, or 'Correct'");
                SetMax(IAPI);
            }
        }
        private static void SetAllowedGuesses(IAPI IAPI)
        {
            try
            {
                IAPI.SetAllowedGuesses(Misc.intput("Enter Number of Guesses: "));
            } catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number of guesses can only be whole numbers");
                SetAllowedGuesses(IAPI);
            }
            
        }
        private static void SetCorrect(IAPI IAPI)
        {
            try
            {
                IAPI.SetCorrect(Misc.intput("Enter 'Correct' Number: "));
            }
            catch (PropertyNotSetException)
            {
                Console.WriteLine("Max or Min hasn't been set yet.");
                SetCorrect(IAPI);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Value must be max >= value >= min");
                SetCorrect(IAPI);
            }

        }
        public static void FlexPlayer(PlayerMode playerMode = PlayerMode.single, int? Max = null,
            int? Min = null, int? Correct = null, int? AllowedGuesses = null, int? UsedGuesses = null)
        {
            Misc.ClearAsciiLogoV();
            IAPI IAPI = new API.API(new API.Model());
            try
            {
                if (Max.HasValue) IAPI.SetMax((int)Max);
                else SetMax(IAPI);
                if (Min.HasValue) IAPI.SetMin((int)Min);
                else SetMin(IAPI);
                if (Correct.HasValue) IAPI.SetCorrect((int)Correct);
                else
                {
                    if (playerMode == PlayerMode.single)
                    {
                        Console.WriteLine("Choosing correct answer randomly...");
                        IAPI.SetCorrectRandom();
                    }
                    else if (playerMode == PlayerMode.multi) { SetCorrect(IAPI); }
                }
                if (AllowedGuesses.HasValue) IAPI.SetAllowedGuesses((int)AllowedGuesses);
                else SetAllowedGuesses(IAPI);
                if (UsedGuesses.HasValue) IAPI.SetUsedGuesses((int)UsedGuesses);
                Misc.ClearAsciiLogoV();
                bool GuessCorrect = Guess(IAPI);
                Misc.ClearAsciiLogoV();
                QuitOptions(IAPI, GuessCorrect, ClearScreen: false, playerMode, IAPI.GetMax(), IAPI.GetMin(), IAPI.GetCorrect(),
                    IAPI.GetAllowedGuesses(), IAPI.GetUsedGuesses());

            } catch (Misc.QuitException) { }
            UI.Main(new string[0]);
        }
        private static void QuitOptions(IAPI IAPI, bool GuessCorrect, bool ClearScreen = false, PlayerMode playerMode = PlayerMode.single,
            int? Max = null, int? Min = null, int? Correct = null,
            int? AllowedGuesses = null, int? UsedGuesses = null)
        {
            string question = string.Empty;
            if (!GuessCorrect)
                question += "(o)ne more guess please\n";
            else
                question += "(r)esult of the match\n";
            question += "(t)ell correct answer\n";
            question += "play (a)gain, same answer\n";
            question += "new (s)ingle player match\n";
            question += "new (m)ulti player match\n";
            question += "(q)uit to main menu\n";
            question += "(c)lear screen\n";
            question += "bring up this (h)elp menu\n";
            string s = Misc.input(question, !ClearScreen).ToLower();
            ClearScreen = false;
            if (Misc.Exist(new[] { "c", "cls", "clear" }, s))
            {
                Misc.ClearAsciiLogoV();
                ClearScreen = true;
            }
            else if (Misc.Exist(new[] { "h", "help" }, s))
                Misc.ClearAsciiLogoV();
            else if (Misc.Exist(new[] { "q", "quit", "e", "exit" }, s))
                throw new Misc.QuitException();
            else if (s == "o" & (!GuessCorrect))
                FlexPlayer(playerMode, Max, Min, Correct, AllowedGuesses + 1, UsedGuesses);
            else if (s == "r" & (GuessCorrect))
            {
                Misc.ClearAsciiLogoV();
                Console.WriteLine(Stats(IAPI) + "\n");
            }
            else if (Misc.Exist(new[] { "t", "tell" }, s))
            {
                Misc.ClearAsciiLogoV();
                Console.WriteLine("Correct answer is: " + IAPI.GetCorrect(pw: "longlongman") + "\n");
            }
            else if (Misc.Exist(new[] { "a", "again" }, s))
            {
                FlexPlayer(playerMode, Max, Min, Correct, AllowedGuesses);
            }
            else if (Misc.Exist(new[] { "s", "single" }, s))
            {
                FlexPlayer(PlayerMode.single);
            }
            else if (Misc.Exist(new[] { "m", "multi" }, s))
            {
                FlexPlayer(PlayerMode.multi);
            }
            else
            {
                Console.WriteLine("Please enter a valid input");
            }
            QuitOptions(IAPI, GuessCorrect, ClearScreen, playerMode, Max, Min, Correct, AllowedGuesses, UsedGuesses);
        }
    }
}
