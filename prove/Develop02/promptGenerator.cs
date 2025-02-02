using System;

class Generator
{
    private static List<string> prompts;

    static Generator()
    {
        prompts = new List<string>
        {
            "What made you smile today?",
            "Describe a challenge you faced and how you overcame it.",
            "What are you grateful for right now?",
            "Write about a favorite memory.",
            "If you could travel anywhere, where would you go and why?",
            "What is something you've learned recently?",
            "Describe your ideal day.",
            "What do you hope to achieve in the next year?",
            "What is your favorite book and why?",
            "Write about someone who inspires you."
        };
    }

    public static string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}