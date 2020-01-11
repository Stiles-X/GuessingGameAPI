using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.UI
{
    class UI
    {
        public static void UIMain(string[] args)
        {
            Console.Clear();
            Args.HandleArgs(args);
            MainMenu();
            Console.Read();
        }
        public static void MainMenu()
        {
            Console.WriteLine(CommonData.GetAsciiLogo("v"+CommonData.version));
        }
    }
}
