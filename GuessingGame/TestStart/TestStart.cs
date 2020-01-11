using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;

namespace GuessingGame
{
    class TestStart
    {
        public static void TestMain()
        {
            API api = new API(GameMode.locked);
            
            api.SetMax(10);
            api.SetMax(6);
            api.SetMin(1);
            api.SetCorrectRandom();
            api.SetAllowedGuesses(5);
            bool correct;
            try
            {
                do { correct = GuessTest(api.GetRandom(), api); }
                while (!correct);
            } catch (ArgumentException) { Console.WriteLine("Out of guesses"); }

            Console.Read();
        }
        public static bool GuessTest(int guess, API api)
        {
            Console.WriteLine($"We have {api.GetAllowedGuesses() - api.GetUsedGuesses()} guesses left!");
            bool correct = api.Guess(guess);
            Console.WriteLine($"We guessed {guess.ToString()} and the answer is {correct}!");
            return correct;
        }
        /*
        public static void GuessTest(int guess, CoreGame game)
        {
            Console.WriteLine($"We have {game.AllowedGuesses - game.UsedGuesses} guesses left!");
            bool correct = game.Guess(guess);
            Console.WriteLine($"We guessed {guess.ToString()} and the answer is {correct}!");
        } */
    }
}
