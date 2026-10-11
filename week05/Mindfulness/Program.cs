using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            if (choice == null)
            {
                Console.WriteLine();
                Console.WriteLine("No interactive input is available. Run this program in a terminal and enter a menu number.");
                break;
            }

            switch (choice)
            {
                case "1": new BreathingActivity().Run(); break;
                case "2": new ReflectionActivity().Run(); break;
                case "3": new ListingActivity().Run(); break;
                case "4": running = false; break;
                default:
                    Console.WriteLine("Please select a valid menu option.");
                    Activity.Pause(2);
                    break;
            }
        }

        Console.WriteLine("Thank you for taking time for mindfulness.");
    }
}
