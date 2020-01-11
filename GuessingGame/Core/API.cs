using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.Core
{
    class SinglePlayer
    {
        public SinglePlayer()
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
    }
}
