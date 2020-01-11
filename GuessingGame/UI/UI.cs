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
        quit,
        s,
        m
    }
    class UI
    {
        // Main
        public static int Main(string[] args)
        {
            MainMenuCommand? argsMainMenuCommand = Args.HandleArgs(args);
            MainMenuCommand Command;
            if (argsMainMenuCommand == null)
            {
                Command = MainMenu() ?? default;
                var mainMenuCommand = Command;
                if (mainMenuCommand == MainMenuCommand.quit)
                    return 0;
                if (Command == MainMenuCommand.s)
                    Game.FlexPlayer(GameMode.s);
                if (Command == MainMenuCommand.m)
                    Game.FlexPlayer(GameMode.m);
                return 1;
            }
            else
            {
                Command = argsMainMenuCommand ?? default;
                if (Command == MainMenuCommand.s)
                    Game.FlexPlayer(GameMode.s);
                if (Command == MainMenuCommand.m)
                    Game.FlexPlayer(GameMode.m);
                return 0;
            }
        }

        //Main Menu
        static MainMenuCommand? MainMenu()
        {
            MainMenuCommand mainMenuCommand;
            var help = MainMenuCommand.help;
            var version = MainMenuCommand.version;
            var not_found = MainMenuCommand.not_found;
            var quit = MainMenuCommand.quit;
            var s = MainMenuCommand.s;
            var m = MainMenuCommand.m;
            MainMenuDisplay();
            do
            {
                string command = Console.ReadLine();
                mainMenuCommand = command switch
                {
                    "s" => s,
                    "m" => m,
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
                return MainMenuCommand.quit;
            if (mainMenuCommand == s)
                return MainMenuCommand.s;
            if (mainMenuCommand == m)
                return MainMenuCommand.m;
            return null;
        }
        static void MainMenuDisplay(MainMenuCommand mainMenuCommand = MainMenuCommand.help)
        {
            Console.Clear();
            Console.WriteLine(CommonData.GetAsciiLogo("v" + CommonData.version));
            Console.WriteLine("__________________________________________");
            string content = mainMenuCommand switch
            {
                MainMenuCommand.s => CommonData.s,
                MainMenuCommand.m => CommonData.m,
                MainMenuCommand.help => CommonData.help,
                MainMenuCommand.version => "Version: " + CommonData.version,
                MainMenuCommand.not_found => CommonData.not_found,
                MainMenuCommand.quit => "Goodbye",
                _ => throw new ArgumentException(@"https://xkcd.com/2200/")
            };
            Console.WriteLine(content);
            if ((mainMenuCommand == MainMenuCommand.quit) |
                (mainMenuCommand == MainMenuCommand.s) |
                (mainMenuCommand == MainMenuCommand.m))
            {
                Thread.Sleep(500);
            }
        }
    }
}
