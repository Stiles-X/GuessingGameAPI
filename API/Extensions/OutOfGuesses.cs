using System;
using System.Collections.Generic;
using System.Text;
using API.Interfaces;

namespace API.Extensions.OutOfGuesses
{
    public static class OutOfGuessesExtension
    {
        public static bool IsOutOfGuesses(this IAPI api)
        {
            int LeftGuesses = api.GetAllowedGuesses() - api.GetUsedGuesses();
            if (LeftGuesses > 0)
            {
                return true;
            }
            else if (LeftGuesses == 0)
            {
                return false;
            }
            throw new InvalidOperationException("LeftGuesses should not be less than 0");
        }
    }
}
