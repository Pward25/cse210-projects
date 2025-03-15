class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, int points, bool completed = false)
    {
        Name = name;
        Points = points;
        _completed = completed;
    }

    public override void RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            Program.AddPoints(Points);
            Console.WriteLine($"Goal '{Name}' completed! +{Points} points");
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public override bool IsComplete() => _completed;
    public override string GetStatus() => _completed ? "[X] " + Name : "[ ] " + Name;
}