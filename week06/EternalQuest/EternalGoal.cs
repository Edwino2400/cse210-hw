using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override bool IsComplete() => false;

    public override int RecordEvent() => GetPoints();

    public override string GetDetailsString() => "[∞] " + GetName() + $" ({GetPoints()} pts per completion)";

    public override string GetStringRepresentation() => $"EternalGoal:{GetName()},{GetPoints()}";

    public static EternalGoal CreateFromString(string data)
    {
        string[] parts = data.Split(",");
        string name = parts[0];
        int points = int.Parse(parts[1]);
        return new EternalGoal(name, points);
    }
}
