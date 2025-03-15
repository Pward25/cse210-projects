class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, int points, int targetCount, int bonus, int currentCount = 0)
    {
        Name = name;
        Points = points;
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            Program.AddPoints(Points);
            Console.WriteLine($"Recorded '{Name}' ({_currentCount}/{_targetCount}). +{Points} points");
            
            if (_currentCount == _targetCount)
            {
                Program.AddPoints(_bonus);
                Console.WriteLine($"Congratulations! Goal '{Name}' completed! Bonus +{_bonus} points");
            }
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public override bool IsComplete() => _currentCount >= _targetCount;
    public override string GetStatus() => $"[{(_currentCount >= _targetCount ? "X" : " ")}] {Name} ({_currentCount}/{_targetCount})";
}
