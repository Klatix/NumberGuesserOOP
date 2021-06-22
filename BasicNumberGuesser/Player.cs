using System;
using System.Collections.Generic;
using System.Text;

namespace BasicNumberGuesser
{

    //class to take the input of our Player and  
    public class Player
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
            //this block of code displays a command line UI and asks for an input
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

            //asking for input and using it in a switch statement
            int choice;
            //if parsing fails that means user input was wrong, most likely a string instead of a number, tryparse fixes a potential problem
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
}
