using System;

abstract class Goal
{
    private string _name;
    private int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public string GetName() => _name;
    public int GetPoints() => _points;

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public virtual string GetDetailsString() => $"[ ] {_name} ({_points} pts)";
    public abstract string GetStringRepresentation();
}
