using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {   
            }
            Game game = new Game();
            game.PlaySinglePlayer();
        }
    }
}
