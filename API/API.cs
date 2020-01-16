using System;

namespace APIProject
{
    public class API : Interfaces.IAPI
    {
        public Interfaces.IModel Model { get; private set; }
        public API(Interfaces.IModel model)
        {
            this.Model = model ?? throw new ArgumentNullException(nameof(model));
        }
        public int GetMax()
        {
            AssertModelNotNull();
            return Model.Max;
        }

        public void SetMax(int max)
        {
            AssertModelNotNull();
            Model.Max = max;
        }

        public int GetMin()
        {
            AssertModelNotNull();
            return Model.Min;
        }

        public void SetMin(int min)
        {
            AssertModelNotNull();
            Model.Min = min;
        }

        public int GetCorrect()
        {
            AssertModelNotNull();
            return Model.Correct;
        }

        public void SetCorrect(int correct)
        {
            AssertModelNotNull();
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
            AssertModelNotNull();
            return Model.AllowedGuesses;
        }

        public void SetAllowedGuesses(int allowedGuesses)
        {
            AssertModelNotNull();
            Model.AllowedGuesses = allowedGuesses;
        }

        public int GetUsedGuesses()
        {
            AssertModelNotNull();
            return Model.UsedGuesses;
        }

        public void SetUsedGuesses(int usedGuesses)
        {
            AssertModelNotNull();
            Model.UsedGuesses = usedGuesses;
        }
        private void AssertModelNotNull()
        {
            AssertModelNotNull();
            if (Model == null)
            {
                throw new InvalidOperationException("Model cannot be null");
            }
        }
    }
}
