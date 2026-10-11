using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class GoalTracker
{
    private readonly List<Goal> _goals = new();
    private int _score;
    private DateTime? _lastRecordedDate;
    private int _currentDailyStreak;
    private int _bestDailyStreak;

    public IReadOnlyList<Goal> Goals => _goals;
    public int Score => _score;
    public int CurrentDailyStreak => _currentDailyStreak;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public bool RecordGoal(int index, out int earned, out string message)
    {
        earned = 0;
        if (index < 0 || index >= _goals.Count) { message = "That goal number does not exist."; return false; }
        if (_goals[index].IsComplete) { message = "That goal is already complete."; return false; }

        earned = _goals[index].Record();
        _score += earned;
        UpdateDailyStreak();
        message = $"Recorded: {_goals[index].Name}. Daily streak: {_currentDailyStreak} day(s).";
        return true;
    }

    // Extra feature: reward consistent daily progress with a 25-point bonus every seventh consecutive day.
    private void UpdateDailyStreak()
    {
        DateTime today = DateTime.Today;
        if (_lastRecordedDate == today) return;
        _currentDailyStreak = _lastRecordedDate == today.AddDays(-1) ? _currentDailyStreak + 1 : 1;
        _lastRecordedDate = today;
        _bestDailyStreak = Math.Max(_bestDailyStreak, _currentDailyStreak);
        if (_currentDailyStreak % 7 == 0) _score += 25;
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        for (int i = 0; i < _goals.Count; i++)
        {
            _goals[i].Display(i + 1);
            if (_goals[i] is EternalGoal || _goals[i] is ChecklistGoal)
                Console.WriteLine($"   {_goals[i].GetStatus()}");
        }
    }

    public void Save(string path)
    {
        SaveData data = new()
        {
            Score = _score,
            Goals = _goals.Select(goal => goal.ToData()).ToList(),
            BestDailyStreak = _bestDailyStreak
        };
        File.WriteAllText(path, JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
    }

    public void Load(string path)
    {
        SaveData data = JsonSerializer.Deserialize<SaveData>(File.ReadAllText(path));
        if (data?.Goals == null || data.Score < 0) throw new JsonException("The save file is invalid.");
        List<Goal> loadedGoals = new();
        foreach (GoalData item in data.Goals)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.Name) || item.Points < 0)
                throw new JsonException("A saved goal is invalid.");
            loadedGoals.Add(item.Type switch
            {
                nameof(SimpleGoal) => new SimpleGoal(item.Name, item.Description ?? "", item.Points, item.Completed),
                nameof(EternalGoal) => new EternalGoal(item.Name, item.Description ?? "", item.Points, Math.Max(0, item.TimesCompleted)),
                nameof(ChecklistGoal) when item.TargetCount > 0 && item.Bonus >= 0 =>
                    new ChecklistGoal(item.Name, item.Description ?? "", item.Points, item.TargetCount, item.Bonus, Math.Max(0, item.TimesCompleted)),
                _ => throw new JsonException("A saved goal has an unknown type or invalid settings.")
            });
        }
        _goals.Clear();
        _goals.AddRange(loadedGoals);
        _score = data.Score;
        _bestDailyStreak = Math.Max(0, data.BestDailyStreak);
        _currentDailyStreak = 0;
        _lastRecordedDate = null;
    }
}
