using System;
using System.Diagnostics;

class ListingActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void Execute()
    {
        Random random = new();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {Prompts[random.Next(Prompts.Length)]} ---");
        Console.WriteLine("You may begin in:");
        Countdown(5);

        Console.WriteLine("Start listing (press Enter after each item):");
        Stopwatch timer = Stopwatch.StartNew();
        int count = 0;
        while (timer.Elapsed.TotalSeconds < DurationSeconds)
        {
            int remaining = DurationSeconds - (int)timer.Elapsed.TotalSeconds;
            Console.Write($"Items listed: {count} | Time left: {remaining}s > ");
            string item = Console.ReadLine();
            if (item == null)
                break;
            if (!string.IsNullOrWhiteSpace(item))
                count++;
        }

        Console.WriteLine($"You listed {count} item{(count == 1 ? "" : "s")}.");
    }
}
