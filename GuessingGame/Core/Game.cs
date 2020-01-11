using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.Core
{
    class Game
    {
        // Max
        private int? _Max { get; set; }
        public int? Max
        {
            get { return _Max; }
            set
            {
                if (_Min.HasValue) // Check if Min have been set, if so
                    if (value <= _Min) // Check if the number we are trying to set as max
                        throw new ArgumentOutOfRangeException(); // is less than min
                _Max = value; // Then set _Max as the value
            }
        }

        // Min
        private int? _Min { get; set; }
        public int? Min
        {
            get { return _Min; }
            set
            {
                if (_Max.HasValue) // Check if Max have been set, if so
                    if (value >= _Max) // Check if the number we are trying to set as min
                        throw new ArgumentOutOfRangeException(); // is less than max
                _Min = value; // Then set _Min as the value
            }
        }

    }
}
