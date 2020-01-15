using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    interface APIInterface
    {
        //Max
        void GetMax();
        void SetMax(int MaxV);
        //Min
        void GetMin();
        void SetMin(int Min);
        //Correct
        void GetCorrect();
        void SetCorrect(int Correct);
        //Guess
        bool Guess();
        //AllowedGuesses
        void GetAllowedGuesses();
        void SetAllowedGuesses(int AllowedGuesses);
        //UsedGuesses
        void GetUsedGuesses();
        void SetUsedGuesses(int UsedGuesses);
    }
}
