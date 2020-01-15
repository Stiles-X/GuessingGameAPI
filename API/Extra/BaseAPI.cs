namespace APIProject.Extra
{
    public class BaseAPI : Interfaces.IAPI
    {
        private Interfaces.IModel Model { get; set; }
        public BaseAPI(Interfaces.IModel model)
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
            SetCorrect(correct);
        }

        public bool Guess(int guess)
        {
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
