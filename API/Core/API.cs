using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class API : Interfaces.IAPI
    {
        private Interfaces.IModel Model { get; set; }
        public API(Interfaces.IModel Model)
        {
            this.Model = Model;
        }

        public int GetMax()
        {
            throw new NotImplementedException();
        }

        public void SetMax(int MaxV)
        {
            throw new NotImplementedException();
        }

        public int GetMin()
        {
            throw new NotImplementedException();
        }

        public void SetMin(int Min)
        {
            throw new NotImplementedException();
        }

        public int GetCorrect()
        {
            throw new NotImplementedException();
        }

        public void SetCorrect(int Correct)
        {
            throw new NotImplementedException();
        }

        public bool Guess(int Guess)
        {
            throw new NotImplementedException();
        }

        public int GetAllowedGuesses()
        {
            throw new NotImplementedException();
        }

        public void SetAllowedGuesses(int AllowedGuesses)
        {
            throw new NotImplementedException();
        }

        public int GetUsedGuesses()
        {
            throw new NotImplementedException();
        }

        public void SetUsedGuesses(int UsedGuesses)
        {
            throw new NotImplementedException();
        }
    }
}
