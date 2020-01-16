using System;
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
            AssertAPINotNull();
            GameAsk.AskMax(API);
            GameAsk.AskMin(API);
            if (IsSingle)
            {
                string[] objects = new string[]
                { "The magic mirror", "Donald Trump", "Your mom", "Area 51", "Ricardo", "Pewdiepie",
                "The cosmic background radiation", "Batman", "Peanut Butter"};
                string person = (string)objects.GetValue(new Random().Next(objects.Length));
                Console.WriteLine($"{person} is setting the correct answer");
                API.SetCorrectRandom();
            }
            else
            {
                GameAsk.AskCorrect(API);
            }
            GameAsk.AskAllowedGuesses(API);
        }
        private bool Guess()
        {
            AssertAPINotNull();
            do
            {
                if (GameAsk.Guess(API))
                {
                    return true;
                }
            } while (!API.IsOutOfGuesses());
            return false;
        }
        private void Inform(bool isGuessCorrect)
        {
            AssertAPINotNull();
            if (isGuessCorrect)
            {
                Console.WriteLine("Congratulations, you guessed correctly");
            }
            else
            {
                Console.WriteLine($"Sorry, better luck next time. The correct answer is {API.GetCorrect()}");
            }
        }
        private void StoreNewAPI()
        {
            API = new APIProject.API(new APIProject.Model());
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
        private void AssertAPINotNull()
        {
            if (API == null)
            {
                throw new InvalidOperationException("API cannot be null");
            }
        }
    }
}
