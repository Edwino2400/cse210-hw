using System;

class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredCompletions;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int requiredCompletions, int bonusPoints)
        : base(name, points)
    {
        _requiredCompletions = requiredCompletions;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }

    public override bool IsComplete() => _timesCompleted >= _requiredCompletions;

    public override int RecordEvent()
    {
        if (_timesCompleted < _requiredCompletions)
        {
            _timesCompleted++;
            if (IsComplete())
            {
                return GetPoints() + _bonusPoints;
            }
            return GetPoints();
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return (_timesCompleted >= _requiredCompletions ? "[X] " : "[ ] ") +
               $"{GetName()} ({GetPoints()} pts) Completed {_timesCompleted}/{_requiredCompletions}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetPoints()},{_timesCompleted},{_requiredCompletions},{_bonusPoints}";
    }

    public static ChecklistGoal CreateFromString(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        int points = int.Parse(parts[1]);
        int completed = int.Parse(parts[2]);
        int required = int.Parse(parts[3]);
        int bonus = int.Parse(parts[4]);

        ChecklistGoal goal = new ChecklistGoal(name, points, required, bonus);
        for (int i = 0; i < completed; i++)
        {
            goal.RecordEvent();
        }
        return goal;
    }
}
