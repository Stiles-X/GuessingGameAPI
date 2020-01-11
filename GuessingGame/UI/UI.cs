using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.UI
{
    enum MainMenuCommand
    {
        version,
        help,
        not_found
    }
    class UI
    {
        // Main
        public static void UIMain(string[] args)
        {
            Args.HandleArgs(args);
            MainMenu();
            Console.Read();
        }

        //Main Menu
        static void MainMenu()
        {
            MainMenuDisplay(MainMenuCommand.help);
        }
        static void MainMenuDisplay(MainMenuCommand mainMenuCommand = MainMenuCommand.help)
        {
            Console.Clear();
            Console.WriteLine(CommonData.GetAsciiLogo("v" + CommonData.version));
            Console.WriteLine("__________________________________________");
            string content = mainMenuCommand switch
            {
                MainMenuCommand.help => CommonData.help,
                MainMenuCommand.version => "Version: " + CommonData.version,
                MainMenuCommand.not_found => CommonData.not_found,
                _ => throw new ArgumentException(@"https://xkcd.com/2200/")
            };
            Console.WriteLine(content);
        }
    }
}
