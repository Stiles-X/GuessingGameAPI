using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    interface IAPIWithHelperFunctions : IAPI
    {
        int GetRandom();
        void SetCorrectRandom();
    }
}
