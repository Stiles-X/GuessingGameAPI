using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;

namespace GuessingGame.UI
{
    enum GameMode
    {
        s,
        m
    }
    class Game
    {
        private static void Guess(API api)
        {
            int answer = CommonData.intput(
                    $"{api.GetLeftGuesses()} guesses left. Choose between (including) {api.GetMin()} and {api.GetMax()}: "
                    );
            if (api.GetLeftGuesses() > 0)
            {
                bool Correct = api.Guess(answer);
                if (Correct) { Console.WriteLine("Congratulations, you did it! Incredible job!"); }
                else { Guess(api); }
            }   else { Console.WriteLine("Sorry, you ran out of tries"); }
        }

        public static void FlexPlayer(GameMode gameMode)
        {
            API api = new API();
            api.SetMin(CommonData.intput("Enter Min Number: "));
            api.SetMax(CommonData.intput("Enter Max Number: "));
            api.SetAllowedGuesses(CommonData.intput("Enter Number of Guesses: "));
            if (gameMode == GameMode.s)
            {
                Console.WriteLine("Choosing correct answer randomly...");
                api.SetCorrectRandom();
            } else if (gameMode == GameMode.m)
            {
                api.SetCorrect(CommonData.intput("Enter 'Correct' Number: "));
            }
            Guess(api);
            Console.ReadLine();
            UI.Main(new string[0]);
        }
    }
}
