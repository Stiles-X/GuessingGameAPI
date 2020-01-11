﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GuessingGame.UI
{
    enum MainMenuCommand
    {
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
                string command = Console.ReadLine();
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
            } while ((mainMenuCommand == help) | (mainMenuCommand == version) | (mainMenuCommand == not_found) |
                    (mainMenuCommand == license) | (mainMenuCommand == about) | (mainMenuCommand == clear));
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
            CommonData.ClearAsciiLogoV();
            Console.WriteLine("___________________________________________");
            string content = mainMenuCommand switch
            {
                MainMenuCommand.clear => "",
                MainMenuCommand.s => CommonData.s,
                MainMenuCommand.m => CommonData.m,
                MainMenuCommand.help => CommonData.help,
                MainMenuCommand.license => CommonData.license,
                MainMenuCommand.about => CommonData.about,
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
