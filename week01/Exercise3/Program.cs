using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = Random.Shared.Next(1, 101);
        int guess;

        Console.WriteLine("Guess the magic number between 1 and 100!");

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

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
                Console.WriteLine("Congratulations! You guessed it!");
            }
        }
        while (guess != magicNumber);
    }
}