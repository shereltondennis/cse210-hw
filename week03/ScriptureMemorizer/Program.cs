using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity feature:
        // This program contains a library of multiple scriptures and
        // randomly selects one scripture for the user to memorize.
        //
        // The program also exceeds the core requirements by selecting
        // only words that have not already been hidden. This prevents
        // the program from randomly selecting the same hidden word.
        
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son " +
                "that whoever believes in him should not perish but have eternal life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own " +
                "understanding. In all your ways acknowledge him and he will make " +
                "your paths straight."
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ who strengthens me."
            )
        };

        // Randomly choose a scripture from the library.
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();

            // Display the complete or partially hidden scripture.
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");

            string input = Console.ReadLine();

            // End the program if the user types quit.
            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Hide a few random words.
            scripture.HideRandomWords(3);

            // End when every word has been hidden.
            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words have been hidden. Great job memorizing!");
                break;
            }
        }
    }
}