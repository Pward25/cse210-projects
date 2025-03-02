class Activity
{
    protected int _duration;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {GetType().Name.Replace("Activity", "")} Activity...");
        Console.WriteLine(GetDescription());

        // Input validation for duration
        bool validInput = false;
        while (!validInput)
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();
            validInput = int.TryParse(input, out _duration) && _duration > 0;
            if (!validInput)
            {
                Console.WriteLine("Please enter a valid positive number for duration.");
            }
        }

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        Execute();
        End();
    }

    public virtual string GetDescription()
    {
        return "This is a general mindfulness activity.";
    }

    public virtual void Execute()
    {
        Console.WriteLine("Executing base activity...");
    }

    private void End()
    {
        Console.WriteLine("Great job! You have completed the activity.");
        Console.WriteLine($"Activity: {GetType().Name.Replace("Activity", "")} - Duration: {_duration} seconds");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
