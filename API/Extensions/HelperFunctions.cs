using APIProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Extensions.HelperFunctions
{
    public static class HelperFunctions
    {
        public static int GetRandom(this IAPI api)
        {
            return new Random().Next(api.GetMin(), api.GetMax() + 1);
        }
        public static void SetCorrectRandom(this IAPI api)
        {
            api.SetCorrect(api.GetRandom());
        }
        public static int GetLeftGuesses(this IAPI api)
        {
            return api.GetAllowedGuesses() - api.GetUsedGuesses();
        }
    }
}
