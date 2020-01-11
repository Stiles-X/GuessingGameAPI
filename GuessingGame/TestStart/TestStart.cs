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
            Game game = new Game
            {
                Min = 1,
                Max = 10,
                Correct = 5,
                AllowedGuesses = 5
            };
            GuessTest(3, game);
            GuessTest(7, game);
            GuessTest(5, game);
            Console.Read();
        }
        public static void GuessTest(int guess, Game game)
        {
            Console.WriteLine($"We have {game.AllowedGuesses - game.UsedGuesses} guesses left!");
            bool correct = game.Guess(guess);
            Console.WriteLine($"We guessed {guess.ToString()} and the answer is {correct}!");
        }
    }
}
