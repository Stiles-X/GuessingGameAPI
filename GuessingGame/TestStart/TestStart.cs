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
            API api = new API(GameMode.sp);
            
            api.SetMax(10);
            api.SetMin(1);
            api.SetCorrectRandom();
            api.SetAllowedGuesses(5);

            GuessTest(api.GetRandom(), api);
            GuessTest(api.GetRandom(), api);
            GuessTest(api.GetRandom(), api);

            Console.Read();
        }
        public static void GuessTest(int guess, API api)
        {
            Console.WriteLine($"We have {api.GetAllowedGuesses() - api.GetUsedGuesses()} guesses left!");
            bool correct = api.Guess(guess);
            Console.WriteLine($"We guessed {guess.ToString()} and the answer is {correct}!");
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
