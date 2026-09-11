using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        bool running = true;

        // Extra feature: users can search saved entries by keyword instead of only listing everything.
        while (running)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Search entries");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    journal.SearchEntries();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 6.");
                    break;
            }
        }
    }
}