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
                if (!Misc.Exist(new[] { "h", "-h", "help", "--help" }, command, help, out mainMenuCommand))
                if (!Misc.Exist(new[] { "l", "-l", "license", "--license" }, command, license, out mainMenuCommand))
                if (!Misc.Exist(new[] { "a", "-a", "about", "--about" }, command, about, out mainMenuCommand))
                if (!Misc.Exist(new[] { "v", "-v", "version", "--version" }, command, version, out mainMenuCommand))
                if (!Misc.Exist(new[] { "c", "cls", "clear" }, command, clear, out mainMenuCommand))
                if (!Misc.Exist(new[] { "e", "exit", "q", "quit" }, command, quit, out mainMenuCommand))
                {
                    mainMenuCommand = command switch
                    {
                        "s" => s,
                        "m" => m,
                        _ => not_found
                    };
                }
                MainMenuDisplay(mainMenuCommand);
            } while (Misc.Exist(new[] { help, version, not_found, license, about, clear }, mainMenuCommand));
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
            if (Misc.Exist(new[] { MainMenuCommand.quit, MainMenuCommand.s, MainMenuCommand.m }, mainMenuCommand))
            {
                Thread.Sleep(350);
            }
        }
    }
}
