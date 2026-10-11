using System.Collections.Generic;

class SaveData
{
    public int Score { get; set; }
    public List<GoalData> Goals { get; set; } = new();
    public int BestDailyStreak { get; set; }
}
