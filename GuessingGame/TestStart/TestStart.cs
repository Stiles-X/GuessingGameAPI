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
                Correct = 5
            };
            bool correct = game.Guess(6);
            Console.WriteLine($"The answer is {correct}!");
            Console.Read();
        }
    }
}
