using System;
using System.Diagnostics;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void Execute()
    {
        Stopwatch timer = Stopwatch.StartNew();
        bool breatheIn = true;
        while (timer.Elapsed.TotalSeconds < DurationSeconds)
        {
            Console.WriteLine(breatheIn ? "Breathe in..." : "Breathe out...");
            int interval = Math.Min(4, Math.Max(1, DurationSeconds - (int)timer.Elapsed.TotalSeconds));
            Countdown(interval);
            breatheIn = !breatheIn;
        }
    }
}
