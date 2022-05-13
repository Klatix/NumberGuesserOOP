using System;

namespace BasicNumberGuesser
{

    class Program
    {
        static void Main(string[] args)
        {
            //version display
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Number Guesser App in C# v.1.2, created by Klatix");
            Console.ResetColor();

            //creating objects necessary to run the game
            NumberGenerator numgen = new NumberGenerator();
            numgen.GenerateCorrectNum();
            Player player = new Player();
            player.EnterName();
            player.SetDifficulty();
            WinChecker winCheck = new WinChecker();
            Game game = new Game();

            Console.Clear();

            //start game
            game.RunGame(winCheck, player, numgen);
        }
    }
}
