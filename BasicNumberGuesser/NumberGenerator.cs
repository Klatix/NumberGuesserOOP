using System;
using System.Collections.Generic;
using System.Text;

namespace BasicNumberGuesser
{

    //class to generate numbers
    public class NumberGenerator
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

}
