using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;
using GuessingGame.Core.Exceptions;

namespace GuessingGame
{
    class TestStart
    {
        public static void TestMain(string[] args)
        {
            GuessingGame.UI.UI.Main(args);
            Program.FakeMain(args);
        }
    }
}
