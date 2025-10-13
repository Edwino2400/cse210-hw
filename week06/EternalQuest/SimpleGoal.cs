using System;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isComplete = false;
    }

    public override bool IsComplete() => _isComplete;

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return (_isComplete ? "[X] " : "[ ] ") + GetName() + $" ({GetPoints()} pts)";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()},{GetPoints()},{_isComplete}";
    }

    public static SimpleGoal CreateFromString(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        int points = int.Parse(parts[1]);
        bool complete = bool.Parse(parts[2]);
        SimpleGoal goal = new SimpleGoal(name, points);
        if (complete) goal.RecordEvent();
        return goal;
    }
}
