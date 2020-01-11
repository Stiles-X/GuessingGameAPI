using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GuessingGame.UI
{
    enum MainMenuCommand
    {
        version,
        help,
        not_found,
        quit
    }
    class UI
    {
        // Main
        public static void Main(string[] args)
        {
            Args.HandleArgs(args);
            MainMenu();
        }

        //Main Menu
        static int? MainMenu()
        {
            MainMenuCommand mainMenuCommand;
            var help = MainMenuCommand.help;
            var version = MainMenuCommand.version;
            var not_found = MainMenuCommand.not_found;
            var quit = MainMenuCommand.quit;
            MainMenuDisplay();
            do
            {
                string command = Console.ReadLine();
                mainMenuCommand = command switch
                {
                    "help" => help,
                    "--help" => help,
                    "-h" => help,
                    "version" => version,
                    "--version" => version,
                    "-v" => version,
                    "quit" => quit,
                    "exit" => quit,
                    "q" => quit,
                    "e" => quit,
                    _ => not_found
                };
                MainMenuDisplay(mainMenuCommand);
            } while ((mainMenuCommand == help)|(mainMenuCommand == version)|(mainMenuCommand == not_found));
            if (mainMenuCommand == quit)
                return 0;
            return 1;
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
                MainMenuCommand.quit => "Goodbye",
                _ => throw new ArgumentException(@"https://xkcd.com/2200/")
            };
            Console.WriteLine(content);
            if (mainMenuCommand == MainMenuCommand.quit)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
