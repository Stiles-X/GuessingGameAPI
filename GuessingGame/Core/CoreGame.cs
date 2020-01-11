using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.Core
{
    class CoreGame
    {
        // Max
        private int? _Max { get; set; }
        public int? Max
        {
            get { return _Max; }
            set
            {
                if (_Min.HasValue) // Check if Min have been set, if so
                    if (value < _Min) // Check if the number we are trying to set as max
                        throw new ArgumentOutOfRangeException("Min", "Min cannot be more than Max"); // is less than min
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
                    if (value > _Max) // Check if the number we are trying to set as min
                        throw new ArgumentOutOfRangeException("Max", "Max cannot be more than Min"); // is less than max
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
                if (!(_Max.HasValue | _Min.HasValue)) // Check if min or max have been set, if so
                    throw new ArgumentNullException("Max, Min", "Max or Min value has not been set");
                if ((value > _Max) | (value < _Min)) // Check if value is {read the code}
                    throw new ArgumentOutOfRangeException("value", "Correct can not be outside of max and min range"); // value out of range
                _Correct = value; // Then set
            }
        }

        // Guess (the method acting)
        public bool Guess(int guess)
        {
            if (!_Correct.HasValue)
                throw new ArgumentNullException("Correct", "Correct has not been set");
            if ((guess > _Max) | (guess < _Min))
                throw new ArgumentOutOfRangeException("guess", "Your guess was outside of max and min range");
            if (AllowedGuesses.HasValue)
            {
                if (_UsedGuesses >= AllowedGuesses)
                    throw new ArgumentException("You are out of guesses");
            }
            else
                throw new ArgumentNullException("AllowedGuesses", "You haven't set AllowedGuesses yet");
            bool result;
            if (guess == _Correct)
                result = true;
            else
                result = false;
            UsedGuesses = _UsedGuesses + 1;
            return result;
        }

        // TO BE USED WITH GUESSES
        // Allowed Guesses
        public int? AllowedGuesses { get; set; }
        // Used Guesses
        private int _UsedGuesses { get; set; }
        public int UsedGuesses
        {
            get { return _UsedGuesses; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("UsedGuesses", "Number of used guesses can not be less than 0");
                if (value > AllowedGuesses)
                    throw new ArgumentOutOfRangeException("UsedGuesses", "Number of used guesses can not be more than allowed guesses");
                _UsedGuesses = value;
            }
        }

        // Random (generate a valid int guess from max min range)
        public int Random
        {
            get
            {
                if (!(_Max.HasValue | _Min.HasValue)) // Check if min or max have been set, if so
                    throw new ArgumentNullException("Max, Min", "Max or Min value has not been set");
                System.Random random = new System.Random();
                int Max = _Max ?? default;
                int Min = _Min ?? default;
                return random.Next(Min, Max + 1); // Our guessing game max is inclusive, rand's max is exclusive so we must plus 1
            }
        }
    }
}
