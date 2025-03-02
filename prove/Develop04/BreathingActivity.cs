class BreathingActivity : Activity
{
    public override string GetDescription()
    {
        return "This activity will help you relax by guiding you through deep breathing exercises.";
    }

    public override void Execute()
    {
        int _elapsed = 0;
        int breatheInTime = 3;  
        int breatheOutTime = 3; 
        
        while (_elapsed < _duration)
        {
            // Breathe in
            Console.WriteLine("Breathe in...");
            ShowCountdown(breatheInTime); 
            _elapsed += breatheInTime;

            if (_elapsed >= _duration) break; 

            // Breathe out
            Console.WriteLine("Breathe out...");
            ShowCountdown(breatheOutTime); 
            _elapsed += breatheOutTime;
        }

        Console.WriteLine("Breathing exercise complete!");
    }
}
