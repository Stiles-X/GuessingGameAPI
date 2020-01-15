using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class BaseAPI : Interfaces.IAPI
    {
        private Interfaces.IModel Model { get; set; }
        public BaseAPI(Interfaces.IModel Model)
        {
            this.Model = Model;
        }

        public int GetMax()
        {
            return Model.Max;
        }

        public void SetMax(int Max)
        {
            Model.Max = Max;
        }

        public int GetMin()
        {
            return Model.Min;
        }

        public void SetMin(int Min)
        {
            Model.Min = Min;
        }

        public int GetCorrect()
        {
            return Model.Correct;
        }

        public void SetCorrect(int Correct)
        {
            SetCorrect(Correct);
        }

        public bool Guess(int Guess)
        {
            SetUsedGuesses(GetUsedGuesses() + 1);
            return (Guess == GetCorrect());
        }

        public int GetAllowedGuesses()
        {
            return Model.AllowedGuesses;
        }

        public void SetAllowedGuesses(int AllowedGuesses)
        {
            Model.AllowedGuesses = AllowedGuesses;
        }

        public int GetUsedGuesses()
        {
            return Model.UsedGuesses;
        }

        public void SetUsedGuesses(int UsedGuesses)
        {
            Model.UsedGuesses = UsedGuesses;
        }
    }
}
