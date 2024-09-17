using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random magic number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess = 0;
            int numberOfGuesses = 0;

            // Loop until the user guesses the correct number
            while (guess != magicNumber)
            {
                // Ask the user for their guess
                Console.WriteLine("What is your guess?");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++;

                // Determine if the guess is higher, lower, or correct
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numberOfGuesses} guesses.");
                }
            }

            // Ask the user if they want to play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");
        }
    }
}
