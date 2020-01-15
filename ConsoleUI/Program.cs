using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main()//string[] args)
        {
            while (Menu())
            {
            }
        }
        static bool Menu()
        {
            Console.WriteLine($"GuessingGameAPI - v{APIProject.Info.version}");
            Console.WriteLine("(s)ingle-player or (m)ul(t)iplayer or (q)uit");
            string command = Console.ReadLine().ToLower();
            Console.Clear();
            Game game = new Game();
            if (command == "s")
            {
                game.PlaySinglePlayer();
            }
            else if (command == "m" | command == "t")
            {
                game.PlayTwoPlayers();
            }
            else
            {
                return false;
            }
            Console.WriteLine("Press any key to exit to main menu...");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
    }
}