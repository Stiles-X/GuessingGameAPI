﻿using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main()//string[] args)
        {
            Game game = new Game();
            game.PlaySinglePlayer();
            Console.Read();
        }
    }
}
