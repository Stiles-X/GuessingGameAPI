namespace APIProject.Interfaces
{
    public interface IAPI
    {
        //Model
        IModel Model { get; }
        //Max
        int GetMax();
        void SetMax(int max);
        //Min
        int GetMin();
        void SetMin(int min);
        //Correct
        int GetCorrect();
        void SetCorrect(int correct);
        //Guess
        bool Guess(int guess);
        //AllowedGuesses
        int GetAllowedGuesses();
        void SetAllowedGuesses(int allowedGuesses);
        //UsedGuesses
        int GetUsedGuesses();
        void SetUsedGuesses(int usedGuesses);
    }
}
