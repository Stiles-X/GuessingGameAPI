using API.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core
{
    class APIWithCustomLogic : API
    {
        public APIWithCustomLogic(IModel Model) : base(Model)
        {
        }

        // Guess
        public new bool Guess(int Guess)
        {
            if ((Guess > GetMax()) | (Guess < GetMin()))
            {
                throw new ArgumentOutOfRangeException("guess", "Your guess was outside of max and min range");
            }

            if (GetUsedGuesses() >= GetAllowedGuesses())
            {
                throw new Exceptions.OutOfTriesException("You are out of guesses");
            }
            SetUsedGuesses(GetUsedGuesses() + 1);
            return (Guess == GetCorrect());
        }
    }
}
