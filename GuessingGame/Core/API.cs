using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.Core
{
    using Exceptions;
    public enum LockMode
    {
        unlocked, // Single-Player
        locked  // Multi-Player
    }
    class API
    {
        public API(LockMode mode = LockMode.locked)
        {
            _CoreGame = new CoreGame();
            _LockMode = mode;
        }
        // LockMode
        private LockMode _LockMode { get; set; }

        // Game (storing a game instance)
        private CoreGame _CoreGame { get; set; }

        // MAX - GET / SET
        public int? GetMax() { return _CoreGame.Max; }
        private bool _IsMaxSet { get; set; }
        public void SetMax(int Max)
        {
            if (_IsMaxSet & (_LockMode == LockMode.locked))
                throw new ForbiddenException("Max", "You have already set the max value, and the game mode is locked.");
            _CoreGame.Max = Max;
            _IsMaxSet = true;
        }

        // MIN - GET / SET
        public int? GetMin() { return _CoreGame.Min; }
        private bool _IsMinSet { get; set; }
        public void SetMin(int Min) 
        {
            if (_IsMinSet & (_LockMode == LockMode.locked))
                throw new ForbiddenException("Min", "You have already set the min value, and the game mode is locked.");
            _CoreGame.Min = Min;
            _IsMinSet = true;
        }

        // Correct - GET / SET
        public int? GetCorrect() { return _CoreGame.Correct; }
        private bool _IsCorrectSet { get; set; }
        public void SetCorrect(int Correct)
        {
            if (_IsCorrectSet & (_LockMode == LockMode.locked))  // Checking so that you can only set Correct one time
                throw new ForbiddenException("Correct", "You have already set the correct answer, and the game mode is locked.");
            _CoreGame.Correct = Correct;
            _IsCorrectSet = true;
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
        // Left Guesses - GET
        public int GetLeftGuesses() { return _CoreGame.LeftGuesses; }
        // Out of Guesses - GET
        public bool GetOutOfGuesses() { return _CoreGame.OutOfGuesses; }
        // Random - GET
        public int GetRandom() { return _CoreGame.Random; }
    }
}
