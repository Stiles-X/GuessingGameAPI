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
            SetCorrect(GetRandom());
        }

        // Guess
        public bool Guess(int guess) { return _CoreGame.Guess(guess); }

        // TO BE USED WITH GUESS
        // Allowed Guesses - GET / SET
        public int? GetAllowedGuesses() { return _CoreGame.AllowedGuesses; }
        public void SetAllowedGuesses(int amount)
        {
            if (_IsAllowedGuessesSet & (_LockMode == LockMode.locked))  // Checking so that you can only set AllowedGuesses one time
                throw new ForbiddenException("AllowedGuesses", "You have already set the allowed guesses, and the game mode is locked.");
            _CoreGame.AllowedGuesses = amount;
            _IsAllowedGuessesSet = true;
        }
        private bool _IsAllowedGuessesSet { get; set; }
        // Used Guesses - GET / SET
        public int GetUsedGuesses() { return _CoreGame.UsedGuesses; }
        public void SetUsedGuesses(int amount)
        {
            if ((_LockMode == LockMode.locked))  // Checking so that you can only set UsedGuesses one time
                throw new ForbiddenException("UsedGuesses", "The game mode is locked.");
            _CoreGame.UsedGuesses = amount;
        }

        // Left Guesses - GET
        public int GetLeftGuesses()
        {
            if (!(GetAllowedGuesses().HasValue))
                throw new PropertyNotSetException("AllowedGuesses", "You haven't set AllowedGuesses yet");
            return (int)GetAllowedGuesses() - GetUsedGuesses();
        }
        // Out of Guesses - GET
        public bool GetOutOfGuesses()
        {
            if (GetLeftGuesses() > 0) { return false; }
            else if (GetLeftGuesses() == 0) { return true; }
            throw new InvalidOperationException("Left guesses can't be negative," + @"https://xkcd.com/2200/");
        }
        // Random - GET
        public int GetRandom()
        {
            if (!(GetMax().HasValue)) // Check if min or max have been set, if so
                throw new PropertyNotSetException("Max", "Max value has not been set");
            if (!(GetMin().HasValue))
                throw new PropertyNotSetException("Min", "Min value has not been set");
            return new System.Random().Next((int)GetMin(), (int)GetMax() + 1); // Our guessing game max is inclusive, rand's max is exclusive so we must plus 1
        }
    }
}
