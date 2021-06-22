using System;

namespace BasicNumberGuesser
{

    //class to generate numbers
    class NumberGenerator
    {
 
        private int correct_num;

        //generate random number between 0-10 as correct answer
        public void GenerateCorrectNum()
        {
            Random rand = new Random();
            correct_num = rand.Next(11);
        }
         public int GetCorrectNum()
        {
            return correct_num;
        }
        
    }


    //class to take the input of our Player and  
    class Player
    {
        private int guess;
        private int chances_left;
        private string name;
        public void SetGuess(int _guess)
        {
            guess = _guess;
        }
        public int GetGuess()
        {
            return guess;
        }
        public void SetName(string _name)
        {
            name = _name;
        }
        public string GetName()
        {
            return name;
        }
        public void SetChances(int chances)
        {
            chances_left = chances;
        }
        public int GetChances()
        {
            return chances_left;
        }
        public void LoseChance()
        {
            chances_left--;
        }
        public void EnterName()
        {
            Console.WriteLine("Enter your Name: ");
            string _name = Console.ReadLine();
            SetName(_name);
            Console.Clear();
        }
        public void SetDifficulty()
        {
            
            Console.WriteLine("Choose difficulty: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1.Easy (4 chances)");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2.Medium (3 chances)");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3.Hard (2 chances)");
            Console.ResetColor();
            Console.WriteLine("Choice: ");
            int choice;
            bool success = int.TryParse(Console.ReadLine(), out choice);
            if (success)
            {
                switch (choice)
                {
                    case 1:
                        chances_left = 4;
                        break;
                    case 2:
                        chances_left = 3;
                        break;
                    case 3:
                        chances_left = 2;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Bad input, choose difficulty again.");
                        SetDifficulty();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bad input, please enter a number instead.");
                SetDifficulty();
            }
        }
    }

    //class to implement game logic
    class WinChecker
    {
        private bool victory = false;

        public void CheckWin(Player player, NumberGenerator numGen)
        {
            if (player.GetGuess() == numGen.GetCorrectNum())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Good Job {player.GetName()}! You guessed correctly!");
                Console.ResetColor();
                victory = true;
            }
            else if (player.GetGuess() > numGen.GetCorrectNum())
            {
                player.LoseChance();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Oops, you guessed too high. Chances left: {player.GetChances()}");
                Console.ResetColor();
                Console.WriteLine("Guess again: ");
                victory = false;
            }
            else if (player.GetGuess() < numGen.GetCorrectNum())
            {
                player.LoseChance();
                Console.Clear();
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
                player.SetGuess(Int32.Parse(Console.ReadLine()));
                winCheck.CheckWin(player, numGen);
                if(player.GetChances() < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're out of chances, better luck next time.");
                    Console.ResetColor();
                    running = false;
                }
                else if(winCheck.GetVictory() == true)
                {
                    running = false;
                }
            }
            Console.WriteLine("Thanks for playing! :)");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //version display
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Number Guesser App in C# v.1.0, created by Klatix");
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
