using APIProject.Interfaces;
using System;

namespace APIProject.Extensions.HelperFunctions
{
    public static class HelperFunction
    {
        public static int GetRandom(this IAPI api)
        {
            if(api == null)
            {
                throw new ArgumentNullException(nameof(api));
            }
            return new Random().Next(api.GetMin(), api.GetMax() + 1);
        }
        public static void SetCorrectRandom(this IAPI api)
        {
            if (api == null)
            {
                throw new ArgumentNullException(nameof(api));
            }
            api.SetCorrect(api.GetRandom());
        }
        public static int GetLeftGuesses(this IAPI api)
        {
            if (api == null)
            {
                throw new ArgumentNullException(nameof(api));
            }
            return api.GetAllowedGuesses() - api.GetUsedGuesses();
        }
    }
}
