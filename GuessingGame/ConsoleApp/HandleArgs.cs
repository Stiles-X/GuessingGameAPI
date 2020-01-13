using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.UI
{
    class Args
    {
        public static MainMenuCommand? HandleArgs(string[] args)
        {
            if (args.Length == 0)
                return null;
            foreach (string arg in args) // Handle all of them, one at a time
            {
                string help = Misc.help;
                string about = Misc.about;
                string license = Misc.license;
                string version = Misc.version;
                string not_found = Misc.not_found;
                string message = arg.ToLower() switch  // Handling command line arguments
                {
                    "license" => license,
                    "--license" => license,
                    "-l" => license,
                    "l" => license,
                    "about" => about,
                    "--about" => about,
                    "-a" => about,
                    "a" => about,
                    "s" => Misc.s,
                    "m" => Misc.m,
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
            return MainMenuCommand.args;
        }
    }
}
