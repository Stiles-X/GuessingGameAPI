using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.Core
{
    using Exceptions;
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
                        throw new ArgumentOutOfRangeException("Max", "Max cannot be less than Min"); // is less than min
                if (_Correct.HasValue) // Check if Correct has been set, if so
                    if (value < _Correct)
                        throw new ArgumentOutOfRangeException("Max", "Max cannot be less than Correct"); // is less than correct
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
                        throw new ArgumentOutOfRangeException("Min", "Min cannot be more than Max"); // is less than max
                if (_Correct.HasValue) // Check if Correct has been set, if so
                    if (value > _Correct)
                        throw new ArgumentOutOfRangeException("Min", "Min cannot be more than Correct"); // is more than correct
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
                if (!(_Max.HasValue)) // Check if min or max have been set, if so
                    throw new PropertyNotSetException("Max", "Max value has not been set");
                if (!(_Min.HasValue))
                    throw new PropertyNotSetException("Min", "Min value has not been set");
                if ((value > _Max) | (value < _Min)) // Check if value is {read the code}
                    throw new ArgumentOutOfRangeException("value", "Correct can not be outside of max and min range"); // value out of range
                _Correct = value; // Then set
            }
        }

        // Guess (the method acting)
        public bool Guess(int guess)
        {
            if (!_Correct.HasValue)
                throw new PropertyNotSetException("Correct", "Correct has not been set");
            if ((guess > _Max) | (guess < _Min))
                throw new ArgumentOutOfRangeException("guess", "Your guess was outside of max and min range");
            if (_AllowedGuesses.HasValue)
            {
                if (_UsedGuesses >= _AllowedGuesses)
                    throw new OutOfTriesException("You are out of guesses");
            }
            else
                throw new PropertyNotSetException("AllowedGuesses", "You haven't set AllowedGuesses yet");
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
        private int? _AllowedGuesses { get; set; }
        public int? AllowedGuesses
        {
            get { return _AllowedGuesses; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("AllowedGuesses", "Number of Allowed guesses can not be less than 0");
                _AllowedGuesses = value;
            }
        }
        // Used Guesses
        private int _UsedGuesses { get; set; }
        public int UsedGuesses
        {
            get { return _UsedGuesses; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("UsedGuesses", "Number of used guesses can not be less than 0");
                if (value > _AllowedGuesses)
                    throw new ArgumentOutOfRangeException("UsedGuesses", "Number of used guesses can not be more than allowed guesses");
                _UsedGuesses = value;
            }
        }
        // Left Guesses
        public int LeftGuesses
        {
            get 
            {
                if (!(_AllowedGuesses.HasValue))
                    throw new PropertyNotSetException("AllowedGuesses", "You haven't set AllowedGuesses yet");
                return (int)_AllowedGuesses - _UsedGuesses; 
            }
        }
        // Out Of Guesses
        public bool OutOfGuesses
        {
            get
            {
                if (LeftGuesses > 0) { return false; }
                else if (LeftGuesses == 0) { return true; }
                throw new InvalidOperationException("Left guesses can't be negative," + @"https://xkcd.com/2200/");
            }
        }

        // Random (generate a valid int guess from max min range)
        public int Random
        {
            get
            {
                if (!(_Max.HasValue)) // Check if min or max have been set, if so
                    throw new PropertyNotSetException("Max", "Max value has not been set");
                if (!(_Min.HasValue))
                    throw new PropertyNotSetException("Min", "Min value has not been set");
                return new System.Random().Next((int)_Min, (int)_Max + 1); // Our guessing game max is inclusive, rand's max is exclusive so we must plus 1
            }
        }
    }
}
