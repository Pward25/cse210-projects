class Program
{
    public static int Score = 0;
    public static int Level = 1;
    public static int NextLevelThreshold = 1000;
    private static List<Goal> goals = new List<Goal>();

    public static void AddPoints(int points)
    {
        Score += points;
        if (Score >= NextLevelThreshold)
        {
            Level++;
            NextLevelThreshold += Level * 1000;
            Console.WriteLine($"Congratulations! You reached Level {Level}!");
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest - Goal Tracker");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score and level");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": RecordGoal(); break;
                case "3": ShowGoals(); break;
                case "4": Console.WriteLine($"Your score: {Score}, Level: {Level}, Next Level: {NextLevelThreshold}"); break;
                case "5": SaveData(); break;
                case "6": LoadData(); break;
                case "7": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist");
        string type = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1": goals.Add(new SimpleGoal(name, points)); break;
            case "2": goals.Add(new EternalGoal(name, points)); break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                return;
        }
        Console.WriteLine("Goal added successfully!");
    }

    static void RecordGoal()
    {
        ShowGoals();
        Console.Write("Enter goal number to record event: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    static void SaveData()
        {
            Console.Write("Enter filename to save: ");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(Score);
                writer.WriteLine(Level);
                writer.WriteLine(NextLevelThreshold);
                foreach (var goal in goals)
                {
                    writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points}");
                }
            }
            Console.WriteLine("Data saved!");
        }

    static void LoadData()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        string[] lines = File.ReadAllLines(filename);
        Score = int.Parse(lines[0]);
        Level = int.Parse(lines[1]);
        NextLevelThreshold = int.Parse(lines[2]);
        goals.Clear();
        for (int i = 3; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            string type = parts[0];
            string name = parts[1];
            int points = int.Parse(parts[2]);
            if (type == "SimpleGoal") goals.Add(new SimpleGoal(name, points));
            else if (type == "EternalGoal") goals.Add(new EternalGoal(name, points));
            else if (type == "ChecklistGoal") goals.Add(new ChecklistGoal(name, points, 0, 0));
        }
        Console.WriteLine("Data loaded!");
    }
}
