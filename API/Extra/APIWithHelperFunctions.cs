using API.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class APIWithHelperFunctions : API, IAPIWithHelperFunctions
    {
        public APIWithHelperFunctions(IModel Model) : base(Model)
        {
        }

        public int GetRandom()
        {
            return new Random().Next(GetMin(), GetMax() + 1);
        }

        public void SetCorrectRandom()
        {
            SetCorrect(GetRandom());
        }
    }
}
