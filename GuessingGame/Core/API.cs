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

    }
}
