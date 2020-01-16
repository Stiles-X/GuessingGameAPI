using System;
namespace APIProject
{
    public class API : Interfaces.IAPI
    {
        #pragma warning disable CA1303 // Do not pass literals as localized parameters
        public Interfaces.IModel Model { get; private set; }
        public API(Interfaces.IModel model)
        {
            this.Model = model;
        }
        public int GetMax()
        {
            return Model.Max;
        }

        public void SetMax(int max)
        {
            Model.Max = max;
        }

        public int GetMin()
        {
            return Model.Min;
        }

        public void SetMin(int min)
        {
            Model.Min = min;
        }

        public int GetCorrect()
        {
            return Model.Correct;
        }

        public void SetCorrect(int correct)
        {
            Model.Correct = correct;
        }

        // Guess
        public bool Guess(int guess)
        {
            if (guess > GetMax())
            {
                throw new ArgumentOutOfRangeException(nameof(guess), "Your guess is more than Max");
            }
            else if (guess < GetMin())
            {
                throw new ArgumentOutOfRangeException(nameof(guess), "Your guess is less than Min");
            }

            if (GetUsedGuesses() >= GetAllowedGuesses())
            {
                throw new InvalidOperationException("You are out of guesses");
            }
            SetUsedGuesses(GetUsedGuesses() + 1);
            return (guess == GetCorrect());
        }

        public int GetAllowedGuesses()
        {
            return Model.AllowedGuesses;
        }

        public void SetAllowedGuesses(int allowedGuesses)
        {
            Model.AllowedGuesses = allowedGuesses;
        }

        public int GetUsedGuesses()
        {
            return Model.UsedGuesses;
        }

        public void SetUsedGuesses(int usedGuesses)
        {
            Model.UsedGuesses = usedGuesses;
        }

    }
}
