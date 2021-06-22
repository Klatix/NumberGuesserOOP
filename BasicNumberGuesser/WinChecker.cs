using System;
using System.Collections.Generic;
using System.Text;

namespace BasicNumberGuesser
{

    //class to implement game logic
    public class WinChecker
    {
        private bool victory = false;

        public void CheckWin(Player player, NumberGenerator numGen)
        {
            if (player.GetGuess() == numGen.GetCorrectNum())
            {
                //Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Good Job {player.GetName()}! You guessed correctly!");
                Console.ResetColor();
                victory = true;
            }
            else if (player.GetGuess() > numGen.GetCorrectNum())
            {
                player.LoseChance();
                //Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Oops, you guessed too high. Chances left: {player.GetChances()}");
                Console.ResetColor();
                Console.WriteLine("Guess again: ");
                victory = false;
            }
            else if (player.GetGuess() < numGen.GetCorrectNum())
            {
                player.LoseChance();
                //Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Oops, you guessed too low. Chances left: {player.GetChances()}");
                Console.ResetColor();
                Console.WriteLine("Guess again: ");
                victory = false;
            }
        }
        public bool GetVictory()
        {
            return victory;
        }
    }

}
