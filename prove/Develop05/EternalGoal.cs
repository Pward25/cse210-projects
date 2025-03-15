class EternalGoal : Goal
{
    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override void RecordEvent()
    {
        Program.AddPoints(Points);
        Console.WriteLine($"Recorded '{Name}'. +{Points} points");
    }

    public override bool IsComplete() => false;
    public override string GetStatus() => "[∞] " + Name;
}