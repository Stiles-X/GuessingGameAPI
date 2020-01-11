using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.Core
{
    public enum GameMode
    {
        sp, // Single-Player
        mp  // Multi-Player
    }
    class API
    {
        public API(GameMode mode)
        {
            _CoreGame = new CoreGame();
            _GameMode = mode;
        }
        // GameMode
        public GameMode _GameMode { get; set; }

        // Game (storing a game instance)
        private CoreGame _CoreGame { get; set; }

        // MAX - GET / SET
        public int? GetMax() { return _CoreGame.Max; }
        public void SetMax(int Max) { _CoreGame.Max = Max; }

        // MIN - GET / SET
        public int? GetMin() { return _CoreGame.Min; }
        public void SetMin(int Min) { _CoreGame.Min = Min; }

        // Correct - GET / SET
        public int? GetCorrect() { return _CoreGame.Correct; }
        private bool _IsCorrectSet { get; set; }
        public void SetCorrect(int Correct)
        {
            if (_IsCorrectSet)  // Checking so that you can only set Correct one time
                throw new ArgumentException("You have already set the correct answer");
            _IsCorrectSet = true;
            _CoreGame.Correct = Correct;
        }
        public void SetCorrectRandom()  // So that you can play single player
        {
            SetCorrect(_CoreGame.Random);
        }

        // Guess
        public bool Guess(int guess) { return _CoreGame.Guess(guess); }

        // TO BE USED WITH GUESS
        // Allowed Guesses - GET / SET
        public void SetAllowedGuesses(int amount) { _CoreGame.AllowedGuesses = amount; }
        public int? GetAllowedGuesses() { return _CoreGame.AllowedGuesses; }
        // Used Guesses - GET
        public int GetUsedGuesses() { return _CoreGame.UsedGuesses; }

        // Random - GET
        public int GetRandom() { return _CoreGame.Random; }
    }
}
