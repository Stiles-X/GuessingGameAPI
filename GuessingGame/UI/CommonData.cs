using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.UI
{
    class CommonData
    {
        public static readonly string help = "Usage: help, version";
        public static readonly string version = "0.0.0";
        public static readonly string not_found = $"Command not found. {help}";
        public static string ascii_logo { get { return GetAsciiLogo(); } }
        public static string GetAsciiLogo(string text = "")
        {
            return
                @"

   _____                     _             
  / ____|                   (_)            
 | |  __ _   _  ___  ___ ___ _ _ __   __ _ 
 | | |_ | | | |/ _ \/ __/ __| | '_ \ / _` |
 | |__| | |_| |  __/\__ \__ \ | | | | (_| |
  \_____|\__,_|\___||___/___/_|_| |_|\__, |
  / ____|                             __/ |
 | |  __  __ _ _ __ ___   ___        |___/ 
 | | |_ |/ _` | '_ ` _ \ / _ \             
 | |__| | (_| | | | | | |  __/             
  \_____|\__,_|_| |_| |_|\___|" + $"{text}    \n";
        }
    }
}
