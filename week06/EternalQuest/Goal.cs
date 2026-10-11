abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public abstract bool IsComplete { get; }

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int Record();
    public abstract string GetStatus();
    protected abstract void AddProgressTo(GoalData data);

    public virtual void Display(int number)
    {
        System.Console.WriteLine($"{number}. {(IsComplete ? "[X]" : "[ ]")} {_name} ({_description})");
    }

    public GoalData ToData()
    {
        GoalData data = new()
        {
            Type = GetType().Name,
            Name = _name,
            Description = _description,
            Points = _points
        };
        AddProgressTo(data);
        return data;
    }
}
