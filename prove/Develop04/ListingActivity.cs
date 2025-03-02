class ListingActivity : Activity
{
    private static readonly string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public string GetDescription()
    {
        return "This activity will help you reflect on the good things in your life by listing as many as you can.";
    }

    public void ExecuteListingActivity()
    {
        Random _rand = new();
        Console.WriteLine(_prompts[_rand.Next(_prompts.Length)]);
        ShowCountdown(5);
        List<string> _items = new();
        Console.WriteLine("Start listing items:");
        int _elapsed = 0;

        while (_elapsed < _duration)
        {
            _items.Add(Console.ReadLine() ?? "");
            _elapsed += 3;
        }

        Console.WriteLine($"You listed {_items.Count} items!");
    }
}