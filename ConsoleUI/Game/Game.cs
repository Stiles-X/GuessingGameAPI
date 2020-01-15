using System;
using System.Collections.Generic;
using System.Text;
using APIProject;
using APIProject.Interfaces;
using APIProject.Exceptions;
using ConsoleUI.GameHelper;

namespace ConsoleUI
{
    class Game
    {
        // Start Game
        private IAPI API { get; set; }
        private void Play()
        {
            StoreNewAPI();
            Ask();
            DisplayState();
            StoreNewAPI();
            Ask();
        }
        private void DisplayState()
        {
            Console.WriteLine($"Max: {API.GetMax()}");
            Console.WriteLine($"Min: {API.GetMin()}");
        }
        private void Ask()
        {
            API.SetMax(GameAsk.AskMax());
            API.SetMin(GameAsk.AskMin());
        }
        private void StoreNewAPI()
        {
            API = new API(new Model());
        }
        // Calls Play
        public void PlayTwoPlayers()
        {
            Play();
        }
        public void PlaySinglePlayer()
        {
            Play();
        }
    }
}
