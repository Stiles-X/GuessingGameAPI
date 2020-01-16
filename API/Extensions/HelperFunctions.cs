using APIProject.Interfaces;
using System;
using System.Diagnostics.Contracts;

namespace APIProject.Extensions.HelperFunctions
{
    public static class HelperFunctions
    {
        public static int GetRandom(this IAPI api)
        {
            Contract.Requires(api != null);
            return new Random().Next(api.GetMin(), api.GetMax() + 1);
        }
        public static void SetCorrectRandom(this IAPI api)
        {
            Contract.Requires(api != null);
            api.SetCorrect(api.GetRandom());
        }
        public static int GetLeftGuesses(this IAPI api)
        {
            Contract.Requires(api != null);
            return api.GetAllowedGuesses() - api.GetUsedGuesses();
        }
    }
}
