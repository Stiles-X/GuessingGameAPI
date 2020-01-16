using System;
using System.Diagnostics.Contracts;
using APIProject.Interfaces;

namespace APIProject.Extensions.OutOfGuesses
{
    public static class OutOfGuessesExtension
    {
        #pragma warning disable CA1303 // Do not pass literals as localized parameters
        public static bool IsOutOfGuesses(this IAPI api)
        {
            Contract.Requires(api != null);
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
