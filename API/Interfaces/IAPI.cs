using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    interface IAPI
    {
        //Max
        int GetMax();
        void SetMax(int MaxV);
        //Min
        int GetMin();
        void SetMin(int Min);
        //Correct
        int GetCorrect();
        void SetCorrect(int Correct);
        //Guess
        bool Guess(int Guess);
        //AllowedGuesses
        int GetAllowedGuesses();
        void SetAllowedGuesses(int AllowedGuesses);
        //UsedGuesses
        int GetUsedGuesses();
        void SetUsedGuesses(int UsedGuesses);
    }
}
