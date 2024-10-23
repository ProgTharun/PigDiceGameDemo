using PigDiceGameDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGameDemo.Model
{
    internal class PigGame
    {
        private Random random = new Random();
        private int totalScore = 0;
        private int turnScore = 0;
        private bool playing = true;

        public void Start()
        {
            Console.WriteLine("Welcome to the game of Pig!");

            while (playing)
            {
                turnScore = 0;
                bool turnActive = true;

                while (turnActive)
                {
                    Console.WriteLine($"Current Total Score: {totalScore}");
                    Console.WriteLine($"Current Turn Score: {turnScore}");
                    Console.Write("Enter 'r' to roll again or 'h' to hold: ");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "r")
                    {
                        int roll = random.Next(1, 7);
                        Console.WriteLine($"You rolled: {roll}");

                        if (roll == 1)
                        {
                            Console.WriteLine("Rolled a 1! Turn over with no points.");
                            turnActive = false;
                        }
                        else
                        {
                            turnScore += roll;
                        }
                    }
                    else if (input.ToLower() == "h")
                    {
                        totalScore += turnScore;
                        turnActive = false;
                        Console.WriteLine($"You ended the turn with a total score of {totalScore}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'r' to roll or 'h' to hold.");
                    }
                }

                if (totalScore >= 20)
                {
                    Console.WriteLine("Congratulations! You win!");
                    playing = false;
                }
            }

            Console.WriteLine("Game over. Thanks for playing!");
        }
    }
}
