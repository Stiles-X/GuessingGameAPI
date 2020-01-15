using API.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Extensions
{
    public static class APIExtensions
    {
        public static int GetRandom(this IAPI api)
        {
            return new Random().Next(api.GetMin(), api.GetMax() + 1);
        }
        public static void SetCorrectRandom(this IAPI api)
        {
            api.SetCorrect(api.GetRandom());
        }
    }
}
