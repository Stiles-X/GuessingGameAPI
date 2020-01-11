using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.UI
{
    class Args
    {
        public static MainMenuCommand? HandleArgs(string[] args)
        {
            foreach (string arg in args) // Handle all of them, one at a time
            {
                string help = CommonData.help;
                string about = CommonData.about;
                string license = CommonData.license;
                string version = CommonData.version;
                string not_found = CommonData.not_found;
                string message = arg switch  // Handling command line arguments
                {
                    "license" => license,
                    "--license" => license,
                    "-l" => license,
                    "l" => license,
                    "about" => about,
                    "--about" => about,
                    "-a" => about,
                    "a" => about,
                    "s" => CommonData.s,
                    "m" => CommonData.m,
                    "help" => help,
                    "--help" => help,
                    "-h" => help,
                    "h" => help,
                    "version" => version,
                    "--version" => version,
                    "-v" => version,
                    "v" => version,
                    _ => not_found
                };
                Console.WriteLine(message);  // Print the value
                if (arg == "s")
                    return MainMenuCommand.s;
                if (arg == "m")
                    return MainMenuCommand.m;
            }
            return null;
        }
    }
}
