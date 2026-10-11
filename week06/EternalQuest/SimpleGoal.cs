class SimpleGoal : Goal
{
    private bool _completed;
    public override bool IsComplete => _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points) => _completed = completed;

    public override int Record()
    {
        if (_completed) return 0;
        _completed = true;
        return Points;
    }

    public override string GetStatus() => _completed ? "[X]" : "[ ]";

    protected override void AddProgressTo(GoalData data) => data.Completed = _completed;
}
