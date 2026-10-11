using System;
using System.Diagnostics;

class ReflectionActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions =
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void Execute()
    {
        Random random = new();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {Prompts[random.Next(Prompts.Length)]} ---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Stopwatch timer = Stopwatch.StartNew();
        string previousQuestion = "";
        while (timer.Elapsed.TotalSeconds < DurationSeconds)
        {
            string question;
            do { question = Questions[random.Next(Questions.Length)]; }
            while (question == previousQuestion && Questions.Length > 1);
            previousQuestion = question;
            Console.Write($"> {question} ");

            int remaining = DurationSeconds - (int)timer.Elapsed.TotalSeconds;
            if (remaining > 0)
                Pause(Math.Min(5, remaining));
        }
    }
}
