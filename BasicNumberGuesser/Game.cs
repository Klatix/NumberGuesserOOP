using System;
using System.Collections.Generic;
using System.Text;

namespace BasicNumberGuesser
{

    //class to operate our game
    class Game
    {
        private bool running;
        public void SetStatus(bool state)
        {
            running = state;
        }
        public void RunGame(WinChecker winCheck, Player player, NumberGenerator numGen)
        {
            SetStatus(true);
            Console.WriteLine($"Welcome {player.GetName()}! A random number between 0-10 has been generated and you need to guess it!");
            Console.WriteLine("Your guess: ");
            while (running)
            {
                int guess;
                bool success = int.TryParse(Console.ReadLine(), out guess);
                if (success)
                {
                    player.SetGuess(guess);
                    winCheck.CheckWin(player, numGen);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad input, please type a number");
                    Console.ResetColor();
                }
                if (player.GetChances() < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're out of chances, better luck next time.");
                    Console.ResetColor();
                    running = false;
                }
                else if (winCheck.GetVictory() == true)
                {
                    running = false;
                }
            }
            Console.WriteLine("Thanks for playing! :)");
        }
    }

}
