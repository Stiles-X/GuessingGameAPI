using System;
using System.Collections.Generic;
using System.Text;
using APIProject;
using APIProject.Extensions.HelperFunctions;
using APIProject.Extensions.OutOfGuesses;
using APIProject.Interfaces;
using ConsoleUI.GameHelper;

namespace ConsoleUI
{
    class Game
    {
        private IAPI API { get; set; }
        private bool IsSingle { get; set; } = true;

        // Start Game
        private void Play()
        {
            StoreNewAPI();
            AskInfo();
            Inform(Guess());
        }
        private void AskInfo()
        {
            GameAsk.AskMax(API);
            GameAsk.AskMin(API);
            if (IsSingle)
            {
                GameAsk.AskCorrect(API);
            }
            else
            {
                API.SetCorrectRandom();
            }
            GameAsk.AskAllowedGuesses(API);
        }
        private bool Guess()
        {
            do
            {
                if (GameAsk.Guess(API))
                {
                    return true;
                }
            } while (!API.IsOutOfGuesses());
            return false;
        }
        private void Inform(bool IsGameWon)
        {
            if (IsGameWon)
            {
                Console.WriteLine("Congratulations, you guessed correctly");
            }
            else
            {
                Console.WriteLine("Sorry, better luck next time");
            }
        }
        private void StoreNewAPI()
        {
            API = new API(new Model());
        }

        // Calls Play
        public void PlayTwoPlayers()
        {
            IsSingle = false;
            Play();
        }
        public void PlaySinglePlayer()
        {
            Play();
        }

        // Extra Functions
        /*private void DisplayState()
        {
            Console.WriteLine($"Max: {API.GetMax()}");
            Console.WriteLine($"Min: {API.GetMin()}");
        }*/
    }
}
