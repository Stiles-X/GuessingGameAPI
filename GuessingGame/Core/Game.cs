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

        // Correct "Correct answer / guess"
        private int? _Correct { get; set; }
        public int? Correct
        {
            get { return _Correct; }
            set
            {
                if (_Max.HasValue & _Min.HasValue) // Check if min or max have been set, if so
                {
                    if ((value >= _Max) | (value <= _Min)) // Check if value is {read the code}
                        throw new ArgumentOutOfRangeException(); // value out of range
                    _Correct = value; // Then set
                }
                else
                    throw new ArgumentNullException("Max and Min value has not been set");
            }
        }
    }
}
