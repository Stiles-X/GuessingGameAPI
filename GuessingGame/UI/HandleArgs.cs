using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.UI
{
    class Args
    {
        public static string[] HandleArgs(string[] args)
        {
            string[] messages = new string[args.Length];
            int i = 0;
            foreach (string arg in args) // Handle all of them, one at a time
            {
                string help = CommonData.help;
                string version = CommonData.version;
                string not_found = CommonData.not_found;
                string message = arg switch  // Handling command line arguments
                {
                    "help" => help,
                    "--help" => help,
                    "-h" => help,
                    "version" => version,
                    "--version" => version,
                    "-v" => version,
                    _ => not_found
                };
                Console.WriteLine(message);  // Print the value
                messages.SetValue(message, i);  // Put the value into array
                i++;  // Increment index
            }
            return messages;  // return array
        }
    }
}
