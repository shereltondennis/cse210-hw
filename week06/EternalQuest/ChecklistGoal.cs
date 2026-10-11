class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonus;
    private int _timesCompleted;
    public override bool IsComplete => _timesCompleted >= _targetCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus,
        int timesCompleted = 0) : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _timesCompleted = System.Math.Min(timesCompleted, targetCount);
    }

    public override int Record()
    {
        if (IsComplete) return 0;
        _timesCompleted++;
        return Points + (IsComplete ? _bonus : 0);
    }

    public override string GetStatus() => $"Completed {_timesCompleted}/{_targetCount} times";

    public override void Display(int number)
    {
        System.Console.WriteLine($"{number}. {(IsComplete ? "[X]" : "[ ]")} {Name} ({Description}) — {GetStatus()}");
    }

    protected override void AddProgressTo(GoalData data)
    {
        data.TargetCount = _targetCount;
        data.Bonus = _bonus;
        data.TimesCompleted = _timesCompleted;
    }
}
