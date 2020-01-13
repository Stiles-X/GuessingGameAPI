using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;

namespace GuessingGame.UI
{
    using Core.Exceptions;
    using System.Threading;

    enum PlayerMode
    {
        single,
        multi
    }
    class Game
    {
        private static bool Guess(API api)
        {
            if (api.GetOutOfGuesses()) { Console.WriteLine("Sorry, you ran out of tries");}
            else
            {
                try
                {
                    int answer = Misc.intput($"{api.GetLeftGuesses()} Gs left. " +
                        $"Guess between {api.GetMax()} and {api.GetMin()}: ");
                    if (api.Guess(answer))
                    {
                        Console.WriteLine("Congratulations, you did it!Incredible job!"
                            + $"\n{Stats(api)}");
                        return true;
                    }
                    else { Guess(api); }
                }
                catch (PropertyNotSetException)
                {
                    Console.WriteLine("'Correct' or 'Allowed Guesses' has not been set");
                    Guess(api);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Your guess was outside of Max and Min range");
                    Guess(api);
                }
            }
            Thread.Sleep(2000);
            return false;
        }
        private static string Stats(API api) =>
            $"From a game of {api.GetAllowedGuesses()} guesses, between {api.GetMax()} and {api.GetMin()},\n"+
            $"You won with {api.GetUsedGuesses()} guesses or {api.GetLeftGuesses()} guesses left";
        private static void SetMin(API api)
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
        private static void SetMax(API api)
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
        private static void SetAllowedGuesses(API api)
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
        private static void SetCorrect(API api)
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
        public static void FlexPlayer(PlayerMode playerMode = PlayerMode.single, int? Max = null,
            int? Min = null, int? Correct = null, int? AllowedGuesses = null, int? UsedGuesses = null)
        {
            Misc.ClearAsciiLogoV();
            API api = new API();
            try
            {
                if (Max.HasValue) api.SetMax((int)Max);
                else SetMax(api);
                if (Min.HasValue) api.SetMin((int)Min);
                else SetMin(api);
                if (Correct.HasValue) api.SetCorrect((int)Correct);
                else
                {
                    if (playerMode == PlayerMode.single)
                    {
                        Console.WriteLine("Choosing correct answer randomly...");
                        api.SetCorrectRandom();
                    }
                    else if (playerMode == PlayerMode.multi) { SetCorrect(api); }
                }
                if (AllowedGuesses.HasValue) api.SetAllowedGuesses((int)AllowedGuesses);
                else SetAllowedGuesses(api);
                if (UsedGuesses.HasValue) api.SetUsedGuesses((int)UsedGuesses);
                Misc.ClearAsciiLogoV();
                bool GuessCorrect = Guess(api);
                Misc.ClearAsciiLogoV();
                QuitOptions(api, GuessCorrect, playerMode, api.GetMax(), api.GetMin(), api.GetCorrect("longlongman"),
                    api.GetAllowedGuesses(), api.GetUsedGuesses());

            } catch (Misc.QuitException) { }
            UI.Main(new string[0]);
        }
        private static void QuitOptions(API api, bool GuessCorrect, PlayerMode playerMode = PlayerMode.single,
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
            string s = Misc.input(question).ToLower();
            if (Misc.Exist(new[] { "c", "cls", "clear" }, s))
                Misc.ClearAsciiLogoV();
            else if (Misc.Exist(new[] { "q", "quit", "e", "exit" }, s))
                throw new Misc.QuitException();
            else if (s == "o" & (!GuessCorrect))
                FlexPlayer(playerMode, Max, Min, Correct, AllowedGuesses + 1, UsedGuesses);
            else if (s == "r" & (GuessCorrect))
            {
                Misc.ClearAsciiLogoV();
                Console.WriteLine(Stats(api)+"\n");
            }
            else if (Misc.Exist(new[] { "t", "tell" }, s))
            {
                Misc.ClearAsciiLogoV();
                Console.WriteLine("Correct answer is: " + api.GetCorrect(pw: "longlongman") + "\n");
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
            QuitOptions(api, GuessCorrect, playerMode, Max, Min, Correct, AllowedGuesses, UsedGuesses);
        }
    }
}
