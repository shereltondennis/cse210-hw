using System;
using System.Diagnostics;
using System.Threading;

abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private int _durationSeconds;

    protected int DurationSeconds => _durationSeconds;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _durationSeconds = ReadDuration();

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        Pause(3);
        Execute();
        Finish();
    }

    protected abstract void Execute();

    protected static int ReadDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                return duration;
            Console.WriteLine("Please enter a whole number greater than zero.");
        }
    }

    protected static void Countdown(int seconds)
    {
        for (int remaining = seconds; remaining > 0; remaining--)
        {
            Console.Write($"{remaining} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public static void Pause(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        Stopwatch timer = Stopwatch.StartNew();
        int frame = 0;
        while (timer.Elapsed < TimeSpan.FromSeconds(seconds))
        {
            Console.Write(frames[frame++ % frames.Length]);
            Thread.Sleep(150);
            Console.Write('\b');
        }
        Console.WriteLine(" ");
    }

    private void Finish()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Pause(2);
        Console.WriteLine($"You have completed {_durationSeconds} seconds of the {_name}.");
        Pause(3);
    }
}
