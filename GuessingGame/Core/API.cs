using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.Core
{
    class API
    {
        public API()
        {
            _CoreGame = new CoreGame();
        }

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


    }
}
