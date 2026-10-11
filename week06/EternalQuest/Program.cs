using System;
using System.IO;
using System.Text.Json;

class Program
{
    private static readonly GoalTracker _tracker = new();

    static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {_tracker.Score} points.\n");
            Console.WriteLine("1. Create new goal\n2. Record goal event\n3. Show goals\n4. Save goals\n5. Load goals\n6. Quit");
            Console.Write("Select an option: ");
            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": RecordGoal(); break;
                case "3": _tracker.DisplayGoals(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Please choose an option from 1 to 6."); break;
            }
        }
    }

    private static void CreateGoal()
    {
        Console.WriteLine("\nGoal types: 1. Simple  2. Eternal  3. Checklist");
        string type = ReadRequired("Choose a goal type: ");
        string name = ReadRequired("Goal name: ");
        string description = ReadRequired("Goal description: ");
        int points = ReadPositiveInt("Points for each completion: ");

        switch (type)
        {
            case "1": _tracker.AddGoal(new SimpleGoal(name, description, points)); break;
            case "2": _tracker.AddGoal(new EternalGoal(name, description, points)); break;
            case "3":
                int target = ReadPositiveInt("How many times must you complete it? ");
                int bonus = ReadNonNegativeInt("Bonus points on completion: ");
                _tracker.AddGoal(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default: Console.WriteLine("Unknown goal type; no goal was created."); return;
        }
        Console.WriteLine("Goal created.");
    }

    private static void RecordGoal()
    {
        if (_tracker.Goals.Count == 0) { Console.WriteLine("Create a goal first."); return; }
        _tracker.DisplayGoals();
        int index = ReadPositiveInt("Which goal number did you complete? ") - 1;
        if (!_tracker.RecordGoal(index, out int earned, out string message))
        {
            Console.WriteLine(message);
            return;
        }
        Console.WriteLine($"{message} You earned {earned} points. Total: {_tracker.Score} points.");
    }

    private static void SaveGoals()
    {
        string path = ReadRequired("File name to save to: ");
        try { _tracker.Save(path); Console.WriteLine("Goals saved."); }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException)
        { Console.WriteLine($"Could not save goals: {ex.Message}"); }
    }

    private static void LoadGoals()
    {
        string path = ReadRequired("File name to load: ");
        try { _tracker.Load(path); Console.WriteLine("Goals loaded."); }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is JsonException || ex is ArgumentException)
        { Console.WriteLine($"Could not load goals: {ex.Message}"); }
    }

    private static string ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(value)) return value;
            Console.WriteLine("A value is required.");
        }
    }

    private static int ReadPositiveInt(string prompt) => ReadInt(prompt, 1);
    private static int ReadNonNegativeInt(string prompt) => ReadInt(prompt, 0);

    private static int ReadInt(string prompt, int minimum)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= minimum) return value;
            Console.WriteLine($"Enter a whole number of at least {minimum}.");
        }
    }
}
