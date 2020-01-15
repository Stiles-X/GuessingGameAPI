using System;
using System.Collections.Generic;
using System.Text;
using APIProject.Interfaces;

namespace APIProject.Extensions.OutOfGuesses
{
    public static class OutOfGuessesExtension
    {
        public static bool IsOutOfGuesses(this IAPI api)
        {
            int leftGuesses = api.GetAllowedGuesses() - api.GetUsedGuesses();
            if (leftGuesses > 0)
            {
                return false;
            }
            else if (leftGuesses == 0)
            {
                return true;
            }
            throw new InvalidOperationException("LeftGuesses should not be less than 0");
        }
    }
}
