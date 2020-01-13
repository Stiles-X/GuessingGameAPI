using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessingGame.UI
{
    class Args
    {
        public static MainMenuCommand? HandleArgs(string[] args)
        {
            if (args.Length == 0)
                return null;
            foreach (string argI in args) // Handle all of them, one at a time
            {
                string help = Misc.help;
                string about = Misc.about;
                string license = Misc.license;
                string version = Misc.version;
                string not_found = Misc.not_found;

                string arg = argI.ToLower();
                string message;
                // Handling command line arguments
                if (!Misc.Exist(new[] { "h", "-h", "help", "--help" }, arg, help, out message))
                if (!Misc.Exist(new[] { "l", "-l", "license", "--license" }, arg, license, out message))
                if (!Misc.Exist(new[] { "a", "-a", "about", "--about" }, arg, about, out message))
                if (!Misc.Exist(new[] { "v", "-v", "version", "--version" }, arg, version, out message))
                {
                    message = arg switch
                    {
                        "s" => Misc.s,
                        "m" => Misc.m,
                        _ => not_found
                    };
                }
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
