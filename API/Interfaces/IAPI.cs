using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    public interface IAPI
    {
        //Max
        int GetMax();
        void SetMax(int Max);
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
