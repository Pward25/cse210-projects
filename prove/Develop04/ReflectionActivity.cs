class ReflectionActivity : Activity
{
    private static readonly string[] _prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> _availableQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _remainingQuestions;

    public ReflectionActivity()
    {
        _remainingQuestions = new List<string>(_availableQuestions);
    }

    public string GetDescription()
    {
        return "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public void ExecuteReflectionActivity()
    {
        Random _rand = new();
        Console.WriteLine(_prompts[_rand.Next(_prompts.Length)]);
        ShowSpinner(3);

        int _elapsed = 0;

        while (_elapsed < _duration && _remainingQuestions.Count > 0)
        {
            int index = _rand.Next(_remainingQuestions.Count);
            Console.WriteLine(_remainingQuestions[index]);
            _remainingQuestions.RemoveAt(index);
            ShowSpinner(5);
            _elapsed += 5;
        }

        if (_remainingQuestions.Count == 0)
        {
            Console.WriteLine("\nYou've answered all available questions. Re-shuffling the list...");
            _remainingQuestions.AddRange(_availableQuestions);
        }
    }
}