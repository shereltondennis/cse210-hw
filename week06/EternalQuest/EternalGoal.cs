class EternalGoal : Goal
{
    private int _timesCompleted;
    public override bool IsComplete => false;

    public EternalGoal(string name, string description, int points, int timesCompleted = 0)
        : base(name, description, points) => _timesCompleted = timesCompleted;

    public override int Record()
    {
        _timesCompleted++;
        return Points;
    }

    public override string GetStatus() => $"Recorded {_timesCompleted} times";

    public override void Display(int number)
    {
        System.Console.WriteLine($"{number}. [Eternal] {Name} ({Description}) — {GetStatus()}");
    }

    protected override void AddProgressTo(GoalData data) => data.TimesCompleted = _timesCompleted;
}
