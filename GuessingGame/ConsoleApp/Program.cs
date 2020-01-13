using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GuessingGame.UI
{
    enum MainMenuCommand
    {
        args,
        clear,
        license,
        about,
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
                {
                    Console.Clear();
                    return 0;
                }
                if (Command == MainMenuCommand.s)
                    Game.FlexPlayer(PlayerMode.single);
                if (Command == MainMenuCommand.m)
                    Game.FlexPlayer(PlayerMode.multi);
                return 1;
            }
            else
            {
                if (argsMainMenuCommand == MainMenuCommand.args)
                    return 0;
                Command = argsMainMenuCommand ?? default;
                if (Command == MainMenuCommand.s)
                    Game.FlexPlayer(PlayerMode.single);
                if (Command == MainMenuCommand.m)
                    Game.FlexPlayer(PlayerMode.multi);
                return 0;
            }
        }

        //Main Menu
        static MainMenuCommand? MainMenu()
        {
            MainMenuCommand mainMenuCommand;
            var help = MainMenuCommand.help;
            var license = MainMenuCommand.license;
            var about = MainMenuCommand.about;
            var version = MainMenuCommand.version;
            var not_found = MainMenuCommand.not_found;
            var quit = MainMenuCommand.quit;
            var s = MainMenuCommand.s;
            var m = MainMenuCommand.m;
            var clear = MainMenuCommand.clear;
            MainMenuDisplay();
            do
            {
                string command = Console.ReadLine().ToLower();
                mainMenuCommand = command switch
                {
                    "cls" => clear,
                    "clear" => clear,
                    "c" => clear,
                    "s" => s,
                    "m" => m,
                    "help" => help,
                    "--help" => help,
                    "-h" => help,
                    "h" => help,
                    "license" => license,
                    "--license" => license,
                    "-l" => license,
                    "l" => license,
                    "about" => about,
                    "--about" => about,
                    "-a" => about,
                    "a" => about,
                    "version" => version,
                    "--version" => version,
                    "-v" => version,
                    "v" => version,
                    "quit" => quit,
                    "exit" => quit,
                    "q" => quit,
                    "e" => quit,
                    _ => not_found
                };
                MainMenuDisplay(mainMenuCommand);
            } while (new[] { help, version, not_found, license, about, clear }.Any(x => x == mainMenuCommand));
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
            Misc.ClearAsciiLogoV();
            string content = mainMenuCommand switch
            {
                MainMenuCommand.clear => "",
                MainMenuCommand.s => Misc.s,
                MainMenuCommand.m => Misc.m,
                MainMenuCommand.help => Misc.help,
                MainMenuCommand.license => Misc.license,
                MainMenuCommand.about => Misc.about,
                MainMenuCommand.version => "Version: " + Misc.version,
                MainMenuCommand.not_found => Misc.not_found,
                MainMenuCommand.quit => "Goodbye",
                _ => throw new ArgumentException(@"https://xkcd.com/2200/")
            };
            Console.WriteLine(content);
            if (new[] { MainMenuCommand.quit, MainMenuCommand.s, MainMenuCommand.m }.Any(x => x == mainMenuCommand))
            {
                Thread.Sleep(400);
            }
        }
    }
}
