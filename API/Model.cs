using System;
using System.Collections.Generic;
using System.Text;
using APIProject.Exceptions;
namespace APIProject
{
    public class Model : Interfaces.IModel
    {
        // Max
        private int? _Max { get; set; }
        public int Max
        {
            get
            {
                if (!(_Max.HasValue))
                {
                    throw new PropertyNotSetException("Max", "Max value has not been set");
                }
                return (int)_Max;
            }
            set
            {
                if (value < Min) // Check if the number we are trying to set as max
                {
                    throw new ArgumentOutOfRangeException("Max", "Max cannot be less than Min"); // is less than min
                }
                if (value < Correct)
                {
                    throw new ArgumentOutOfRangeException("Max", "Max cannot be less than Correct"); // is less than correct
                }
                _Max = value; // Then set _Max as the value
            }
        }

        // Min
        private int? _Min { get; set; }
        public int Min
        {
            get
            {
                if (!(_Min.HasValue))
                {
                    throw new PropertyNotSetException("Min", "Min value has not been set");
                }
                return (int)_Min;
            }
            set
            {
                if (value > Max) // Check if the number we are trying to set as min
                {
                    throw new ArgumentOutOfRangeException("Min", "Min cannot be more than Max"); // is less than max
                }
                if (value > Correct)
                {
                    throw new ArgumentOutOfRangeException("Min", "Min cannot be more than Correct"); // is more than correct
                }
                _Min = value; // Then set _Min as the value
            }
        }

        // Correct "Correct answer / guess"
        private int? _Correct { get; set; }
        public int Correct
        {
            get
            {
                if (!_Correct.HasValue)
                {
                    throw new PropertyNotSetException("Correct", "Correct has not been set");
                }
                return (int)_Correct;
            }
            set
            {
                if ((value > Max) | (value < Min)) // Check if value is out of range
                {
                    throw new ArgumentOutOfRangeException("value", "Correct can not be outside of max and min range"); // value out of range
                }
                _Correct = value; // Then set
            }
        }

        // Allowed Guesses
        private int? _AllowedGuesses { get; set; }
        public int AllowedGuesses
        {
            get
            {
                if (!_AllowedGuesses.HasValue)
                {
                    throw new PropertyNotSetException("AllowedGuesses", "You haven't set AllowedGuesses yet");
                }
                return (int)_AllowedGuesses;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("AllowedGuesses", "Number of Allowed guesses can not be less than 0");
                }
                _AllowedGuesses = value;
            }
        }
        // Used Guesses
        private int _UsedGuesses { get; set; }
        public int UsedGuesses
        {
            get
            {
                return _UsedGuesses;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("UsedGuesses", "Number of used guesses can not be less than 0");
                }
                if (value > AllowedGuesses)
                {
                    throw new ArgumentOutOfRangeException("UsedGuesses", "Number of used guesses can not be more than allowed guesses");
                }
                _UsedGuesses = value;
            }
        }
    }
}
